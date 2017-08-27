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
    public override void TopDown_Update(NbTopdownController pNB)
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

    public override void SideView_Update_Right_Direction(NbSidescrollController pNB)
    {
        this.CheckKeyPresses(pNB);

        if (Input.GetKey(KeyCode.D))
        {
            pNB.SV_MoveRight();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            pNB.ChangeToLeftState();
        }
    }

    public override void SideView_Update_Left_Direction(NbSidescrollController pNB)
    {
        this.CheckKeyPresses(pNB);

        if (Input.GetKey(KeyCode.A))
        {
            pNB.SV_MoveLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            pNB.ChangeToRightState();
        }
    }

    //Private Functions
    private void CheckKeyPresses(NbSidescrollController pNB)
    {
        if (Input.GetKey(KeyCode.W))
        {
            pNB.SV_MoveUp();
        }
        else if (Input.GetKey(KeyCode.S))
        {
            pNB.SV_MoveDown();
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            pNB.SV_Ascend();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            pNB.FireWeapon();
        }
    }
}
