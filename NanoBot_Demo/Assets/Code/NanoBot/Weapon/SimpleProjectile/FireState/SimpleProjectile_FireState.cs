

public abstract class SimpleProjectile_FireState
{
    //Functions//

    //Constructor
    public SimpleProjectile_FireState()
    {

    }

    //Abstract Function
    //public abstract void FireProjectile(NbSidescrollController NB, Weapon_Projectile WP);

    //Accept Functions
    public abstract void Accept(NbSidescrollController NB, Weapon_Projectile WP, NB_SS_Direction_State dirState);
}
