using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FireState 
{
    public FireState()
    {

    }

    public abstract void Fire_Projectile(Weapon_Projectile WP);
}
