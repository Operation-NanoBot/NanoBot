

public class SimpleProjectile_CanFireState : SimpleProjectile_FireState
{
    //Functions//

    //Constructor
    public SimpleProjectile_CanFireState()
        :base()
    {

    }

    //Override
    public override void FireProjectile(NbSidescrollController NB, Weapon_Projectile WP)
    {
        FactoryManager.CreateSimpleProjectile(NB.GetMissilePosition(), NB.transform.rotation.eulerAngles.z);
        WP.ChangeToCooldown(NB);
    }
}
