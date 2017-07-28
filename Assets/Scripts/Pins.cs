using UnityEngine;

public class Pins : MonoBehaviour {

    public float StandingThreshold=3f;
    public float DistanceToRaisePins = 60f;

    public bool IsStanding()
    {
        Vector3 PinRotationEuler = transform.rotation.eulerAngles;
        float TiltInX = Mathf.Abs(PinRotationEuler.x);
        float TiltInZ = Mathf.Abs(PinRotationEuler.z);

        if ((TiltInX > StandingThreshold && TiltInX<360-StandingThreshold) || (TiltInZ > StandingThreshold && TiltInX < 360 - StandingThreshold))
        {
            return false;
        }
        return true;
    }

    public void Raise()
    {
           
                transform.Translate(new Vector3(0, DistanceToRaisePins, 0), Space.World);
                transform.GetComponent<Rigidbody>().useGravity = false;
           
        
    }

    public void Lower()
    {

            transform.Translate(new Vector3(0, -DistanceToRaisePins, 0), Space.World);
            transform.GetComponent<Rigidbody>().useGravity = true;
        
    }

}
