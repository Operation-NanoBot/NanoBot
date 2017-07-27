//using UnityEngine;

public class AreaAggression_ChaseState : AreaAggressionState
{
    //Functions//

    //Constructor
    public AreaAggression_ChaseState()
        :base()
    {

    }

    public override void Update(AI_Area_Aggressor AAA)
    {
        AAA.DetectPlayer();
    }

    public override void FixedUpdate(AI_Area_Aggressor AAA)
    {
        AAA.ChasePlayer();
    }

}
