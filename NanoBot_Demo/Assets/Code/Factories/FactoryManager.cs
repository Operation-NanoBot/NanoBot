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
        this.garbageFactory = new GarbageFactory(this.destructibleGarbagePrefab, this.indestructibleGarbagePrefab);
        this.nurdlesFactory = new NurdlesFactory(this.NurdlePrefab);

    }

    //Private Functions to be public//

    //Simple Projectile
    private void privCreateSimpleProjectile(Vector3 inPos, float inRot)
    {
        this.simpleProjectileFactory.GetProjectile(inPos, inRot);
    }

    private void privReturnSimpleProjectile(ProjectileController inPC)
    {
        this.simpleProjectileFactory.Return(inPC);
    }

    //Garbage
    private void privCreateDestructibleGarbage(Transform inParent, Vector3 inPos, float inRot)
    {
        this.garbageFactory.GetDestructibleGarbage(inParent, inPos, inRot);
    }

    private void privCreateIndestructibleGarbage(Transform inParent, Vector3 inPos, float inRot)
    {
        this.garbageFactory.GetIndestructibleGarbage(inParent, inPos, inRot);
    }

    private void privReturnGarbage(GarbageBase inGB)
    {
        this.garbageFactory.Return(inGB);
    }

    //Nurdle
    private void privCreateNurdle(Vector3 inPos)
    {
        this.nurdlesFactory.GetNurdle(inPos);
    }

    private void privReturnNurdle(NurdlesController NC)
    {
        this.nurdlesFactory.Return(NC);
    }

    //Static Public Functions
    //Projectile
    public static void CreateSimpleProjectile(Vector3 inPos, float inRot)
    {
        Instance.privCreateSimpleProjectile(inPos, inRot);
    }

    public static void ReturnSimpleProjectile(ProjectileController inPC)
    {
        Instance.privReturnSimpleProjectile(inPC);
    }

    //Garbage
    public static void CreateDestructibleGarbage(Transform inParent, Vector3 inPos, float inRot)
    {
        Instance.privCreateDestructibleGarbage(inParent, inPos, inRot);
    }

    public static void CreateIndestructibleGarbage(Transform inParent, Vector3 inPos, float inRot)
    {
        Instance.privCreateIndestructibleGarbage(inParent, inPos, inRot);
    }

    public static void ReturnGarbage(GarbageBase inGB)
    {
        Instance.privReturnGarbage(inGB);
    }

    //Nurdles
    public static void CreateNurdle(Vector3 inPos)
    {
        Instance.privCreateNurdle(inPos);
    }

    public static void ReturnNurdle(NurdlesController NC)
    {
        Instance.privReturnNurdle(NC);
    }

    //Variables//

    //Instance
    private static FactoryManager Instance = null;

    //Prefabs
    public GameObject simpleProjectilePrefab;
    public GameObject destructibleGarbagePrefab;
    public GameObject indestructibleGarbagePrefab;
    public GameObject NurdlePrefab;

    //Factories
    private SimpleProjectileFactory simpleProjectileFactory;
    private GarbageFactory garbageFactory;
    private NurdlesFactory nurdlesFactory;
}
