using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Linq;

public class LobeInterpTest
{
    private RawGene LobeGene;
    [SetUp]
    public void SetUp()
    {
        LobeGene = new RawGene(Enumerable.Repeat<byte>(0, 200).ToArray<byte>());
    }

    [UnityTest]
    public IEnumerator LobeID()
    {
        LobeGene[2] = 7;

        var InterpretedGene = LobeInterpreter.Interpret(LobeGene);
        Assert.AreEqual((BrainLobeID)7, InterpretedGene.LobeID);

        yield return null;
    }

    [UnityTest]
    public IEnumerator LobeLocation()
    {
        Vector2Int Location = new Vector2Int(1, 2);
        LobeGene[7] = (byte)Location.x;
        LobeGene[8] = (byte)Location.y;

        var InterpretedGene = LobeInterpreter.Interpret(LobeGene);
        Assert.AreEqual(Location, InterpretedGene.Location);

        yield return null;
    }

    [UnityTest]
    public IEnumerator LobeDimensions()
    {
        Vector2Int Dimension = new Vector2Int(3, 4);
        LobeGene[9] = (byte)Dimension.x;
        LobeGene[10] = (byte)Dimension.y;

        var InterpretedGene = LobeInterpreter.Interpret(LobeGene);
        Assert.AreEqual(Dimension, InterpretedGene.Dimension);

        yield return null;
    }
}
