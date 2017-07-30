using UnityEngine;
using UnityEngine.UI;

public class PinSetter : MonoBehaviour {
    private Pins[] PinArray;
    private Animator animator;
    private PinCounter pinCounter;
   
    public GameObject pinSet;
   
	// Use this for initialization
	void Start ()
    {
        pinCounter = GameObject.FindObjectOfType<PinCounter>();
        animator = GetComponent<Animator>();

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
       GameObject Lane= Instantiate(pinSet, new Vector3(0, 80, 1829), Quaternion.identity);
        Rigidbody[] childs = Lane.GetComponentsInChildren<Rigidbody>();
        for (int i = 0; i < childs.Length; i++)
        {
            childs[i].useGravity = false;
        }
     
    }


    private void OnTriggerExit(Collider other)
    {
        if(other.transform.parent.GetComponent<Pins>())
        Destroy(other.transform.parent.gameObject);
    }

    public void Animation(ActionMaster.Action action)
    {
        if (ActionMaster.Action.EndTurn == action || ActionMaster.Action.Reset == action)
        {
            animator.SetTrigger("ResetTrigger");
            pinCounter.LastSettleCountReset();
        }
        else
            animator.SetTrigger("TidyTrigger");
    }
}
