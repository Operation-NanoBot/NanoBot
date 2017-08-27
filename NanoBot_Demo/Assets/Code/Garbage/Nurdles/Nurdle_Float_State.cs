using System;
using UnityEngine;

public class Nurdle_Float_State : NurdleState
{
    //Functions//

    //Constructor
    public Nurdle_Float_State()
        :base()
    {

    }

    public override void Update(NurdlesController NC)
    {
        //Intentionally does nothing
    }

    public override void TriggerEnter(Collider2D collision, NurdlesController NC)
    {
        NC.SuckState();
    }

    public override void TriggerExit(Collider2D collider, NurdlesController NC)
    {
        //Intentionally does nothing
    }
}
