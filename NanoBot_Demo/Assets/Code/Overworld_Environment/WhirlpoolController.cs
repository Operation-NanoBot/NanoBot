using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhirlpoolController : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collider)
    {
        collider.gameObject.GetComponent<Rigidbody2D>().AddForce((this.transform.position - collider.transform.position).normalized * force);
    }

    [SerializeField]
    private float force = 10.0f;
}
