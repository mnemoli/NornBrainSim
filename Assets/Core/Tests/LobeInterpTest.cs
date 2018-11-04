using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Creatures;
using System.Collections.Generic;

public class LobeInterpTest
{

    public LobeInterpreter LobeInterpreter;

    [SetUp]
    public void MakeInterpreter()
    {
        const string FileLocation = "F:\\Jade\\Documents\\Unity Projects\\BrainSim2\\Assets\\Genes\\norn.gen";
        GeneFileLoader g = GeneFileLoader.CreateNew(FileLocation);
        LobeInterpreter = ScriptableObject.CreateInstance<LobeInterpreter>();
    }

    [UnityTest]
    public IEnumerator LobeLocation()
    {
        Vector2Int Location = new Vector2Int(1, 2);
        var GeneBytes = new byte[16];
        GeneBytes[7] = (byte)Location.x;
        GeneBytes[8] = (byte)Location.y;
        Gene LobeGene = new Gene(GeneBytes);

        Lobe Lobe = LobeInterpreter.LobeFromGene(LobeGene);
        Assert.AreEqual(Lobe.Location.x, Location.x);
        Assert.AreEqual(Lobe.Location.y, Location.y);
        yield return null;
    }

    [UnityTest]
    public IEnumerator LobeDimensions()
    {
        Vector2Int Dimension = new Vector2Int(3, 4);
        var GeneBytes = new byte[16];
        GeneBytes[9] = (byte)Dimension.x;
        GeneBytes[10] = (byte)Dimension.y;
        Gene LobeGene = new Gene(GeneBytes);

        Lobe Lobe = LobeInterpreter.LobeFromGene(LobeGene);
        Assert.AreEqual(Lobe.Dimension.x, Dimension.x);
        Assert.AreEqual(Lobe.Dimension.y, Dimension.y);
        yield return null;
    }
}
