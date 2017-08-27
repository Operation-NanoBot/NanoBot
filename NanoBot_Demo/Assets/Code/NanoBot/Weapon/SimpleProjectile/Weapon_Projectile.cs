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
        this.fireState = canFire;

        this.CooldownTime = inTime;
    }

    //Overridden Functions
    public override void Fire(NbSidescrollController NC, NB_SS_Direction_State dirState)
    {
        this.fireState.Accept(NC, this, dirState);
    }

    //Weapon Functions
    public void ChangeToCooldown(NbSidescrollController NB)
    {
        this.fireState = noFire;
        NB.StartCoroutine(Cooldown());
        
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(CooldownTime);
        this.fireState = canFire;
    }

    //Variables//

    //Strategy
    private SimpleProjectile_FireState fireState;
    private static SimpleProjectile_CanFireState canFire = new SimpleProjectile_CanFireState();
    private static SimpleProjectile_NoFireState noFire = new SimpleProjectile_NoFireState();

    [SerializeField]
    private float CooldownTime;
}
