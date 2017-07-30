using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {
    public Text[] Scores;
    public Text[] Rolls;
	
    public void FillRollCard(List<int> rolls)
    {
        string ScoreString = FormatRolls(rolls);
        for (int i = 0; i < ScoreString.Length; i++)
        {
            Rolls[i].text =ScoreString[i].ToString();
            
        }
    }

    public void FillScores(List<int> scores)
    {
        for (int i = 0; i <scores.Count; i++)
        {
            Scores[i].text = scores[i].ToString();

        }
    }

    private static string FormatRolls(List<int> rolls)
    {
        string output = "";

        return output;
    }
}
