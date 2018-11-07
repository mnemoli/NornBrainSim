using NUnit.Framework;
using System.Collections;
using UnityEngine.TestTools;

public class SVRuleBuildTest
{
    [UnityTest]
    public IEnumerator Interpret()
    {
        RawGene gene = new RawGene(new byte[] { 0x23, 0x31, 0x22});
        var SVRule = SVRuleInterpreter.Interpret(gene);
        Assert.AreEqual((OpCodeType)0x23, SVRule.OpCodes[0]);
        Assert.AreEqual((OpCodeType)0x31, SVRule.OpCodes[1]);
        Assert.AreEqual((OpCodeType)0x22, SVRule.OpCodes[2]);

        yield return null;
    }

    [UnityTest]
    public IEnumerator Build()
    {
        RawGene gene = new RawGene(new byte[] { 1, 22, 31 });
        var SVRuleGene = SVRuleInterpreter.Interpret(gene);
        var SVRule = SVRuleBuilder.Build(SVRuleGene);
        Assert.IsInstanceOf(typeof(Zero), SVRule.OpCodes[0]);
        Assert.IsInstanceOf(typeof(ThirtyTwo), SVRule.OpCodes[1]);
        Assert.IsInstanceOf(typeof(Plus), SVRule.OpCodes[2]);

        yield return null;

    }
}
