using UnityEngine;

public class EnergyCollector : MonoBehaviour
{
    //Functions//

    //GO Functions
    private void Start()
    {
        this.NB = FindObjectOfType<NbSidescrollController>();
    }

    //Collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        NurdlesController NC = collision.gameObject.GetComponent<NurdlesController>();
        if(NC != null)
        {
            this.NB.AddEnergy(NC.GetEnergyAmount());
        }
    }

    //Variables//

    private NbSidescrollController NB;
}
