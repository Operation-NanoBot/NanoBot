using UnityEngine;

public class FactoryManager : MonoBehaviour
{
    void Awake()
    {
        if (Instance == null)
        {
            //Set Instance to this
            Instance = this;
        }
        else if (Instance != this)
        {
            //Destroy that instance so only one remains
            Destroy(gameObject);
            return;
        }

        //So this permeates through all Scenes
        DontDestroyOnLoad(gameObject);

        //Create Factories
        this.simpleProjectileFactory = new SimpleProjectileFactory(this.simpleProjectilePrefab);
    }

    //Private Functions to be public//

    //Creation
    private void privCreateSimpleProjectile(Vector3 inPos, float inRot)
    {
        this.simpleProjectileFactory.GetProjectile(inPos, inRot);
    }

    //Returns
    private void privReturnSimpleProjectile(ProjectileController inPC)
    {
        this.simpleProjectileFactory.Return(inPC);
    }

    //Static Public Functions
    public static void CreateSimpleProjectile(Vector3 inPos, float inRot)
    {
        Instance.privCreateSimpleProjectile(inPos, inRot);
    }

    public static void ReturnSimpleProjectile(ProjectileController inPC)
    {
        Instance.privReturnSimpleProjectile(inPC);
    }

    //Variables//

    //Instance
    private static FactoryManager Instance = null;

    //Prefabs
    public GameObject simpleProjectilePrefab;

    //Factories
    private SimpleProjectileFactory simpleProjectileFactory;
}
