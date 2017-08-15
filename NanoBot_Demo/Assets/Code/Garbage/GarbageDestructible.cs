using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageDestructible : GarbageBase
{
    //Functions//

    //GO Functions
    private void Awake()
    {
        base.AwakeInitialize();
    }

    //Collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<ProjectileController>() != null)
        {
            this.SpawnNurdles();
            this.DestroyGarbage();
        }
    }

    //Private
    private void SpawnNurdles()
    {
        int NumNurds = 0;
        while (NumNurds < this.NumNurdles)
        {
            //Grab Nurdles from Factory
            FactoryManager.CreateNurdle(this.transform.position);

            ++NumNurds;
        }
    }

    private void DestroyGarbage()
    {
        FactoryManager.ReturnGarbage(this);
    }

    //Variables
    [SerializeField]
    protected int NumNurdles = 3;
}
