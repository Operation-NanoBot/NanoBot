public abstract class NB_SS_Direction_State
{
    //Functions//

    //Constructor
    protected NB_SS_Direction_State()
    {

    }

    public abstract void Update(NbSidescrollController NB, ControllerStrategy Controller);

    //Visitor Pattern Functions//

    //Fire State
    public void VisitCanFire(NbSidescrollController NB, Weapon_Projectile WP)
    {
        FactoryManager.CreateSimpleProjectile(NB.GetNosePosition(), this.MissileRot);
        WP.ChangeToCooldown(NB);
    }

    //Variables//

    //Protected
    protected float MissileRot;


}
