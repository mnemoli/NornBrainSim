using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using OpCode;

public class SVRuleTest
{
    [UnityTest]
    public IEnumerator BasicTest()
    {
        var SV = new SVRule(new List<IOpCode> { new ThirtyTwo(), new Plus(), new Zero() });
        Assert.AreEqual(32, SV.Evaluate(new SVDataPacket()));

        yield return null;
    }
    [UnityTest]
    public IEnumerator MixedOperandLengths()
    {
        var SV = new SVRule(new List<IOpCode> { new ThirtyTwo(), new Decr(), new Plus(), new Zero() });
        Assert.AreEqual(31, SV.Evaluate(new SVDataPacket()));

        yield return null;
    }
}
