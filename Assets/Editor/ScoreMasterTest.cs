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
}

   


