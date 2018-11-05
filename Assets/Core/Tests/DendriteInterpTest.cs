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
}
