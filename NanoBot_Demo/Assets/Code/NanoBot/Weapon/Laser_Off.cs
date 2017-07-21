using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Off : Laser_State
{
    public Laser_Off()
    {

    }

    public override void FireLaser(NanoBotController NC, Weapon_Laser WL)
    {
        WL.CreateLaser(NC);
    }
}
