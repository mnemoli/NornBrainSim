using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Linq;

public class DendriteInterpTest { 

    private RawGene LobeGene;

    [SetUp]
    public void CreateGene()
    {
        LobeGene = new RawGene(Enumerable.Repeat<byte>(0, 200).ToArray<byte>());
    }

    [UnityTest]
    public IEnumerator DendriteSource()
    {
        LobeGene[29] = 5;
        LobeGene[116] = 7;

        var InterpretedGene = DendriteInterpreter.Interpret(LobeGene);
        var Den0 = InterpretedGene[0];
        var Den1 = InterpretedGene[1];

        Assert.AreEqual((BrainLobeType)5, Den0.SourceLobeIndex);
        Assert.AreEqual((BrainLobeType)7, Den1.SourceLobeIndex);

        yield return null;
    }

    [UnityTest]
    public IEnumerator DendriteRange()
    {
        LobeGene[30] = 1;
        LobeGene[31] = 2;
        LobeGene[117] = 3;
        LobeGene[118] = 4;
        

        var InterpretedGene = DendriteInterpreter.Interpret(LobeGene);
        var Den0 = InterpretedGene[0];
        var Den1 = InterpretedGene[1];

        Assert.AreEqual(1, Den0.DendriteNumber.x);
        Assert.AreEqual(2, Den0.DendriteNumber.y);
        Assert.AreEqual(3, Den1.DendriteNumber.x);
        Assert.AreEqual(4, Den1.DendriteNumber.y);

        yield return null;
    }

    [UnityTest]
    public IEnumerator DendriteSpread()
    {
        LobeGene[32] = 1;
        LobeGene[119] = 3;

        var InterpretedGene = DendriteInterpreter.Interpret(LobeGene);
        var Den0 = InterpretedGene[0];
        var Den1 = InterpretedGene[1];

        Assert.AreEqual(DendriteGene.SpreadType.Normal, Den0.Spread);
        Assert.AreEqual(DendriteGene.SpreadType.Was, Den1.Spread);

        yield return null;
    }

    [UnityTest]
    public IEnumerator DendriteStrengthRange()
    {
        LobeGene[36] = 2;
        LobeGene[37] = 3;
        LobeGene[123] = 4;
        LobeGene[124] = 5;

        var InterpretedGene = DendriteInterpreter.Interpret(LobeGene);
        var Den0 = InterpretedGene[0];
        var Den1 = InterpretedGene[1];

        Assert.AreEqual(2, Den0.StrengthRange.x);
        Assert.AreEqual(3, Den0.StrengthRange.y);
        Assert.AreEqual(4, Den1.StrengthRange.x);
        Assert.AreEqual(5, Den1.StrengthRange.y);

        yield return null;
    }

    [UnityTest]
    public IEnumerator DendriteLTWRange()
    {
        LobeGene[34] = 2;
        LobeGene[35] = 3;
        LobeGene[121] = 4;
        LobeGene[122] = 5;

        var InterpretedGene = DendriteInterpreter.Interpret(LobeGene);
        var Den0 = InterpretedGene[0];
        var Den1 = InterpretedGene[1];

        Assert.AreEqual(2, Den0.LTWRange.x);
        Assert.AreEqual(3, Den0.LTWRange.y);
        Assert.AreEqual(4, Den1.LTWRange.x);
        Assert.AreEqual(5, Den1.LTWRange.y);

        yield return null;
    }
}
