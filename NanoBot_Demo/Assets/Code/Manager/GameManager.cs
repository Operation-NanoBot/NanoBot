using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Functions//

    //GO Functions
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

        //Grab NanoBot Player
        this.NC = GetComponentInChildren<NanoBotController>();
        this.NanoBot_Player = this.NC.gameObject;
        this.NC.InitializePlayer();

        //Grab Camera and assign to follow NanoBot
        this.MainCam = GetComponentInChildren<Camera>();
        this.cameraFollow = this.MainCam.GetComponent<CameraFollow>();
        this.cameraFollow.AssignTarget(this.NanoBot_Player.transform);

        if(isOverworld)
        {
            this.NC.TopDown();
        }
        else
        {
            this.NC.SideView();
        }
    }

    //Private Functions//

    //Functions to be Public
    private void privSideScroll()
    {
        SceneManager.LoadScene(2);
        this.NC.SideView();
    }

    private void privTopDown()
    {
        SceneManager.LoadScene(1);
        this.NC.TopDown();
    }

    private GameObject privGetPlayer()
    {
        return this.NanoBot_Player;
    }

    //Public Static Functions
    public static void SideScroll()
    {
        Instance.privSideScroll();
    }

    public static void TopDown()
    {
        Instance.privTopDown();
    }

    public static GameObject GetPlayer()
    {
        return Instance.privGetPlayer();
    }


    //Variables//

    //Instance
    private static GameManager Instance = null;

    //GameObjects
    private GameObject NanoBot_Player;

    //NanoBot Controller
    private NanoBotController NC;

    //Camera
    private Camera MainCam;
    private CameraFollow cameraFollow;

    //Overworld vs SideScroll
    public bool isOverworld = true;
}
