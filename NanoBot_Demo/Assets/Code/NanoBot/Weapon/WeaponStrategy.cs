using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponStrategy
{
    public WeaponStrategy()
    {

    }

    public abstract void Fire(NanoBotController NC);
	
}
