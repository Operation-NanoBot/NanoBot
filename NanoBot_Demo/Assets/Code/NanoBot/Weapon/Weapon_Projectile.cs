using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Projectile : WeaponStrategy
{
    //Functions//

    //Constructor
    public Weapon_Projectile()
        :base()
    {
        this.fireState = new CanFire_State();
    }

    //Overridden Functions
    public override void Fire()
    {
        this.fireState.Fire_Projectile(this);
    }

    public void CreateProjectile()
    {
        ProjectileController PC = GameObject.Inst
    }

    //Variables//
    private FireState fireState;
}
