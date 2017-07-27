using UnityEngine;

public class Ball : MonoBehaviour {

    public Vector3 InitialVelocity = new Vector3(0,0,100f);
    private Rigidbody rigidbody;
    private AudioSource audioSource;

    public bool InPlay = false;

	// Use this for initialization
	void Start ()
    {
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        rigidbody.useGravity = false;

	}

    public void Launch(Vector3 InitialVelocity)
    {
        InPlay = true;
        audioSource.Play();
        rigidbody.useGravity = true;
        rigidbody.velocity =  InitialVelocity;

    }
	
	// Update is called once per frame
	void Update ()
    {
      
	}
}
