using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiveSpot : MonoBehaviour
{
    //Functions//

    //GO Functions

    //Collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Only Collides with Player in Physics2D Matrix
        other.GetComponent<NbTopdownController>().SetDiveLevel(this.LevelIndex);
    }

    //Variables//

    [SerializeField]
    private int LevelIndex = 0;
}
