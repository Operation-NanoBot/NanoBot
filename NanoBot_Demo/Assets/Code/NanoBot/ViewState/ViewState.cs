using UnityEngine;

public abstract class ViewState
{
    //Functions//

    //Constructor
    public ViewState(ControllerStrategy CS, Sprite inSprite)
    {
        this.controllerStrategy = CS;
        this.MainSprite = inSprite;
    }

    //Abstract Function
    public abstract void ViewUpdate(NanoBotController NC);

    //Virtual Functions
    public Sprite GetSprite()
    {
        return this.MainSprite;
    }

    //Variables//

    //Protected
    protected ControllerStrategy controllerStrategy;

    protected Sprite MainSprite;
}

