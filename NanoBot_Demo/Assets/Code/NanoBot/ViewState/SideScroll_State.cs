using UnityEngine;

public class SideScroll_State : ViewState
{
    //Functions//

    //Constructor
    public SideScroll_State(ControllerStrategy CS, Sprite inSprite)
        :base(CS, inSprite)
    {

    }

    public override void ViewUpdate(NanoBotController NC)
    {
        this.controllerStrategy.SideView_Update(NC);
    }
}

