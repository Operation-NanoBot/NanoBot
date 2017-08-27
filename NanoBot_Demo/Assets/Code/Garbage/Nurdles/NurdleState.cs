using UnityEngine;

public abstract class NurdleState
{
    //Functions//

    //Constructor
    public NurdleState()
    {

    }

    //Update
    public abstract void Update(NurdlesController NC);

    //Collision
    public abstract void TriggerEnter(Collider2D collision, NurdlesController NC);
    public abstract void TriggerExit(Collider2D collider, NurdlesController NC);

}
