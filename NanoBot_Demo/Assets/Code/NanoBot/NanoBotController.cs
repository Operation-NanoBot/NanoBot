﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class NanoBotController : MonoBehaviour
{
    //Functions//

    //Base Functions
    protected void Initialize()
    {
        //Set up Controller Type
        this.controllerStrategy = new KeyboardController();

        //Grab Necessary Components
        this.SR = this.GetComponent<SpriteRenderer>();
        this.RB = this.GetComponent<Rigidbody2D>();
    }

    //Private//

    //Strategy
    protected ControllerStrategy controllerStrategy;

    //GO Components
    protected SpriteRenderer SR;
    protected Rigidbody2D RB;
    protected Transform ThrustTransform;

}
