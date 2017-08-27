

public class SimpleProjectile_CanFireState : SimpleProjectile_FireState
{
    //Functions//

    //Constructor
    public SimpleProjectile_CanFireState()
        : base()
    {

    }

    //Accept Functions
    public override void Accept(NbSidescrollController NB, Weapon_Projectile WP, NB_SS_Direction_State dirState)
    {
        dirState.VisitCanFire(NB, WP);
    }
}
