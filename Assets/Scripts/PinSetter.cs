using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
    private Pins[] PinArray;
    private int StandingPins;
    private float LastTimeChange;
    private Ball ball;
    private int LastSettleCount=10;
    private ActionMaster actionMaster=new ActionMaster();
    private Animator animator;

    public bool BallOutOfPlay = false;
    public int LastStandingCount = -1;
    public Text PinCountDisplay;
    public GameObject pinSet;
   


	// Use this for initialization
	void Start () {
        StandingPins = 0;
        ball = GameObject.FindObjectOfType<Ball>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        PinCountDisplay.text = CountPinStanding().ToString();
        if (BallOutOfPlay)
        {
            PinCountDisplay.color = Color.red;
            CheckStanding();
            
        }
	}

    private void PinsFallen()
    {
        actionMaster.Bowl(10 - CountPinStanding());
    }

    public void RaisePins()
    {
        PinArray = GameObject.FindObjectsOfType<Pins>();
        for (int i = 0; i < PinArray.Length; i++)
        {
            if (PinArray[i].IsStanding())
            {
                PinArray[i].Raise();
                
            }
        }
    }

    public void LowerPins()
    {
        PinArray = GameObject.FindObjectsOfType<Pins>();
        for (int i = 0; i < PinArray.Length; i++)
        {
            PinArray[i].Lower();
            PinArray[i].transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    public void RenewPins()
    {
       GameObject Lane= Instantiate(pinSet, new Vector3(0, 80, 1829), Quaternion.identity);
        Rigidbody[] childs = Lane.GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].useGravity = false;
        }
     
    }

    void CheckStanding()
    {
        int CurrentStanding = CountPinStanding();
        if (CurrentStanding != LastStandingCount)
        {
            LastTimeChange = Time.time;
            LastStandingCount = CurrentStanding;
            return;
        }

        float settleTime = 3f; //Time to consider pins settled
        if((Time.time-LastTimeChange)>settleTime)
        {
            PinsHaveSettled();
        }
    }

    void PinsHaveSettled()
    {
        int countstanding = CountPinStanding();
        int PinFallen = LastSettleCount - countstanding;
        LastSettleCount = countstanding;
        Animation(actionMaster.Bowl(PinFallen));
        ball.BallReset();
        BallOutOfPlay = false;
        LastStandingCount = -1;
        PinCountDisplay.color = Color.green;
    }

    public int CountPinStanding()
    {
        PinArray = GameObject.FindObjectsOfType<Pins>();
        int StandingPins = 0;
        for (int i = 0; i < PinArray.Length; i++)
        {
            if (PinArray[i].IsStanding())
                StandingPins++;

        }
        return StandingPins;
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.transform.parent.GetComponent<Pins>())
        //    StandingPins--;
        if(other.transform.parent.GetComponent<Pins>())
        Destroy(other.transform.parent.gameObject);
    }

    private void Animation(ActionMaster.Action action)
    {
        if (ActionMaster.Action.EndTurn == action || ActionMaster.Action.Reset == action)
        {
            animator.SetTrigger("ResetTrigger");
            LastSettleCount = 10;
        }
        else
            animator.SetTrigger("TidyTrigger");
    }
}
