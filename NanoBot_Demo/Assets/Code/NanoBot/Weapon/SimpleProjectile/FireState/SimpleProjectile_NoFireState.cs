

public class SimpleProjectile_NoFireState : SimpleProjectile_FireState
{
    //Functions//

    //Constructor
    public SimpleProjectile_NoFireState()
        : base()
    {

    }

    //Accept Functions
    public override void Accept(NbSidescrollController NB, Weapon_Projectile WP, NB_SS_Direction_State dirState)
    {
        //Intentionally does nothing
    }
}
