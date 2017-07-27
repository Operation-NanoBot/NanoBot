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
        Destroy(this.gameObject);
    }

    //Public Functions

    //Movement Functions
    public void InitializeNurdle()
    {
        this.RB.AddForce(Random.onUnitSphere * Random.Range(MinForce, MaxForce));
        this.RB.AddTorque(Random.Range(MinTorque, MaxTorque));
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
