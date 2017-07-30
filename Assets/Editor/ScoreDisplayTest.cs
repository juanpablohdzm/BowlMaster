using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq;

[TestFixture]
public class ScoreDisplayTest
{

    [Test]
    public void T00PassingTest()
    {
        Assert.AreEqual(1, 1);
    }

    [Test]
    public void T01Bowl1()
    {
        int[] rolls = { 1 };
        string rollstring = "1";
        Assert.AreEqual(rollstring, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T02Bowl1234()
    {
        int[] rolls = { 1,2,3,4 };
        string rollstring = "1234";
        Assert.AreEqual(rollstring, ScoreDisplay.FormatRolls(rolls.ToList()));
    }
    [Test]
    public void T03BowlX()
    {
        int[] rolls = { 10 };
        string rollstring = "X ";
        Assert.AreEqual(rollstring, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

    [Test]
    public void T04BowlSpare()
    {
        int[] rolls = { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,10,10,1 };
        string rollstring = "111111111111111111XX1";
        Assert.AreEqual(rollstring, ScoreDisplay.FormatRolls(rolls.ToList()));
    }

}
