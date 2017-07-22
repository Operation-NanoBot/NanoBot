

using System;

public class Firing_On_State : FiringState
{
    public Firing_On_State()
        :base()
    {

    }

    public override void Update(NanoBotController NC)
    {
        NC.Fire_Weapon();
    }
}

