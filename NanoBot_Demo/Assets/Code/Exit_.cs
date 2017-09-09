using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit_ : MonoBehaviour
{
	
	// Update is called once per frame
	void Update ()
    {
		if( Input.GetKeyUp( KeyCode.Escape ) )
        {
            Application.Quit();
        }
	}
}
