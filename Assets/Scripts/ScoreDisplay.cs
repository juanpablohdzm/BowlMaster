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

    public static string FormatRolls(List<int> rolls)
    {
        string output = "";
        for (int i = 0; i < rolls.Count; i++)
        {
            int box = output.Length+1;
             if(rolls[i]==0)
             {
                output += "-";
             }
             else 
                 if((box%2==0 || box==21) && rolls[i - 1] + rolls[i] == 10)//Spare
                 {
                
                    output +="/";
                 }
                 else
                    if(i>=18 && rolls[i]==10) //Strike in last frame
                    {
                        output += "X";
                    }
                    else 
                        if(rolls[i]==10) //strike
                        {
                            output += "X ";
                        }
                        else 
                            if (rolls[i] < 10)
                                output += rolls[i];

        }
        return output;
    }
}
