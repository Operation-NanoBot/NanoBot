using UnityEngine;

public class GarbageFactory
{
    //Functions//

    //Constructor
    public GarbageFactory(GameObject Prefab)
    {
        //Initiation
        this.GarbagePrefab = Prefab;
        this.ActiveGarbageList = new System.Collections.Generic.List<GarbageBase>();
        this.InactiveGarbageStack = new System.Collections.Generic.Stack<GarbageBase>();

    }

    public void GetProjectile(Vector3 inPos, float inRot)
    {
        if (this.InactiveGarbageStack.Count == 0)
        {
            //Create New Instance
            this.GB = GameObject.Instantiate<GameObject>(this.GarbagePrefab).GetComponent<GarbageBase>();
        }
        else
        {
            //Grab from Inactive Stack
            this.GB = this.InactiveGarbageStack.Pop();
        }

        //Add to Active Stack
        this.ActiveGarbageList.Insert(0, this.GB);

        //Initialize
        //this.GB.Initialize(inPos, inRot);
    }

    public void Return(GarbageBase inGB)
    {
        //Deactivate GO
        inGB.gameObject.SetActive(false);

        //Remove from active list
        this.ActiveGarbageList.Remove(inGB);

        //Add to Inactive Stack
        this.InactiveGarbageStack.Push(inGB);
    }

    //Variables//

    //Stacks
    private System.Collections.Generic.List<GarbageBase> ActiveGarbageList;
    private System.Collections.Generic.Stack<GarbageBase> InactiveGarbageStack;

    //Prefab
    private GameObject GarbagePrefab;

    //Holders
    private GarbageBase GB;
}
