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

        //Grab Holders
        for(int index = 0; index < NUM_HOLDERS; ++index)
        {
            this.HolderArr[index] = GetComponentsInChildren<Transform>()[index + 1];
        }

        //Create Factories
        this.simpleProjectileFactory = new SimpleProjectileFactory(this.simpleProjectilePrefab);
        this.garbageFactory = new GarbageFactory(this.destructibleGarbagePrefab, this.indestructibleGarbagePrefab);
        this.nurdlesFactory = new NurdlesFactory(this.NurdlePrefab);

    }

    //Private Functions to be public//

    //Simple Projectile
    private void privCreateSimpleProjectile(Vector3 inPos, float inRot)
    {
        this.simpleProjectileFactory.GetProjectile(this.HolderArr[0], inPos, inRot);
    }

    private void privReturnSimpleProjectile(ProjectileController inPC)
    {
        this.simpleProjectileFactory.Return(inPC);
    }

    //Garbage
    private void privCreateDestructibleGarbage(Vector3 inPos, float inRot)
    {
        this.garbageFactory.GetDestructibleGarbage(this.HolderArr[1], inPos, inRot);
    }

    private void privCreateIndestructibleGarbage(Vector3 inPos, float inRot)
    {
        this.garbageFactory.GetIndestructibleGarbage(this.HolderArr[1], inPos, inRot);
    }

    private void privReturnGarbage(GarbageBase inGB)
    {
        this.garbageFactory.Return(inGB);
    }

    //Nurdle
    private void privCreateNurdle(Vector3 inPos)
    {
        this.nurdlesFactory.GetNurdle(this.HolderArr[2], inPos);
    }

    private void privReturnNurdle(NurdlesController NC)
    {
        this.nurdlesFactory.Return(NC);
    }

    //End Level
    private void privEndLevel()
    {
        this.simpleProjectileFactory.DeactivateAll();
        this.garbageFactory.DeactivateAll();
        this.nurdlesFactory.DeactivateAll();
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
    public static void CreateDestructibleGarbage(Vector3 inPos, float inRot)
    {
        Instance.privCreateDestructibleGarbage(inPos, inRot);
    }

    public static void CreateIndestructibleGarbage(Vector3 inPos, float inRot)
    {
        Instance.privCreateIndestructibleGarbage(inPos, inRot);
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

    public static void EndLevel()
    {
        Instance.privEndLevel();
    }

    //Variables//

    //Instance
    private static FactoryManager Instance = null;

    //Holder
    private const int NUM_HOLDERS = 3;
    private Transform[] HolderArr = new Transform[NUM_HOLDERS];

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
