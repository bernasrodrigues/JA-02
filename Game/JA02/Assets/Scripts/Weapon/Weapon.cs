using UnityEngine;
using Random = UnityEngine.Random;

public abstract class Weapon : MonoBehaviour
{

    public delegate void OnBulletChangeDelegate(int bulletsLeft, int ammoReserve);
    public static event OnBulletChangeDelegate OnBulletChange;      // this event is sent with info regarding ammo count, ammoDisplay receives the event and updates it's values

    [Header("Ammo Stats")]
    public int bulletsLeft;
    public int magazineSize;
    public int ammoReserve;
    public int maximumAmmo;


    /*
    bulletsLeft = bullets that the player has in the magazine (bullets ready to shoot before having to reload)
    magazineSize = maximum number of bullets that each magazine holds
    ammoReserve = ammo that the player has in reserve
    maximumAmmo = maximum amount of ammo that the player can store/have in reserve
     */

    [Header("Gun Stats")]
    [SerializeField]
    protected float _damage;
    [SerializeField]
    protected float _fireRate;
    [SerializeField]
    protected float _spread;
    [SerializeField]
    protected float _reloadTime;
    [SerializeField]
    protected float _equipSpeedModifier;
    [SerializeField]
    protected float bulletSpeed;
    [SerializeField]
    protected float _bulletsPerShoot;

    // properties (weapon stats with the applied Character Stat)
    /*
    public float Damage { get { return _damage * CharacterStats.GetStat(StatAtribute.damageModifier); } }
    public float FireRate { get { return _fireRate * CharacterStats.GetStat(StatAtribute.fireRateModifier); } }
    public float Spread { get { return _spread * CharacterStats.GetStat(StatAtribute.spreadModifier); } }
    public float ReloadTime { get { return _reloadTime * CharacterStats.GetStat(StatAtribute.reloadSpeedModifier); } }
    public float EquipSpeedModifier { get { return _equipSpeedModifier * CharacterStats.GetStat(StatAtribute.equipSpeedModifier); } }
    public float BulletsPerShoot { get { return _bulletsPerShoot * CharacterStats.GetStat(StatAtribute.bulletQuantityModifier); } }
    public int MagazineSize { get { return (int)(magazineSize + CharacterStats.GetStat(StatAtribute.magazineSizeModifier)); } }
    public int MaximumAmmo { get { return (int)(maximumAmmo + CharacterStats.GetStat(StatAtribute.magazineSizeModifier)); } }

    */

    // Change to use character stats
    public float Damage { get { return _damage; } }
    public float FireRate { get { return _fireRate; } }
    public float Spread { get { return _spread ; } }
    public float ReloadTime { get { return _reloadTime; } }
    public float EquipSpeedModifier { get { return _equipSpeedModifier ; } }
    public float BulletsPerShoot { get { return _bulletsPerShoot ; } }
    public int MagazineSize { get { return (int)(magazineSize) ; } }
    public int MaximumAmmo { get { return (int)(maximumAmmo ); } }


    public FireMode firemode;
    public bool isInInventory;
    /*
    damage = the damage each shoot does
    fireRate = how fast the weapon shoots (time between shots)              lower "fireRate"    ->  more bullets fired
    spread = how much the shoots deviate from their intended tragectory     higher "spread"     ->  the less acurate the weapon is    
    reloadTime = time the weapon takes to reload
    bulletSpeed = how fast the bullet is shoot from the gun
    bulletsPerShoot = how many bullets the weapon shoots each time it is fired (ex: shotgun fires multiple bullets while pistol only shoots one)
    firemode = How the weapon fires
    */

    // bolleans
    protected bool shooting = false, reloading = false, readyToShoot = true, shootCooldown = true;
    /*
    shooting -> check if shooting
    reloading -> to check if reloading
    readytoShoot -> if it can be shoot
    shootCooldown -> after firing each shoot a cooldown is issued before being able to fire the next
     */

    [Header("Other")]
    public GameObject projectile;       // bullets object that the gun fires
    public Transform firePoint;         // where the bullets are fired from
    public AudioClip shootAudio;
    public float minPitch, maxPitch;

    public abstract void CheckInput();


    private void Start()
    {
        Physics.IgnoreLayerCollision(6, 10);
    }


    public void CheckShootingMode()     // check if a weapon is fired as automatic or as single fire
    {
        if (firemode == FireMode.Auto) shooting = Input.GetMouseButton(0);
        else if (firemode == FireMode.Single) shooting = Input.GetMouseButtonDown(0);
    }

