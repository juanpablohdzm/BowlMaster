using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMasterOld
{
    public enum Action { Tidy,Reset,EndTurn,EndGame};

    private int[] bowls = new int[21];
    private  int bowl = 1;

     private Action Bowl(int pins)
     {
        if (pins < 0 || pins > 10)
            throw new UnityException("Not valid pin number");

        bowls[bowl-1] = pins;
        if(bowl==20 && Bowl21Awarded())
        {
            bowl++;
            if (AllPinsKnockedDown() && bowls[19]!=0 )
                return Action.Reset;
            return Action.Tidy;
        }
               
        if (bowl==19 && Bowl21Awarded())
        {
            bowl++;
            return Action.Reset;
        }
        else 
            if(bowl==20 && !Bowl21Awarded())
            {
            return Action.EndGame;
            }

        if (bowl == 21)
            return Action.EndGame;

        if (pins == 10)
        {
            if (bowl % 2 == 0)
                bowl++;
            else
                bowl += 2;
            return Action.EndTurn;
            
        }

        if (bowl % 2 != 0)
        {
           
            bowl ++;
            return Action.Tidy;
                   
        }
        else 
            if(bowl % 2==0)
            {
                bowl++;
                return Action.EndTurn;
            }
        throw new UnityException("Need code");
     }
    private bool Bowl21Awarded()
    {
        return (bowls[18] + bowls[19] >= 10);
    }

    private bool AllPinsKnockedDown()
    {
        return ((bowls[18] + bowls[19])%10 == 0);
    }

    public static Action NextAction(List<int> pinFalls)
    {
        ActionMasterOld am = new ActionMasterOld();
        Action currentAction = new Action();
        foreach(int pinFall in pinFalls)
        {
            currentAction = am.Bowl(pinFall);
        }
        return currentAction;
    }
}
