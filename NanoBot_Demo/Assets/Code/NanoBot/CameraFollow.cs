using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	//Functions//

    //GO Functions
	void Update ()
    {
        this.vCurrentPos.Set(Target.transform.position.x, Target.transform.position.y, -20.0f);
        this.transform.position = this.vCurrentPos;
	}

    //Public Functions
    public void AssignTarget(Transform inTrans)
    {
        this.Target = inTrans;
    }

    //Variables//

    //Private
    private Vector3 vCurrentPos;
    private Transform Target;
}
