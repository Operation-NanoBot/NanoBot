using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NbSidescrollController : NanoBotController
{
    //Functions//

    //GO Functions
    private void Start()
    {
        base.Initialize();

        //Initialize Weapon Strategy
        this.weaponStrategy = new Weapon_Projectile(this.cooldownTime);


        //Grab Components
        this.Missile_Transform = GetComponentsInChildren<Transform>()[2];

        //Set Physics Data
        //this.RB.centerOfMass = new Vector2(0.0f, 1.0f);
        this.RB.drag = this.LinearDrag;
        this.RB.angularDrag = this.AngularDrag;

        //Set Rotation to Sideways
        this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 270.0f);

        //Level Initialization
        this.InitializeLevel(GameManager.GetData());
    }

    private void FixedUpdate()
    {
        this.controllerStrategy.SideView_Update(this);
    }

    //Level Initialization
    public void InitializeLevel(NanobotData inData)
    {
        //Nothing for now
    }

    //Movement Functions
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
        GameManager.Ascend(this);
    }

    //Weapon Functions
    public void FireWeapon()
    {
        this.weaponStrategy.Fire(this);
    }

    //Get Functions
    public Vector3 GetMissilePosition()
    {
        return this.Missile_Transform.position;
    }

    //Variables//

    //Strategy
    private WeaponStrategy weaponStrategy;

    //Components
    private Transform Missile_Transform;

    //Physics
    [SerializeField]
    private float Thrust_Forward = 1.0f;
    [SerializeField]
    private float Thrust_Backward = 1.0f;
    [SerializeField]
    private float Rotation_Thrust = 1.0f;
    [SerializeField]
    private float LinearDrag = 0.5f;
    [SerializeField]
    private float AngularDrag = 0.1f;

    //Temporary, just for Design use
    [SerializeField]
    private float cooldownTime = 1.0f;
}
