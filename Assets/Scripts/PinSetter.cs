using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
    private Pins[] PinArray;
    private int StandingPins;
    private bool BallEnteredBox=false;
    private float LastTimeChange;
    private Ball ball;

    public int LastStandingCount = -1;
    public Text PinCountDisplay;


	// Use this for initialization
	void Start () {
        StandingPins = 0;
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        PinCountDisplay.text = CountPinStanding().ToString();
        if (BallEnteredBox)
            CheckStanding();
           
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
        }
    }

    public void RenewPins()
    {

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
        ball.BallReset();
        BallEnteredBox = false;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Ball>())
        {
            BallEnteredBox = true;
            PinCountDisplay.color = Color.red;
        }
            //if (other.transform.parent.GetComponent<Pins>())
            //    StandingPins++;
        }
    private void OnTriggerExit(Collider other)
    {
        //if (other.transform.parent.GetComponent<Pins>())
        //    StandingPins--;
        if(other.transform.parent.GetComponent<Pins>())
        Destroy(other.transform.parent.gameObject);
    }
}
