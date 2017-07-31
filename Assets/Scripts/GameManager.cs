using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private List<int> rolls = new List<int>();
    private PinSetter pinSetter;
    private Ball ball;
    private ScoreDisplay scoreDisplay;
    public LevelManager levelManager;
	// Use this for initialization
	void Start () {
        pinSetter = GameObject.FindObjectOfType<PinSetter>();
        ball= GameObject.FindObjectOfType<Ball>();
        scoreDisplay = GameObject.FindObjectOfType<ScoreDisplay>();

    }
	
	public void Bowl(int pinFall)
    {
        rolls.Add(pinFall);
        ActionMaster.Action nextAction = ActionMaster.NextAction(rolls);
        if (nextAction == ActionMaster.Action.EndGame)
            levelManager.LoadNextLevel();
        pinSetter.Animation(nextAction);
        scoreDisplay.FillRollCard(rolls);
        scoreDisplay.FillScores(ScoreMaster.ScoreCumulative(rolls));
        ball.BallReset();
    }
}
