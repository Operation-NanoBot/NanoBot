using UnityEngine;

public class AI_Base : MonoBehaviour
{
    //Functions//

    //GO Functions
    protected void Initialize()
    {
        this.Target = FindObjectOfType<NbSidescrollController>().gameObject.transform;
    }

    //Collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<ProjectileController>() != null)
        {
            Destroy(this.gameObject);
        }
    }

    //Variables//
    protected Transform Target;
}
