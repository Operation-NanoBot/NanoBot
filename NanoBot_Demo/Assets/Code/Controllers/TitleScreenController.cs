﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreenController : MonoBehaviour
{
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyUp(KeyCode.Space))
        {
            GameManager.LoadLevel(2);
        }
	}
}
