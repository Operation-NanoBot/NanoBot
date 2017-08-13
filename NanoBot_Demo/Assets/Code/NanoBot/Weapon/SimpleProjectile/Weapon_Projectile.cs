using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Projectile : WeaponStrategy
{
    //Functions//

    //Constructor
    public Weapon_Projectile(float inTime)
        :base()
    {
        //Set Fire State
        this.fireState = new SimpleProjectile_CanFireState();

        this.CooldownTime = inTime;
    }

    //Overridden Functions
    public override void Fire(NbSidescrollController NC)
    {
        this.fireState.FireProjectile(NC, this);
    }

    //Weapon Functions
    public void ChangeToCooldown(NbSidescrollController NB)
    {
        this.fireState = new SimpleProjectile_NoFireState();
        NB.StartCoroutine(Cooldown());
        
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(CooldownTime);
        this.fireState = new SimpleProjectile_CanFireState();
    }

    //Variables//

    //Strategy
    private SimpleProjectile_FireState fireState;

    [SerializeField]
    private float CooldownTime;
}
