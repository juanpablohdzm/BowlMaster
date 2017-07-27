using UnityEngine;

public class CameraController : MonoBehaviour {

    public Ball ball;
    public float HeadPinPos;
    private Vector3 DistanceCameraBall;

	// Use this for initialization
	void Start ()
    {
        DistanceCameraBall = transform.position - ball.transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
       
        if(ball.transform.position.z<=HeadPinPos)
            transform.position=ball.transform.position + DistanceCameraBall;
    }
}