    public void Shoot()
    {
        readyToShoot = true;
        Vector3 direction = GetTargetDirection();

        for (int i = 1; i <= BulletsPerShoot; i++)
        {
            direction = ApplySpread(direction);         // apply spread to the direction
            GameObject bullet = InstantiateBullet();
            bullet.transform.forward = direction.normalized;                                                   // bullet pointing forward
            bullet.GetComponent<Rigidbody>().AddForce(direction.normalized * bulletSpeed, ForceMode.Impulse);
            //bullet.GetComponent<Rigidbody>().AddForce(firstPersonCamera.transform.up * upwardForce, ForceMode.Impulse);   // for grenades
        }

        bulletsLeft--;
        launchEvent();
        if (shootCooldown)
        {
            //Debug.Log("Shot colldown");
            Invoke("ResetShot", FireRate);
            shootCooldown = false;
        }
    }

    public void EnemyShoot(Vector3 direction)
    {
        readyToShoot = true;

        for (int i = 1; i <= BulletsPerShoot; i++)
        {
            direction = ApplySpread(direction);         // apply spread to the direction
            GameObject bullet = InstantiateBullet();
            bullet.transform.forward = direction.normalized;                                                   // bullet pointing forward
            bullet.GetComponent<Rigidbody>().AddForce(direction.normalized * bulletSpeed, ForceMode.Impulse);
        }
    }

    /*
        private void Update() {
            // ray to the middle of the screen (where the camera is pointing)
            Ray ray = firstPersonCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            // Check if hit something
            Vector3 targetPoint;
            if (Physics.Raycast(ray, out hit))
            {
                print(hit.collider.name);
                Debug.DrawLine(transform.position, hit.point, Color.red);
                targetPoint = hit.point;    // if hit something target -> point hit
            }
        }
    */

    public Vector3 GetTargetDirection()
    {

        Vector3 direction = PlayerMovement.Instance.GetAimingPosition() - PlayerMovement.Instance.gameObject.transform.position;


        return direction.normalized;





        /*

        // ray to the middle of the screen (where the camera is pointing)
        Ray ray = firstPersonCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;


        // Check if hit something
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;    // if hit something target -> point hit
        }
        else
        {
            targetPoint = ray.GetPoint(75); // if nothing is hit, point to a point far away from the player
        }

        // calculate direction vector  ( -> targetPoint - firePoint)
        Vector3 direction = targetPoint - firePoint.position;
        return direction;

            */
    }


    public Vector3 ApplySpread(Vector3 direction)
    {
        float x = Random.Range(-Spread, Spread);
        float y = Random.Range(-Spread, Spread);
        direction += new Vector3(x, y, 0);

        return direction;
    }


    public void ResetShot()
    {
        readyToShoot = true;
        shootCooldown = true;
        //Debug.Log(readyToShoot);
    }

    // Check if able to reload, if able -> call "reloadFinished" method
    public virtual void Reload()
    {
        print("AAAAAABBBBBBBBBBBAAAA");
        if (ammoReserve > 0)
        {
            reloading = true;
            Invoke("ReloadFinished", ReloadTime);

        }
    }

    // Performs the reload
    public virtual void ReloadFinished()
    {
        ammoReserve += bulletsLeft;     // add unused ammo to ammoReserve
        if (ammoReserve < MagazineSize)    // if reserve ammo cant fill a full magazine -> magazine is filled with whatever ammo is left
        {
            bulletsLeft = ammoReserve;
            ammoReserve = 0;
        }
        else
        {
            bulletsLeft = MagazineSize;     // if  leftover reserve ammo -> fill magazine
            ammoReserve -= MagazineSize;
        }
        launchEvent();
        reloading = false;
    }


    // When the weapon is enabled (when it is equiped) it delays until weapon can be fired
    public virtual void OnEnable()
    {
        readyToShoot = false;
        ResetShot();
        launchEvent();
    }


    public virtual GameObject InstantiateBullet()       // created the bullet and sets the variables(damage)
    {
        GameObject bullet = Instantiate(projectile, firePoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetDamage(this.Damage);

        return bullet;
    }




    public virtual void launchEvent()       // launch bullet that shows the number of bullets changed
    {
        if (OnBulletChange != null)
        {
            OnBulletChange(bulletsLeft, ammoReserve);
        }
        else
        {
            Debug.Log("subscriver expected but none received... event not sent");
        }
    }


    public enum FireMode
    {
        Single,
        Auto,
    }

}