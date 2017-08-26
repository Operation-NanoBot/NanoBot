using UnityEngine;

public class DepleteEnergyOverTime : MonoBehaviour
{

	// Use this for initialization
	void Awake ()
    {
        emc = GetComponent<EnergyMeterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        emc.MinusEnergy(energyDepletion);
	}

    private EnergyMeterController emc;
    private const float energyDepletion = 0.0001f;
}
