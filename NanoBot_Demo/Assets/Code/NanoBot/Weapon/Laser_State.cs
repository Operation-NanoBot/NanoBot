using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Laser_State
{
    public Laser_State()
    {

    }

    public abstract void FireLaser(NanoBotController NC, Weapon_Laser WL);
}
