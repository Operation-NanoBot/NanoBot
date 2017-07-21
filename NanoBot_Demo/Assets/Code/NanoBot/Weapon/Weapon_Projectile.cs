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
        
    }

    //Overridden Functions
    public override void Fire(NanoBotController NC)
    {
        this.CreateProjectile(NC);
        NC.Cooldown();
    }

    public void CreateProjectile(NanoBotController NC)
    {
        GameObject GO = GameObject.Instantiate(NC.ProjectilePrefab, NC.GetMissilePosition(), Quaternion.identity);
        GO.GetComponent<ProjectileController>().RotateProjectile(NC.transform.eulerAngles.z);
        GO.GetComponent<ProjectileController>().DestructTimerStart();
    }

    

    //Variables//
    //private FireState fireState;
}
