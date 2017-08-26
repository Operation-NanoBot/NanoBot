public class NB_SS_Direction_Left_State : NB_SS_Direction_State
{

    //Functions

    //Constructor
    public NB_SS_Direction_Left_State()
    {
        this.DirMult = -1.0f;
    }

    public override void Update(NbSidescrollController NB, ControllerStrategy Controller)
    {
        Controller.SideView_Update_Left_Direction(NB);
    }
}
