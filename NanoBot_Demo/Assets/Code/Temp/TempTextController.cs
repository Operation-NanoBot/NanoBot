using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempTextController : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        isActive = true;
        this.text = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKeyUp(KeyCode.P))
        {
            if (this.isActive)
            {
                this.isActive = false;
                this.text.gameObject.SetActive(false);
            }
            else
            {
                this.text.gameObject.SetActive(true);
                this.isActive = true;
            }
        }
	}

    private bool isActive;
    private Text text;

}
