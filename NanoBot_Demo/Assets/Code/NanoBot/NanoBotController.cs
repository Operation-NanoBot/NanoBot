﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NanoBotController : MonoBehaviour
{
    //Functions//

    //GO Functions


    void Start ()
    {
        //Set up Keyboard for now
        this.controllerStrategy = new KeyboardController();

        //Set up Weapons
        this.weaponStrategy = new Weapon_Projectile(this.CooldownTime);
        //this.weaponStrategy = new Weapon_Laser();

        //Grab Necessary Components
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
	
	void FixedUpdate ()
    {
        this.controllerStrategy.Update(this);
        //Debug.Log("Velocity: " + this.RB.velocity);
	}

    //Movement Functions
    //public void MoveForward()
    //{
    //    this.RB.AddForce(this.transform.up * this.Thrust_Forward);
    //}

    public void MoveForward2()
    {
        this.RB.AddForceAtPosition(this.transform.up * this.Thrust_Forward, this.ThrustTransform.position);
    }

    //public void MoveForward3()
    //{
    //    this.RB.AddForceAtPosition(this.Thruster.transform.up * this.Thrust_Forward, this.Thruster.transform.position);
    //}

    //public void MoveForward4()
    //{
    //    this.RB.AddForceAtPosition(this.transform.up * (this.Thrust_Forward / 2.0f), this.Left_Thrust.position);
    //    this.RB.AddForceAtPosition(this.transform.up * (this.Thrust_Forward / 2.0f), this.Right_Thrust.position);
    //}

    public void MoveBackward()
    {
        this.RB.AddForce(this.transform.up * -this.Thrust_Backward);
    }

    //public void RotateCW()
    //{
    //    this.RB.AddTorque(-this.Rotation_Thrust);
    //}

    public void RotateCW2()
    {
        this.RB.AddForceAtPosition(this.transform.right * -this.Rotation_Thrust, this.ThrustTransform.position);
    }

    //public void RotateCW3()
    //{
    //    this.Thruster.Rotate(new Vector3(0.0f, 0.0f, this.ThrustTransform.position.y), -this.Rotation_Thrust);
    //}

    //public void RotateCW4()
    //{
    //    this.RB.AddForceAtPosition(this.transform.up * this.Thrust_Forward / 2.0f, this.Left_Thrust.position);
    //}

    //public void RotateCCW()
    //{
    //    this.RB.AddTorque(this.Rotation_Thrust);
    //}

    public void RotateCCW2()
    {
        this.RB.AddForceAtPosition(this.transform.right * this.Rotation_Thrust, this.ThrustTransform.position);
    }

    //public void RotateCCW4()
    //{
    //    this.RB.AddForceAtPosition(this.transform.up * this.Thrust_Forward / 2.0f, this.Right_Thrust.position);
    //}

    //Weapon Functions
    public void Fire_Weapon()
    {
        //this.weaponStrategy.Fire();
        this.weaponStrategy.Fire(this);
    }

    //Get Functions
    public Vector3 GetMissilePosition()
    {
        return this.MissileTransform.position;
    }


    //Variables//

    //Private//

    //Strategy
    private ControllerStrategy controllerStrategy;
    private WeaponStrategy weaponStrategy;

    //Prefabs
    public GameObject ProjectilePrefab;
    public GameObject LaserPrefab;

    //GO Components
    private Rigidbody2D RB;
    private Transform ThrustTransform;
    private Transform MissileTransform;
    //private Transform Left_Thrust;
    //private Transform Right_Thrust;
    //private Transform Thruster;

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
