﻿using System;

public class NB_SS_Direction_Right_State : NB_SS_Direction_State
{
    //Functions

    //Constructor
    public NB_SS_Direction_Right_State()
    {
        this.DirMult = 1.0f;
    }

    public override void Update(NbSidescrollController NB, ControllerStrategy Controller)
    {
        Controller.SideView_Update_Right_Direction(NB);
    }
}
