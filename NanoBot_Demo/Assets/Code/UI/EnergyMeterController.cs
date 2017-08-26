//EnergyMeterController.cs
//Nathan Andre August 2017

/*
 * This Controls the UI Unity Slider to Show how much energy the Nanobot currently has.
 * It will Reset at the beginning of every SideScroll Level 
 */
using UnityEngine;
using UnityEngine.UI;

public class EnergyMeterController : MonoBehaviour
{
    //Functions//

    //GO Functions
    private void Awake()
    {
        //Grab Slider Component
        this.slider = GetComponent<Slider>();
        this.fillImage = this.slider.GetComponentsInChildren<Image>()[1];
    }

    private void Start()
    {
        //Set Values to Max
        this.slider.normalizedValue = 1.0f;
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.O))
        {
            this.MinusEnergy(0.1f);
        }

        if (Input.GetKeyUp(KeyCode.P))
        {
            this.AddEnergy(0.1f);
        }
    }

    //Value Changing functions
    public void AddEnergy(float inVal)
    {
        this.slider.normalizedValue += inVal;

        this.CheckEmpty();
    }

    public void MinusEnergy(float inVal)
    {
        this.slider.normalizedValue -= inVal;

        this.CheckEmpty();
    }

    private void CheckEmpty()
    {
        if(this.slider.normalizedValue == 0.0f)
        {
            this.fillImage.color = Color.red;
        }
    }

    //Variables//

    //Components
    private Slider slider;
    private Image fillImage;

    //Values
    private float CurrentEnergyPercentage;
}

