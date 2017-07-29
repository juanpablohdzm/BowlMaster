using UnityEngine;

public class Ball : MonoBehaviour {

    public Vector3 InitialVelocity = new Vector3(0,0,100f);
    private Vector3 InitialPosition;
    private Rigidbody rigidbody;
    private AudioSource audioSource;

    public bool InPlay = false;

	// Use this for initialization
	void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        rigidbody.useGravity = false;

        InitialPosition = transform.position;

	}

    public void Launch(Vector3 InitialVelocity)
    {
        InPlay = true;
        audioSource.Play();
        rigidbody.useGravity = true;
        rigidbody.velocity =  InitialVelocity;

    }
	
	public void BallReset()
    {
        InPlay = false;
        transform.position = InitialPosition;
        transform.rotation = new Quaternion(0, 0, 0,0);
        rigidbody.useGravity = false;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }
}
