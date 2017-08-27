using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurdlesController : MonoBehaviour
{
    //Functions//

    //GO Functions
    private void Awake()
    {
        //Grab Components
        this.RB = this.GetComponent<Rigidbody2D>();
        this.Target = FindObjectOfType<NbSidescrollController>().transform;
    }

    private void Start()
    {
        this.nurdleLevel = new NurdleLevelOne();
    }

    private void Update()
    {
        this.nurdleState.Update(this);
    }

    //Collisions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SonicNet SN = collision.gameObject.GetComponent<SonicNet>();
        if (SN != null)
        {
            this.nurdleState.TriggerEnter(collision, this);
        }
        else if(collision.gameObject.GetComponent<EnergyCollector>() != null)
        {
            this.DestroyNurdle();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        this.nurdleState.TriggerExit(collision, this);
    }

    //Public Functions

    //Movement Functions
    public void InitializeNurdle(Vector3 inPos)
    {
        this.transform.position = inPos;
        this.nurdleState = floatState;

        this.RB.AddForce(Random.onUnitSphere * Random.Range(MinForce, MaxForce));
        this.RB.AddTorque(Random.Range(MinTorque, MaxTorque));
    }

    public void MoveTowardTarget()
    {
        this.RB.AddForce((this.Target.position - this.transform.position).normalized * this.MoveForce);
    }

    //State Changes
    public void SuckState()
    {
        this.nurdleState = suckState;
    }

    public void FloatState()
    {
        this.nurdleState = floatState;
    }

    //Getters
    public float GetEnergyAmount()
    {
        return this.nurdleLevel.GetEnergy();
    }

    //Private
    private void DestroyNurdle()
    {
        FactoryManager.ReturnNurdle(this);
    }

    //Variables//

    //Private

    //Componenets
    private Rigidbody2D RB;
    private Transform Target;

    //State
    private NurdleState nurdleState;
    private static Nurdle_Float_State floatState = new Nurdle_Float_State();
    private static Nurdle_Suck_State suckState = new Nurdle_Suck_State();

    //Level
    private Nurdle_Level nurdleLevel;

    //Physics
    [SerializeField]
    private float MinTorque;
    [SerializeField]
    private float MaxTorque;
    [SerializeField]
    private float MinForce;
    [SerializeField]
    private float MaxForce;
    [SerializeField]
    private float MoveForce = 5.0f;


}
