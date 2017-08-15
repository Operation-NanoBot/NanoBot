 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GarbageBase : MonoBehaviour
{
    //Functions//

    protected void AwakeInitialize()
    {
        this.GetComponent<Rigidbody2D>().gravityScale = this.GravityScale;
    }

    public void Initialize(Vector3 inPos, float inRot)
    {
        this.transform.position = inPos;
        this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, inRot);
    }

    //Variables//

    [SerializeField]
    protected float GravityScale = 0.05f;
}
