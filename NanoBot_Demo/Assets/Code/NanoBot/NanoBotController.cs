using UnityEngine;
using UnityEngine.SceneManagement;

public class NanoBotController : MonoBehaviour
{
    //Functions//

    //GO Functions


    //void Awake ()
    //{
    //    //Set up Controller Type
    //    this.controllerStrategy = new KeyboardController();

    //    //Set up Weapons
    //    this.firingState = new Firing_Off_State();
    //    this.weaponStrategy = new Weapon_Projectile(this.CooldownTime);
    //    //this.weaponStrategy = new Weapon_Laser();

    //    //Grab Necessary Components
    //    this.SR = this.GetComponent<SpriteRenderer>();
    //    this.RB = this.GetComponent<Rigidbody2D>();
    //    this.ThrustTransform = this.GetComponentsInChildren<Transform>()[1];
    //    this.MissileTransform = this.GetComponentsInChildren<Transform>()[2];
    //    //this.Thruster = this.GetComponentsInChildren<Transform>()[2];
    //    //this.Left_Thrust = this.GetComponentsInChildren<Transform>()[2];
    //    //this.Right_Thrust = this.GetComponentsInChildren<Transform>()[3];

    //    //Set Physics Data
    //    //this.RB.centerOfMass = new Vector2(0.0f, 1.0f);
    //    this.RB.drag = this.LinearDrag;
    //    this.RB.angularDrag = this.AngularDrag;
    //    this.RB.gravityScale = 0.0f;

    //    //Set up Initial View State
    //    //this.TopDown();
    //}

    void FixedUpdate ()
    {
        //this.controllerStrategy.Update(this);
        this.viewState.ViewUpdate(this);
        //Debug.Log("Velocity: " + this.RB.velocity);
	}

    private void Update()
    {
        this.firingState.Update(this);
        //this.viewState.ViewUpdate(this);
    }

    //Initialization
    public void InitializePlayer()
    {
        //Set up Controller Type
        this.controllerStrategy = new KeyboardController();

        //Set up Weapons
        this.firingState = new Firing_Off_State();
        this.weaponStrategy = new Weapon_Projectile(this.CooldownTime);
        //this.weaponStrategy = new Weapon_Laser();

        //Grab Necessary Components
        this.SR = this.GetComponent<SpriteRenderer>();
        this.RB = this.GetComponent<Rigidbody2D>();
        this.ThrustTransform = this.GetComponentsInChildren<Transform>()[1];
        this.MissileTransform = this.GetComponentsInChildren<Transform>()[2];
        //this.Thruster = this.GetComponentsInChildren<Transform>()[2];
        //this.Left_Thrust = this.GetComponentsInChildren<Transform>()[2];
        //this.Right_Thrust = this.GetComponentsInChildren<Transform>()[3];

        //Set Physics Data
        //this.RB.centerOfMass = new Vector2(0.0f, 1.0f);
        this.RB.drag = this.LinearDrag;
        this.RB.angularDrag = this.AngularDrag;
        this.RB.gravityScale = 0.0f;
    }

    //View State Functions
    public void TopDown()
    {
        this.viewState = new TopDown_State(this.controllerStrategy, Resources.Load<Sprite>("Images/Sprite/NanoBot"));
        this.ChangeSprite();
        this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        this.transform.position = Vector3.zero;
    }

    public void SideView()
    {
        this.viewState = new SideScroll_State(this.controllerStrategy, Resources.Load<Sprite>("Images/Sprite/NanoBot_Side"));
        this.ChangeSprite();
        this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, -90.0f);
        this.transform.position = Vector3.zero;
    }

    //TopDown Movement
    public void TD_MoveForward()
    {
        this.RB.AddForceAtPosition(this.transform.up * this.Thrust_Forward, this.ThrustTransform.position);
    }

    public void TD_MoveBackward()
    {
        this.RB.AddForce(this.transform.up * -this.Thrust_Backward);
    }

    public void TD_RotateCW()
    {
        this.RB.AddForceAtPosition(this.transform.right * -this.Rotation_Thrust, this.ThrustTransform.position);
    }

    public void TD_RotateCCW()
    {
        this.RB.AddForceAtPosition(this.transform.right * this.Rotation_Thrust, this.ThrustTransform.position);
    }

    public void TD_Dive()
    {
        GameManager.SideScroll();
    }

    //SideView Movement
    public void SV_MoveForward()
    {
        this.RB.AddForceAtPosition(this.transform.up * this.Thrust_Forward, this.ThrustTransform.position);
    }

    public void SV_MoveBackward()
    {
        this.RB.AddForce(this.transform.up * -this.Thrust_Backward);
    }

    public void SV_RotateCW()
    {
        this.RB.AddForceAtPosition(this.transform.right * -this.Rotation_Thrust, this.ThrustTransform.position);
    }

    public void SV_RotateCCW()
    {
        this.RB.AddForceAtPosition(this.transform.right * this.Rotation_Thrust, this.ThrustTransform.position);
    }

    public void SV_Ascend()
    {
        GameManager.TopDown();
    }

    //Weapon Functions
    public void Fire_Weapon()
    {
        this.weaponStrategy.Fire(this);
    }

    public void Firing()
    {
        this.firingState = new Firing_On_State();
    }

    public void NotFiring()
    {
        this.firingState = new Firing_Off_State();
    }

    //Get Functions
    public Vector3 GetMissilePosition()
    {
        return this.MissileTransform.position;
    }

    //Private Functions

    //Change Sprite
    private void ChangeSprite()
    {
        this.SR.sprite = this.viewState.GetSprite();
    }


    //Variables//

    //Private//

    //Strategy
    private ViewState viewState;
    private ControllerStrategy controllerStrategy;
    private WeaponStrategy weaponStrategy;
    private FiringState firingState;

    //Prefabs
    public GameObject ProjectilePrefab;
    public GameObject LaserPrefab;

    //GO Components
    private SpriteRenderer SR;
    private Rigidbody2D RB;
    private Transform ThrustTransform;
    private Transform MissileTransform;

    //Physics
    [SerializeField]
    private float Thrust_Forward;
    [SerializeField]
    private float Thrust_Backward;
    [SerializeField]
    private float Rotation_Thrust;
    [SerializeField]
    private float LinearDrag;
    [SerializeField]
    private float AngularDrag;

    //Weapon Variable
    [SerializeField]
    private float CooldownTime;

}
