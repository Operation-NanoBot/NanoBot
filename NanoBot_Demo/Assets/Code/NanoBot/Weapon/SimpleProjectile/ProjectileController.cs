using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    //Functions//

	//GO Functions
	void Awake () //This code is initiated when Instantiate is called right away from what I read.
    {
        //Grab Components
        this.RB = this.GetComponent<Rigidbody2D>();

        //Set Physics Data
        this.RB.gravityScale = 0.0f;
	}
	void FixedUpdate ()
    {
        //Limit Max Velocity
        if (this.RB.velocity.sqrMagnitude < (MaxVelocity * MaxVelocity))
        {
            this.RB.MovePosition(this.transform.position + (this.transform.up * ProjectileSpeed * this.DirectionMult));
        }
    }

    //Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.DestroyProjectile();
    }

    //Rotation
    public void Initialize(Vector3 inPos, float inDir)
    {
        //Set Rotation
        this.DirectionMult = inDir;
        this.transform.position = inPos;

        //Start Coroutine
        StartCoroutine(DestroySelf());
    }

    //CoRoutines
    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(DestroyTime);
        DestroyProjectile();
    }

    //Private
    private void DestroyProjectile()
    {
        FactoryManager.ReturnSimpleProjectile(this);
    }

    //Variables//
    
    //Components
    private Rigidbody2D RB;

    //Physics
    [SerializeField]
    private float MaxVelocity = 20.0f;
    [SerializeField]
    private float ProjectileSpeed = 0.5f;
    [SerializeField]
    private float DestroyTime = 4.0f;

    private float DirectionMult;
}
