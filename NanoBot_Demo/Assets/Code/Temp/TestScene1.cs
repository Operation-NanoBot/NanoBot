using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScene1 : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("AWAKE!");
    }

    void Start ()
    {
        Debug.Log("START!");
	}
	
	void Update ()
    {
        Debug.Log("UPDATE!");
	}

    private void LateUpdate()
    {
        Debug.Log("LATE UPDATE!");
    }
}
