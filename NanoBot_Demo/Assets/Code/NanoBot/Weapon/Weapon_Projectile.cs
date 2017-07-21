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
        this.fireState = new CanFire_State();

        this.CooldownTime = inTime;
    }

    //Overridden Functions
    public override void Fire(NanoBotController NC)
    {
        this.fireState.Fire(NC, this);
    }

    public void CreateProjectile(NanoBotController NC)
    {
        GameObject GO = GameObject.Instantiate(NC.ProjectilePrefab, NC.GetMissilePosition(), Quaternion.identity);
        GO.GetComponent<ProjectileController>().RotateProjectile(NC.transform.eulerAngles.z);
        GO.GetComponent<ProjectileController>().DestructTimerStart();

        //Change Fire State
        this.fireState = new NoFire_State();
        NC.StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(CooldownTime);
        this.fireState = new CanFire_State();
    }

    //Variables//
    private FireState fireState;
    [SerializeField]
    private float CooldownTime;
}
