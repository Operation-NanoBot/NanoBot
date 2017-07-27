using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : ControllerStrategy
{
    //Constuctor
    public KeyboardController()
        :base()
    {

    }

    //Overidden Functions
    public override void TopDown_Update(NanoBotController pNB)
    {
        if(Input.GetKey(KeyCode.W))
        {
            pNB.TD_MoveForward();
        }
        else if(Input.GetKey(KeyCode.S))
        {
            pNB.TD_MoveBackward();
        }

        if(Input.GetKey(KeyCode.D))
        {
            pNB.TD_RotateCW();
        }
        else if(Input.GetKey(KeyCode.A))
        {
            pNB.TD_RotateCCW();
        }

        if(Input.GetKeyUp(KeyCode.Q))
        {
            pNB.TD_Dive();
        }
    }

    public override void SideView_Update(NanoBotController pNB)
    {
        if (Input.GetKey(KeyCode.W))
        {
            pNB.SV_MoveForward();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            pNB.SV_MoveBackward();
        }

        if (Input.GetKey(KeyCode.D))
        {
            pNB.SV_RotateCW();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            pNB.SV_RotateCCW();
        }

        if(Input.GetKeyUp(KeyCode.E))
        {
            pNB.SV_Ascend();
        }

        if(Input.GetKey(KeyCode.Space))
        {
            pNB.Fire_Weapon();
        }
    }
}
