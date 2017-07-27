using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageBase : MonoBehaviour
{
    //Functions//

    //Collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("COLLISION");
        if(collision.gameObject.GetComponent<ProjectileController>() != null)
        {
            this.SpawnNurdles();
            Destroy(this.gameObject);
        }
    }

    //Public
    public virtual void SpawnNurdles()
    {
        int NumNurds = 0;
        while(NumNurds < this.NumNurdles)
        {
            //Grab Nurdles from Factory
            NurdlesFactory.CreateNurdle(this.transform.position);

            ++NumNurds;
        }
    }



    //Variables
    [SerializeField]
    protected int NumNurdles;
}
