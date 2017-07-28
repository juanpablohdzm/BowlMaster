using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

[TestFixture]
public class ScoreMasterTest
{
    private ActionMaster actionMaster;
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;

    [SetUp]
    public void Setup()
    {
        actionMaster = new ActionMaster();
    }
        
    

    [Test]
    public void FailingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01FirstStrikeReturnsEndTurn()
    {

        Assert.AreEqual(endTurn, actionMaster.Bowl(10));
    }

    [Test]
    public void T02Bowl8ReturnsTidy()
    {

        Assert.AreEqual(tidy, actionMaster.Bowl(8));
    }

    [Test]
    public void T03SpareReturnsEndTurn()
    {
        actionMaster.Bowl(2);
        Assert.AreEqual(endTurn, actionMaster.Bowl(8));
    }

    [Test]
    public void T05CheckResetAtStrikeInLastFrame()
    {
        
        for (int i = 0; i < 18; i++)
        {
            actionMaster.Bowl(1);
        }
        Assert.AreEqual(reset, actionMaster.Bowl(10));
    }

    [Test]
    public void T06CheckResetSpareAtLastFrame()
    {
        for (int i = 0; i < 18; i++)
        {
            actionMaster.Bowl(1);
        }
        actionMaster.Bowl(1);
        Assert.AreEqual(reset, actionMaster.Bowl(9));
    }

    [Test]
    public void T07CheckEndGameAtLastFrame()
    {
        for (int i = 0; i < 18; i++)
        {
            actionMaster.Bowl(1);
        }
         actionMaster.Bowl(1);
         actionMaster.Bowl(7);
        Assert.AreEqual(ActionMaster.Action.EndGame, actionMaster.Bowl(2));
    }

    [Test]
    public void T08GameEndsAtBowl20()
    {

        for (int i = 0; i < 19; i++)
        {
            actionMaster.Bowl(1);
        }
        Assert.AreEqual(ActionMaster.Action.EndGame, actionMaster.Bowl(1));
    }
}

   


