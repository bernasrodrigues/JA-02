using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]

public class PlayerMovement : MonoBehaviour
{
    //Player Camera variables
    public enum CameraDirection { x, z }
    public CameraDirection cameraDirection = CameraDirection.x;
    public float cameraHeight = 20f;
    public float cameraDistance = 7f;
    public Camera playerCamera;
    public GameObject targetIndicatorPrefab;
    //Player Controller variables
    public float speed = 5.0f;
    public float gravity = 14.0f;
    public float maxVelocityChange = 10.0f;
    public bool canJump = true;
    public float jumpHeight = 2.0f;
    
    //Private variables
    bool grounded = false;
    Rigidbody r;
    GameObject targetObject;
    //Mouse cursor Camera offset effect
    Vector2 playerPosOnScreen;
    Vector2 cursorPosition;
    Vector2 offsetVector;
    //Plane that represents imaginary floor that will be used to calculate Aim target position
    Plane surfacePlane = new Plane();

    [SerializeField]  private Weapon equipedWeapon;
    public static PlayerMovement Instance { get; private set; }






    void Awake()
    {

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }









        r = GetComponent<Rigidbody>();
        r.freezeRotation = true;
        r.useGravity = false;

        //Instantiate aim target prefab
        if (targetIndicatorPrefab)
        {
            targetObject = Instantiate(targetIndicatorPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        }

        //Hide the cursor
        Cursor.visible = false;
    }





    private void Update()
    {
        UpdateRenderDistance();

        if (equipedWeapon != null)
            if (equipedWeapon.gameObject.activeSelf)  // don't check inputs while the weapon is inactive (when switching weapons)
                equipedWeapon.CheckInput();    // handle equiped weapon
    }


    private float CalculateLODBias(float y) {
        float y1 = 10f;
        float lodBias1 = 2f;
        float y2 = 200f;
        float lodBias2 = 5f;

        float m = (lodBias2 - lodBias1) / (y2 - y1);
        float b = lodBias1 - m * y1;

        float lodBias = m * y + b;
        return lodBias;
    }

    private void UpdateRenderDistance() {
        
    // y: 10 -> LOD Bias: 2
    // y: 200 -> LOD Bias: 5
        QualitySettings.lodBias = CalculateLODBias(playerCamera.transform.position.y);
    }






    private void FixedUpdate()
    {
        //Setup camera offset
        /**Vector3 cameraOffset = Vector3.zero;
        if (cameraDirection == CameraDirection.x)
        {
            cameraOffset = new Vector3(cameraDistance, cameraHeight, 0);
        }
        else if (cameraDirection == CameraDirection.z)
        {
            cameraOffset = new Vector3(0, cameraHeight, cameraDistance);
        } **/
        Vector3 cameraOffset = new Vector3(0, cameraHeight, 0);

        if (grounded)
        {
            MoveCommand moveCMD = new MoveCommand(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"), this);
            CommandManager.Instance.AddCommand(moveCMD);



            // Jump
            if (canJump && Input.GetButton("Jump"))
            {
                JumpCommand jumpCMD = new JumpCommand(this);
                CommandManager.Instance.AddCommand(jumpCMD);
            }

        }






        // We apply gravity manually for more tuning control
        r.AddForce(new Vector3(0, -gravity * r.mass, 0));

        grounded = false;

        //Mouse cursor offset effect
        /**playerPosOnScreen = playerCamera.WorldToViewportPoint(transform.position);
        cursorPosition = playerCamera.ScreenToViewportPoint(Input.mousePosition);
        offsetVector = cursorPosition - playerPosOnScreen; **/

        //Camera follow
        /** playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, transform.position + cameraOffset, Time.deltaTime * 7.4f);
        playerCamera.transform.LookAt(transform.position + new Vector3(-offsetVector.y * 2, 0, offsetVector.x * 2));
        **/
        if(GameSystem.instance.InGame){
            playerCamera.GetComponent<CameraController>().Follow(transform.position, Time.deltaTime * 7.4f);
        }

        //Aim target position and rotation        
        targetObject.transform.position = GetAimTargetPos();
        targetObject.transform.LookAt(new Vector3(transform.position.x, targetObject.transform.position.y, transform.position.z));
        

        //Player rotation
        transform.LookAt(new Vector3(targetObject.transform.position.x, transform.position.y, targetObject.transform.position.z));
    }

    Vector3 GetAimTargetPos()
    {
        //Update surface plane
        surfacePlane.SetNormalAndPosition(Vector3.up, transform.position);

        //Create a ray from the Mouse click position
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        //Initialise the enter variable
        float enter = 0.0f;

        if (surfacePlane.Raycast(ray, out enter))
        {
            //Get the point that is clicked
            Vector3 hitPoint = ray.GetPoint(enter);

            //Move your cube GameObject to the point where you clicked
            return hitPoint;
        }

        //No raycast hit, hide the aim target by moving it far away
        return new Vector3(-5000, -5000, -5000);
    }


    void OnCollisionStay()
    {
        grounded = true;
    }


    #region Setters/Getters
    public Rigidbody GetRigidBody()
    {
        return r;
    }

    public Vector3 GetAimingPosition()
    {

        return targetObject.transform.position;

    }

    #endregion







}