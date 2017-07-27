using UnityEngine;

public class NurdlesFactory : MonoBehaviour
{
    //Functions//

    //GO Functions
    private void Awake()
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
    }

    //Functions to be public
    private void privCreateNurdle(Vector3 inPos)
    {
        if(this.InactiveNurdleStack.Count == 0)
        {
            //Create New Nurdle
            this.NurdleHolder = Instantiate<GameObject>(this.NurdlePrefab, inPos, Quaternion.identity);
        }
        else
        {
            //Grab From Inactive List
            this.NurdleHolder = this.InactiveNurdleStack.Pop();
            this.NurdleHolder.SetActive(true);
        }

        //Add to Active Stack
        this.ActiveNurdleStack.Push(this.NurdleHolder);

        //Set Force and Rotation
        this.NurdleHolder.GetComponent<NurdlesController>().InitializeNurdle();
    }

    //Public Static Functions
    public static void CreateNurdle(Vector3 inPos)
    {
        Instance.privCreateNurdle(inPos);
    }

    //Variables//

    //Instance
    private static NurdlesFactory Instance = null;
    
    //GameObjects
    public GameObject NurdlePrefab;
    private GameObject NurdleHolder;

    //List
    private System.Collections.Generic.Stack<GameObject> ActiveNurdleStack = new System.Collections.Generic.Stack<GameObject>();
    private System.Collections.Generic.Stack<GameObject> InactiveNurdleStack = new System.Collections.Generic.Stack<GameObject>();

    //NurdleController
    private NurdlesController NC;

}
