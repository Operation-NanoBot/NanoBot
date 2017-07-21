using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FireState 
{
    public FireState()
    {

    }

    public FireState(WeaponStrategy WS)
    {
        this.weaponStrategy = WS;
    }

    public abstract void Fire(NanoBotController NC);

    protected WeaponStrategy weaponStrategy;
}
