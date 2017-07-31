using UnityEngine;

public class OverworldManager
{
    //Functions//

    //Constructor
    public OverworldManager(Overworld_Location[] inArr)
    {
        //Zero out Nanobot Location
        this.Recent_NanoBot_Dive_Location = Vector3.zero;

        //Create Array
        this.Loc_Arr = new Overworld_Location[NUM_ROWS, NUM_COLS];

        //Grab Components
        this.Loc_Arr[0, 0] = inArr[0];
        this.Loc_Arr[0, 1] = inArr[1];
        this.Loc_Arr[1, 0] = inArr[2];
        this.Loc_Arr[1, 1] = inArr[3];
    }

    public void SwitchToSideScroll(Vector3 inPos)
    {
        //Store Dive Location
        this.Recent_NanoBot_Dive_Location = inPos;

        //Find Key
        int xPos = (int)((inPos.x + 80.0f) / 80.0f);
        int yPos = (int)((inPos.y + 80.0f) / 80.0f);

        //Load Corresponding Scene
        this.Loc_Arr[xPos, yPos].LoadScene();

        //Deactivate all areas
        this.SetLocationActivation(false);
    }

    public Vector3 SwitchToOverworld()
    {
        //Activate all Locations
        this.SetLocationActivation(true);

        //Return the Nanobot Location
        return this.Recent_NanoBot_Dive_Location;
    }

    //Private
    private void SetLocationActivation(bool inActive)
    {
        for (int row = 0; row < NUM_ROWS; ++row)
        {
            for (int col = 0; col < NUM_COLS; ++col)
            {
                this.Loc_Arr[row, col].SetActivation(inActive);
            }
        }
    }

    //Variables//

    //Constants
    private const int NUM_ROWS = 2;
    private const int NUM_COLS = 2;

    //Diving Locations
    private Overworld_Location[,] Loc_Arr;

    private Vector3 Recent_NanoBot_Dive_Location;
	
}
