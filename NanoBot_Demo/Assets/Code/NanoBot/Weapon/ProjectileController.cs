using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    //Functions//

	//GO Functions
	void Awake ()
    {
        //Grab Components
        this.RB = this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.RB.AddForce(this.transform.up * ProjectileForce);
	}

    //Variables//
    
    //Components
    private Rigidbody2D RB;

    //Physics
    [SerializeField]
    private float MaxVelocity;
    [SerializeField]
    private float ProjectileForce;
}
