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

        //Set Energy
        this.EnergyAmount = 0.1f;
    }

    //Collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<NbSidescrollController>() != null)
        {
            this.DestroyNurdle();
        }
    }

    //Public Functions

    //Movement Functions
    public void InitializeNurdle(Vector3 inPos)
    {
        this.transform.position = inPos;

        this.RB.AddForce(Random.onUnitSphere * Random.Range(MinForce, MaxForce));
        this.RB.AddTorque(Random.Range(MinTorque, MaxTorque));
    }

    //Getters
    public float GetEnergyAmount()
    {
        return this.EnergyAmount;
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

    //Energy
    private float EnergyAmount;

    //Physics
    [SerializeField]
    private float MinTorque;
    [SerializeField]
    private float MaxTorque;
    [SerializeField]
    private float MinForce;
    [SerializeField]
    private float MaxForce;


}
