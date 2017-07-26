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

        //Create NanoBot Player
        this.NanoBot_Player = Instantiate(NanoBot_Player, this.transform);
        this.NB = this.NanoBot_Player.GetComponent<NanoBotController>();

        //Create Camera and assign to follow NanoBot
        this.MainCam = GetComponentInChildren<Camera>();
        this.cameraFollow = this.MainCam.GetComponent<CameraFollow>();
        this.cameraFollow.AssignTarget(this.NanoBot_Player.transform);
    }

    //Private Functions//

    //Functions to be Public
    private void privSideScroll()
    {
        SceneManager.LoadScene(2);
        this.NB.SideView();
    }

    private void privTopDown()
    {
        SceneManager.LoadScene(1);
        this.NB.TopDown();
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

    //Variables//

    //Instance
    private static GameManager Instance = null;

    //GameObjects
    public GameObject NanoBot_Player;

    //NanoBot Controller
    private NanoBotController NB;

    //Camera
    private Camera MainCam;
    private CameraFollow cameraFollow;
}
