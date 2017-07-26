using UnityEngine;

public class TopDown_State : ViewState
{
    //Functions//
    public TopDown_State(ControllerStrategy CS, Sprite inSprite)
        :base(CS, inSprite)
    {

    }

    public override void ViewUpdate(NanoBotController NC)
    {
        this.controllerStrategy.TopDown_Update(NC);
    }
}

