using System;
using UnityEngine;

public class Nurdle_Suck_State : NurdleState
{
    //Functions//

    //Constuctor
    public Nurdle_Suck_State()
    {

    }

    public override void Update(NurdlesController NC)
    {
        NC.MoveTowardTarget();
    }

    public override void TriggerEnter(Collider2D collision, NurdlesController NC)
    {
        //Intentionally does nothing
    }

    public override void TriggerExit(Collider2D collider, NurdlesController NC)
    {
        NC.FloatState();
    }
}
