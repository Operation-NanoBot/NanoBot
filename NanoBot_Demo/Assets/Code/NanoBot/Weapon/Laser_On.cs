using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_On : Laser_State
{

    public Laser_On()
    {

    }

    public override void FireLaser(NanoBotController NC, Weapon_Laser WL)
    {
        Debug.Log("Hello!");
        if(Input.GetKeyUp(KeyCode.Space))
        {
            WL.TurnLaserOff();
        }
    }
}
