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
    [UnityTest]
    public IEnumerator Susceptibility()
    {
        var SV = new SVRule(new List<IOpCode>
        {
            new Output(),
            new True(),
            new Suscept(),
            new MoveTowards(),
            new TwoFiveFive(),
            new SixtyFour()
        });
        var DataPacket = new SVDataPacket
        {
            NeuronOutput = 1,
            Susceptibility = 1
        };
        var Result = SV.Evaluate(DataPacket);
        Assert.AreEqual(65, Mathf.RoundToInt(Result));

        yield return null;
    }
}
