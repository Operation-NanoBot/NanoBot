public abstract class NB_SS_Direction_State
{
    //Functions//

    //Constructor
    protected NB_SS_Direction_State()
    {

    }

    public abstract void Update(NbSidescrollController NB, ControllerStrategy Controller);

    public float GetMult()
    {
        return this.DirMult;
    }

    //Variables//

    protected float DirMult;
}
