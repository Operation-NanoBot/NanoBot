using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitToWinScreen : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FactoryManager.EndLevel();
        GameManager.LoadLevel(4);
    }
}
