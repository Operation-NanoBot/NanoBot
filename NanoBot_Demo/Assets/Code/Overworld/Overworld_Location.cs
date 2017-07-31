using UnityEngine;
using UnityEngine.SceneManagement;

public class Overworld_Location : MonoBehaviour
{
    //Functions//

    //Public
    public void LoadScene()
    {
        SceneManager.LoadScene(this.sideScroll_Level_Index);
    }

    public void SetActivation(bool inActive)
    {
        this.gameObject.SetActive(inActive);
    }

    //Variables//

    //Public
    public int sideScroll_Level_Index;
}
