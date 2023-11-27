using UnityEngine;

class Pistol : Weapon
{

    public override void CheckInput()
    {
        CheckShootingMode();

        // Handle reloads
        if (Input.GetButton("Reload") && bulletsLeft < MagazineSize && !reloading) Reload();   // reload on "R" key
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0) Reload();                                   // auto reload when firing an empty clip

        /*
        print(readyToShoot);
        print(shooting);
        print(!reloading);
        print(bulletsLeft);
        */


        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            Shoot();
        }
    }


    // starter gun can always reload
    public override void Reload()
    {
        reloading = true;
        float reloadTimeMod = ReloadTime;
        
    }

    // ammo reserves dont matter for starting gun
    public override void ReloadFinished()
    {
        bulletsLeft = MagazineSize;
        reloading = false;
        launchEvent();
    }


}