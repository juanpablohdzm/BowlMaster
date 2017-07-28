using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

[TestFixture]
public class ScoreMasterTest
{
    private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
    [Test]
    public void FailingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01FirstStrikeReturnsEndTurn()
    {
        ActionMaster actionMaster = new ActionMaster();
        Assert.AreEqual(endTurn,actionMaster.Bowl(10));
    }

}
