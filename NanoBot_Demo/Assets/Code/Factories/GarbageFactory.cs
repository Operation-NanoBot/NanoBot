using UnityEngine;

public class GarbageFactory
{
    //Functions//

    //Constructor
    public GarbageFactory(GameObject D_Prefab, GameObject I_Prefab)
    {
        //Initiation
        this.DestructibleGarbagePrefab = D_Prefab;
        this.IndestructibleGarbagePrefab = I_Prefab;

        this.ActiveGarbageList = new System.Collections.Generic.List<GarbageBase>();
        this.InactiveGarbageStack = new System.Collections.Generic.Stack<GarbageBase>();

    }

    public void GetDestructibleGarbage(Transform inParent, Vector3 inPos, float inRot)
    {
        if (this.InactiveGarbageStack.Count == 0)
        {
            //Create New Instance
            this.GB = GameObject.Instantiate<GameObject>(this.DestructibleGarbagePrefab, inParent).GetComponent<GarbageBase>();
        }
        else
        {
            //Grab from Inactive Stack
            this.GB = this.InactiveGarbageStack.Pop();
        }

        //Add to Active Stack
        this.ActiveGarbageList.Insert(0, this.GB);

        //Initialize
        this.GB.Initialize(inPos, inRot);
    }

    public void GetIndestructibleGarbage(Transform inParent, Vector3 inPos, float inRot)
    {
        if (this.InactiveGarbageStack.Count == 0)
        {
            //Create New Instance
            this.GB = GameObject.Instantiate<GameObject>(this.IndestructibleGarbagePrefab, inParent).GetComponent<GarbageBase>();
        }
        else
        {
            //Grab from Inactive Stack
            this.GB = this.InactiveGarbageStack.Pop();
        }

        //Add to Active Stack
        this.ActiveGarbageList.Insert(0, this.GB);

        //Activate
        this.GB.gameObject.SetActive(true);

        //Initialize
        this.GB.Initialize(inPos, inRot);
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

    public void DeactivateAll()
    {
        //Deactivate all active Items and move them to inactive list
        int NumItems = this.ActiveGarbageList.Count;
        for (int index = 0; index < NumItems; ++index)
        {
            this.ActiveGarbageList[index].gameObject.SetActive(false);
            this.InactiveGarbageStack.Push(this.ActiveGarbageList[index]);
        }

        //Clear Active List
        this.ActiveGarbageList.RemoveRange(0, NumItems);
    }

    //Variables//

    //Stacks
    private System.Collections.Generic.List<GarbageBase> ActiveGarbageList;
    private System.Collections.Generic.Stack<GarbageBase> InactiveGarbageStack;

    //Prefab
    private GameObject DestructibleGarbagePrefab;
    private GameObject IndestructibleGarbagePrefab;

    //Holders
    private GarbageBase GB;
}
