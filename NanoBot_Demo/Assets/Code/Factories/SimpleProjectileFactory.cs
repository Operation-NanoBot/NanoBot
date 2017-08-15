using UnityEngine;

public class SimpleProjectileFactory
{
    //Functions//

    //Constructor
    public SimpleProjectileFactory(GameObject Prefab)
    {
        //Initiation
        this.SimpleProjectilePrefab = Prefab;
        this.ActiveProjectileList = new System.Collections.Generic.List<ProjectileController>();
        this.InactiveProjectileStack = new System.Collections.Generic.Stack<ProjectileController>();
        
    }

    public void GetProjectile(Vector3 inPos, float inRot)
    {
        if(this.InactiveProjectileStack.Count == 0)
        {
            //Create New Instance
            this.PC = GameObject.Instantiate<GameObject>(this.SimpleProjectilePrefab).GetComponent<ProjectileController>();
        }
        else
        {
            //Grab from Inactive Stack
            this.PC = this.InactiveProjectileStack.Pop();
        }

        //Add to Active Stack
        this.ActiveProjectileList.Insert(0, this.PC);

        //Activate
        this.PC.gameObject.SetActive(true);

        //Initialize
        this.PC.Initialize(inPos, inRot);
    }

    public void Return(ProjectileController inPC)
    {
        //Deactivate GO
        inPC.gameObject.SetActive(false);

        //Remove from active list
        this.ActiveProjectileList.Remove(inPC);

        //Add to Inactive Stack
        this.InactiveProjectileStack.Push(inPC);
    }

    //Variables//

    //Stacks
    private System.Collections.Generic.List<ProjectileController> ActiveProjectileList;
    private System.Collections.Generic.Stack<ProjectileController> InactiveProjectileStack;

    //Prefab
    private GameObject SimpleProjectilePrefab;

    //Holders
    ProjectileController PC;

}