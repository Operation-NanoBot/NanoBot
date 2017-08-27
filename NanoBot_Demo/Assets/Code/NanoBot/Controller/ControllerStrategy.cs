﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ControllerStrategy
{
    //Constructor
    public ControllerStrategy()
    {

    }

    //Abstract Functions
    public abstract void TopDown_Update(NbTopdownController pNB);


    public abstract void SideView_Update_Right_Direction(NbSidescrollController pNB);
    public abstract void SideView_Update_Left_Direction(NbSidescrollController pNB);
	
}
