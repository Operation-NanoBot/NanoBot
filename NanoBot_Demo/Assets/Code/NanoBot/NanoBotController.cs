using UnityEngine;
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
        this.ThrustTransform = this.GetComponentsInChildren<Transform>()[1];

        //Set Physics Data
        this.RB.gravityScale = 0.0f;
    }

    //Weapon Functions
    //public void Fire_Weapon()
    //{
    //    this.weaponStrategy.Fire(this);
    //}

    //public void Firing()
    //{
    //    this.firingState = new Firing_On_State();
    //}

    //public void NotFiring()
    //{
    //    this.firingState = new Firing_Off_State();
    //}

    ////Get Functions
    //public Vector3 GetMissilePosition()
    //{
    //    return this.MissileTransform.position;
    //}


    //Variables//

    //Private//

    //Strategy
    protected ControllerStrategy controllerStrategy;

    //GO Components
    protected SpriteRenderer SR;
    protected Rigidbody2D RB;
    protected Transform ThrustTransform;

}
