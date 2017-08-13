using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoScreenController : MonoBehaviour
{
    //Functions//

    //GO Functions

	// Use this for initialization
	void Start ()
    {
        this.StartCoroutine(ChangeLevel());
	}
	
	//CoRoutine
    IEnumerator ChangeLevel()
    {
        yield return new WaitForSeconds(this.LogoTime);

        GameManager.LoadLevel(1);
    }

    //Variables//
    [SerializeField]
    private float LogoTime = 5.0f;
}
