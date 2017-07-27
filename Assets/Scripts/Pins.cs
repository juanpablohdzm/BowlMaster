using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pins : MonoBehaviour {

    public float StandingThreshold=3f;

    public bool IsStanding()
    {
        Vector3 PinRotationEuler = transform.rotation.eulerAngles;
        float TiltInX = Mathf.Abs(PinRotationEuler.x);
        float TiltInZ = Mathf.Abs(PinRotationEuler.z);
        if(TiltInX>=StandingThreshold || TiltInZ>=StandingThreshold)
        return false;
        return true;
    }
}
