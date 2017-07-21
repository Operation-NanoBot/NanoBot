using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FireState 
{
    public FireState()
    {

    }

    public abstract void Fire(NanoBotController NC, Weapon_Projectile WP);
}
