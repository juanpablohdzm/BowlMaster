using UnityEngine;

[RequireComponent(typeof(Ball))]
public class DragLaunch : MonoBehaviour {
    private Ball ball;
    private Vector3 StartPos,FinishPos;
    private float StartTime, FinishTime;
	// Use this for initialization
	void Start () {
        ball = GetComponent<Ball>();
	}

    //Capture time and position of drag start
    public void OnDragStart()
    {
       StartPos= Input.mousePosition;
        StartTime = Time.time;
    }

    //Launch ball
    public void OnDragEnd()
    {
        if (!ball.InPlay)
        {
            FinishPos = Input.mousePosition;
            FinishTime = Time.time;
            float DragDuration = -StartTime + FinishTime;
            float SpeedX = (-StartPos.x + FinishPos.x) / DragDuration;
            float SpeedZ = (FinishPos.y - StartPos.y) / DragDuration;

            ball.Launch(new Vector3(SpeedX, 0, SpeedZ));
        }
    }
    public void MoveStart(float xNudge)
    {
        if (!ball.InPlay)
        {
            float Zpos = ball.transform.position.z;
            float Ypos = ball.transform.position.y;
            float Xpos =Mathf.Clamp( ball.transform.position.x+xNudge,-50f,50);

            ball.transform.position = new Vector3(Xpos, Ypos, Zpos);
            
        }
       
    }
    
}
