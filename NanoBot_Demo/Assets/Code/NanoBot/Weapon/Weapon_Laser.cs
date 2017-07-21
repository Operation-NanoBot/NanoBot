using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Laser : WeaponStrategy
{
    //Functions//

    //Constructor
    public Weapon_Laser()
    {
        this.laserState = new Laser_Off();
    }

    public override void Fire(NanoBotController NC)
    {
        this.laserState.FireLaser(NC, this);
    }

    public void CreateLaser(NanoBotController NC)
    {
        this.LaserGO = GameObject.Instantiate(NC.LaserPrefab, NC.GetMissilePosition(), Quaternion.identity);

        //Change State
        this.laserState = new Laser_On();
    }

    //Turn off Laser
    public void TurnLaserOff()
    {
        this.laserState = new Laser_Off();
        GameObject.Destroy(LaserGO);
    }

    //Variables
    private Laser_State laserState;
    private GameObject LaserGO;
}
