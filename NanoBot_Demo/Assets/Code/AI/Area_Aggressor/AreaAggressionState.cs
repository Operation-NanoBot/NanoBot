using UnityEngine;

public abstract class AreaAggressionState
{
    //Functions//

    //Constructor
    public AreaAggressionState()
    {

    }

    //Update
    public abstract void Update(AI_Area_Aggressor AAA);
    public abstract void FixedUpdate(AI_Area_Aggressor AAA);

}
