using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PinCounter : MonoBehaviour
{
    private int StandingPins;
    private float LastTimeChange;
    private int LastSettleCount = 10;
    private Pins[] PinArray;
    private bool BallOutOfPlay = false;
    private GameManager gameManager;

    public int LastStandingCount = -1; 
    public Text PinCountDisplay;
    // Use this for initialization
    void Start()
    {
        StandingPins = 0;
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        PinCountDisplay.text = CountPinStanding().ToString();
        if (BallOutOfPlay)
        {
            PinCountDisplay.color = Color.red;
            CheckStanding();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Ball>())
        {
            BallOutOfPlay = true;
        }
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

    void PinsHaveSettled()
    {
        int countstanding = CountPinStanding();
        int PinFallen = LastSettleCount - countstanding;
        LastSettleCount = countstanding;
        gameManager.Bowl(PinFallen);
        BallOutOfPlay = false;
        LastStandingCount = -1;
        PinCountDisplay.color = Color.green;
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
        if ((Time.time - LastTimeChange) > settleTime)
        {
            PinsHaveSettled();
        }
    }

    public void LastSettleCountReset()
    {
        LastSettleCount = 10;
    }
}
