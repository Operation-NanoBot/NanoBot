using UnityEngine;

public class NurdlesFactory
{
    //Functions//

    //Constructor
    public NurdlesFactory(GameObject Prefab)
    {
        //Initiation
        this.NurdlesPrefab = Prefab;
        this.ActiveNurdleList = new System.Collections.Generic.List<NurdlesController>();
        this.InactiveNurdleStack = new System.Collections.Generic.Stack<NurdlesController>();

    }

    public void GetNurdle(Vector3 inPos)
    {
        if (this.InactiveNurdleStack.Count == 0)
        {
            //Create New Instance
            this.NC = GameObject.Instantiate<GameObject>(this.NurdlesPrefab).GetComponent<NurdlesController>();
        }
        else
        {
            //Grab from Inactive Stack
            this.NC = this.InactiveNurdleStack.Pop();
        }

        //Add to Active Stack
        this.ActiveNurdleList.Insert(0, this.NC);

        //Activate
        this.NC.gameObject.SetActive(true);

        //Initialize
        this.NC.InitializeNurdle(inPos);
    }

    public void Return(NurdlesController inNC)
    {
        //Deactivate GO
        inNC.gameObject.SetActive(false);

        //Remove from active list
        this.ActiveNurdleList.Remove(inNC);

        //Add to Inactive Stack
        this.InactiveNurdleStack.Push(inNC);
    }

    //Variables//

    //Stacks
    private System.Collections.Generic.List<NurdlesController> ActiveNurdleList;
    private System.Collections.Generic.Stack<NurdlesController> InactiveNurdleStack;

    //Prefab
    private GameObject NurdlesPrefab;

    //Holders
    NurdlesController NC;

}
