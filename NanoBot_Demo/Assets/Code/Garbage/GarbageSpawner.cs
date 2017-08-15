using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageSpawner : MonoBehaviour
{
    //Functions//

    //GO Functions
    private void Awake()
    {
        this.StartCoroutine(SpawnGarbage());
    }

    //CoRoutines
    IEnumerator SpawnGarbage()
    {
        yield return new WaitForSeconds(this.SpawnFrequency);

        this.CreateGarbage();

        StartCoroutine(SpawnGarbage());
    }

    //Private
    private void CreateGarbage()
    {
        int rand = Random.Range(0, 2);

        if(rand == 0)
        {
            FactoryManager.CreateDestructibleGarbage(this.transform.position, 0.0f);
        }
        else
        {
            FactoryManager.CreateIndestructibleGarbage(this.transform.position, 0.0f);
        }
    }

    //Variables

    [SerializeField]
    private float SpawnFrequency = 5.0f;
}
