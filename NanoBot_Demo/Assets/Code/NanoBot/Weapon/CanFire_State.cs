using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanFire_State : FireState
{
    public CanFire_State(WeaponStrategy WS)
        :base(WS)
    {

    }

    public override void Fire(NanoBotController NC)
    {
        this.weaponStrategy.Fire(NC);
    }
}
