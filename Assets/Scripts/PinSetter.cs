using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
    private Pins[] PinArray;
    private int StandingPins;
    public Text PinCountDisplay;
	// Use this for initialization
	void Start () {
        StandingPins = 0;
	}
	
	// Update is called once per frame
	void Update () {
        PinCountDisplay.text = StandingPins.ToString();
	}

    //public int CountPinStanding(Collider other)
    //{
    //    //PinArray = GameObject.FindObjectsOfType<Pins>();
    //    //int StandingPins=0;
    //    //for (int i = 0; i < PinArray.Length; i++)
    //    //{
    //    //    if (PinArray[i].IsStanding())
    //    //        StandingPins++;
    //    //}
    //    //return StandingPins;
    //}

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.transform.parent.GetComponent<Pins>())
            StandingPins++;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.parent.GetComponent<Pins>())
            StandingPins--;
    }
}
