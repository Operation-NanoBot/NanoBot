//using UnityEngine;

public class AreaAggression_DetectState : AreaAggressionState
{ 
    //Functions//

    //Constructor
    public AreaAggression_DetectState()
        :base()
    {

    }

    public override void Update(AI_Area_Aggressor AAA)
    {
        AAA.DetectPlayer();

        if(AAA.PlayerDetected())
        {
            AAA.ChaseState();
        }
    }

    public override void FixedUpdate(AI_Area_Aggressor AAA)
    {
        //Intentionally does nothing
    }
}
