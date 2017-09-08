using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeToSideScroll : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.LoadLevel(3);
    }
}
