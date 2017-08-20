//Nurdle_Level.cs
//Nathan Andre August 2017

/*
 * This Class is an abstract class that will differentiate the different Nurdles
 * This includes Energy Given
 */

public abstract class Nurdle_Level
{
    //Functions//

    //Constructor
    public Nurdle_Level()
    {

    }

    //Get Function
    public float GetEnergy()
    {
        return this.EnergyAmount;
    }

    //Variables
    protected float EnergyAmount;


}
