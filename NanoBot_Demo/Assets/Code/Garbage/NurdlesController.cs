using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NurdlesController : MonoBehaviour
{
    //Functions//

    //GO Functions
    private void Awake()
    {
        this.RB = this.GetComponent<Rigidbody2D>();
    }

    //Collisions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.DestroyNurdle();
    }

    //Public Functions

    //Movement Functions
    public void InitializeNurdle(Vector3 inPos)
    {
        this.transform.position = inPos;

        this.RB.AddForce(Random.onUnitSphere * Random.Range(MinForce, MaxForce));
        this.RB.AddTorque(Random.Range(MinTorque, MaxTorque));
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
