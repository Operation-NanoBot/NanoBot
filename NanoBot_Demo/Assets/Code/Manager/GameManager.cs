using UnityEngine;
using UnityEngine.SceneManagement;

public struct NanobotData
{
    public Vector3 Overworld_Dive_Position;
    public float Overworld_Dive_Rotation;
}

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

        //Set Starting Position for Nanobot Data
        this.nanobotData.Overworld_Dive_Position = this.OV_NB_StartingPos;
        this.nanobotData.Overworld_Dive_Rotation = this.OV_NB_StartingRot;
    }

    //Private Functions//

    //Functions to be Public

        //Level Change
    private void privLoadLevel(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }

    //Grabbing Current Player
    private NanobotData privGetData()
    {
        return this.nanobotData;
    }


    //Diving/Ascending
    private void privDive(NbTopdownController NB, int levelIndex)
    {
        //Save Data
        this.nanobotData.Overworld_Dive_Position = NB.transform.position;
        this.nanobotData.Overworld_Dive_Rotation = NB.transform.rotation.eulerAngles.z;

        //Load Level
        this.privLoadLevel(levelIndex);
    }

    private void privAscend(NbSidescrollController NB)
    {
        FactoryManager.EndLevel();
        this.privLoadLevel(2);
    }

    //Public Static Functions
    public static void LoadLevel(int index)
    {
        Instance.privLoadLevel(index);
    }

    public static NanobotData GetData()
    {
        return Instance.privGetData();
    }

    public static void Dive(NbTopdownController NB, int index)
    {
        Instance.privDive(NB, index);
    }

    public static void Ascend(NbSidescrollController NB)
    {
        Instance.privAscend(NB);
    }


    //Variables//

    //Instance
    private static GameManager Instance = null;

    //Nanobot Data
    private NanobotData nanobotData;

    //Starting Position and Rotation
    public Vector3 OV_NB_StartingPos = new Vector3(0.0f, 0.0f, 0.0f);
    public float OV_NB_StartingRot = 0.0f;
}
