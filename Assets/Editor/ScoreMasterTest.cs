using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class ScoreMasterTest
{
    private List<int> pinFalls;
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
    private ActionMaster.Action reset = ActionMaster.Action.Reset;

    [SetUp]
    public void Setup()
    {
        pinFalls = new List<int>();
    }



    [Test]
    public void FailingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01FirstStrikeReturnsEndTurn()
    {
        pinFalls.Add(10);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T02Bowl8ReturnsTidy()
    {
        pinFalls.Add(8);
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T03SpareReturnsEndTurn()
    {
        pinFalls.Add(0);
        pinFalls.Add(1);
        Assert.AreEqual(endTurn, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T05CheckResetAtStrikeInLastFrame()
    {

        for (int i = 0; i < 18; i++)
        {
            pinFalls.Add(1);
        }
        pinFalls.Add(10);
        Assert.AreEqual(reset, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T06CheckResetSpareAtLastFrame()
    {
        for (int i = 0; i < 18; i++)
        {
            pinFalls.Add(1);
        }
        pinFalls.Add(1);
        pinFalls.Add(9);
        Assert.AreEqual(reset, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T07CheckEndGameAtLastFrame()
    {
        for (int i = 0; i < 18; i++)
        {
            pinFalls.Add(1);
        }
        pinFalls.Add(1);
        pinFalls.Add(7);
        Assert.AreEqual(ActionMaster.Action.EndGame, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T08GameEndsAtBowl20()
    {

        for (int i = 0; i < 20; i++)
        {
            pinFalls.Add(1);
        }
        Assert.AreEqual(ActionMaster.Action.EndGame, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T09Strike19ThenSpare()
    {

        for (int i = 0; i < 18; i++)
        {
            pinFalls.Add(1);
        }
        pinFalls.Add(10);
        pinFalls.Add(5);
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T10Extra()
    {

        for (int i = 0; i < 18; i++)
        {
            pinFalls.Add(1);
        }
        pinFalls.Add(10);
        pinFalls.Add(0);
        Assert.AreEqual(tidy, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T11Extra2()
    {

        for (int i = 0; i < 18; i++)
        {
            pinFalls.Add(1);
        }
        pinFalls.Add(10);
        Assert.AreEqual(reset, ActionMaster.NextAction(pinFalls));
    }

    [Test]
    public void T12LastThreeStrikes()
    {
        for (int i = 0; i < 18; i++)
        {
            pinFalls.Add(1);
        }
        pinFalls.Add(10);
        pinFalls.Add(10);
        pinFalls.Add(10);
        Assert.AreEqual(ActionMaster.Action.EndGame, ActionMaster.NextAction(pinFalls));
    }
}

   


