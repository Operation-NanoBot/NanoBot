using UnityEngine;

public class NbSidescrollController : NanoBotController
{
    //Functions//

    //GO Functions
    private void Start()
    {
        base.Initialize();

        //Initialize State
        this.directionState = rightState;

        //Initialize Weapon Strategy
        this.weaponStrategy = new Weapon_Projectile(this.cooldownTime);


        //Grab Components
        this.Nose_Transform = GetComponentsInChildren<Transform>()[1];
        this.energyMeter = FindObjectOfType<EnergyMeterController>();

        //Set Physics Data
        //this.RB.centerOfMass = new Vector2(0.0f, 1.0f);
        this.RB.drag = this.LinearDrag;
        this.RB.gravityScale = 0.05f;

        //Level Initialization
        this.InitializeLevel(GameManager.GetData());
    }

    private void FixedUpdate()
    {
        this.directionState.Update(this, this.controllerStrategy);
    }

    //Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //NurdlesController NC = collision.gameObject.GetComponent<NurdlesController>();
        //if(NC != null)
        //{
        //    this.AddEnergy(NC.GetEnergyAmount());
        //}
    }

    //Level Initialization
    public void InitializeLevel(NanobotData inData)
    {
        //Nothing for now
    }

    //Movement Functions
    public void SV_MoveRight()
    {
        this.RB.AddForce(this.transform.right * this.Thrust_Right);
    }

    public void SV_MoveLeft()
    {
        this.RB.AddForce(this.transform.right * -this.Thrust_Left);
    }

    public void SV_MoveUp()
    {
        this.RB.AddForce(this.transform.up * this.Thrust_Up);
    }

    public void SV_MoveDown()
    {
        this.RB.AddForce(this.transform.up * -this.Thrust_Down);
    }

    public void SV_Ascend()
    {
        GameManager.Ascend(this);
    }

    //State Change Functions
    public void ChangeToRightState()
    {
        //Change the State
        this.directionState = rightState;

        //Flip the Sprite
        this.SR.flipX = false;

        //Move the Nose Position
        this.Nose_Transform.localPosition = new Vector3(1.5f, 0.0f);
    }

    public void ChangeToLeftState()
    {
        //Change the State
        this.directionState = leftState;

        //Flip the Sprite
        this.SR.flipX = true;

        //Move the Nose Position
        this.Nose_Transform.localPosition = new Vector3(-1.5f, 0.0f);
    }

    //Weapon Functions
    public void FireWeapon()
    {
        this.weaponStrategy.Fire(this, this.directionState);
    }

    //Energy Functions
    public void AddEnergy(float inVal)
    {
        this.energyMeter.AddEnergy(inVal);
    }

    public void MinusEnergy(float inVal)
    {
        this.energyMeter.MinusEnergy(inVal);
    }

    //Get Functions
    public Vector3 GetNosePosition()
    {
        return this.Nose_Transform.position;
    }

    //Variables//

    //States
    private NB_SS_Direction_State directionState;
    private static NB_SS_Direction_Left_State leftState = new NB_SS_Direction_Left_State();
    private static NB_SS_Direction_Right_State rightState = new NB_SS_Direction_Right_State();


    //Strategy
    private WeaponStrategy weaponStrategy;

    //Components
    private Transform Nose_Transform;
    private EnergyMeterController energyMeter;

    //Physics
    [SerializeField]
    private float Thrust_Right = 1.0f;
    [SerializeField]
    private float Thrust_Left = 1.0f;
    [SerializeField]
    private float Thrust_Up = 1.0f;
    [SerializeField]
    private float Thrust_Down = 1.0f;
    [SerializeField]
    private float LinearDrag = 0.5f;

    //Temporary, just for Design use
    [SerializeField]
    private float cooldownTime = 1.0f;
}
