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
        if (this.RB.velocity.sqrMagnitude < (MaxVelocity * MaxVelocity))
        {
            //this.RB.AddForce(this.transform.up * ProjectileForce);
            this.RB.MovePosition(this.transform.position + (this.transform.up * ProjectileSpeed));
        }
        //Debug.Log("Velocity: " + this.RB.velocity);
    }

    //Collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }

    //Rotation
    public void RotateProjectile(float zRot)
    {
        this.transform.Rotate(0.0f, 0.0f, zRot);
    }

    //Destruction
    public void DestructTimerStart()
    {
        this.StartCoroutine(DestroySelf());
    }

    //CoRoutines
    IEnumerator DestroySelf()
    {
        yield return new WaitForSeconds(DestroyTime);
        Destroy(this.gameObject);
    }

    //Variables//
    
    //Components
    private Rigidbody2D RB;

    //Physics
    [SerializeField]
    private float MaxVelocity;
    [SerializeField]
    private float ProjectileSpeed;
    [SerializeField]
    private float DestroyTime;
}
