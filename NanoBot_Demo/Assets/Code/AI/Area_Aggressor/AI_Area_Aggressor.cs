using UnityEngine;

public class AI_Area_Aggressor : AI_Base
{
    //Functions//

    //GO Functions
    private void Awake()
    {
        //Initialize
        base.Initialize();


        //Create States
        this.detectState = new AreaAggression_DetectState();
        this.chaseState = new AreaAggression_ChaseState();

        //Set Default State
        this.mainState = this.detectState;

        //Grab Components
        this.RB = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        this.mainState.Update(this);
    }

    private void FixedUpdate()
    {
        this.mainState.FixedUpdate(this);
    }

    //State Changes
    public void DetectState()
    {
        this.mainState = this.detectState;
    }

    public void ChaseState()
    {
        this.mainState = this.chaseState;
    }

    //State Functions
    public void DetectPlayer()
    {
        this.Distance2Player = this.Target.position - this.transform.position;
    }

    public bool PlayerDetected()
    {
        return (this.Distance2Player.sqrMagnitude < (this.Aggression_Distance * this.Aggression_Distance));
    }

    public void ChasePlayer()
    {
        this.RB.AddForce(this.Distance2Player * this.ForceFactor);
    }

    //Variables//

    //Components
    private Rigidbody2D RB;

    //States
    private AreaAggressionState mainState;
    private AreaAggression_DetectState detectState;
    private AreaAggression_ChaseState chaseState;

    //Radius of Aggression
    [SerializeField]
    private float Aggression_Distance = 4.0f;

    //Distance to Player
    private Vector3 Distance2Player;

    //Speed
    [SerializeField]
    private float ForceFactor = 5.0f;
}
