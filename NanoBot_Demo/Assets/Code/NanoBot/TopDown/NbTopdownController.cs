using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NbTopdownController : NanoBotController
{
    //Functions//

    //GO Functions
    private void Start()
    {
        base.Initialize();

        //Set Physics Data
        //this.RB.centerOfMass = new Vector2(0.0f, 1.0f);
        this.RB.drag = this.LinearDrag;
        this.RB.angularDrag = this.AngularDrag;

        //Grab Data From GameManager;
        this.InitializeLevel(GameManager.GetData());
    }

    private void FixedUpdate()
    {
        this.controllerStrategy.TopDown_Update(this);
    }

    //Level Initialization
    private void InitializeLevel(NanobotData inData)
    {
        this.transform.position = inData.Overworld_Dive_Position;
        this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, inData.Overworld_Dive_Rotation);
    }

    //Dive Level Setter
    public void SetDiveLevel(int inIndex)
    {
        this.DiveLevelIndex = inIndex;
    }

    //Movement Functions
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
        GameManager.Dive(this, this.DiveLevelIndex);
    }

    //Variables//

    //Dive Level Index
    private int DiveLevelIndex;

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
}
