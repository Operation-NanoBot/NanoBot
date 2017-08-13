using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressSpace : MonoBehaviour
{
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyUp(KeyCode.Space))
        {
            GameManager.LoadLevel(this.LevelNum);
        }
	}

    public int LevelNum = 0;
}
