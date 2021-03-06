﻿using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class LobeBuilderTest
{
    private class DummyBrain : Brain
    {
        public override Lobe LobeFromIndex(BrainLobeType index)
        {
            return new Lobe(BrainLobeID.Attention, null, new Vector2Int(0, 0), new Vector2Int(0, 0), null, false, false);
        }
    }
    [UnityTest]
    public IEnumerator BuildLobe()
    {
        DummyBrain Brain = new DummyBrain();
        var Location = new Vector2Int(1, 2);
        var Dimension = new Vector2Int(3, 4);
        LobeGene Gene = new LobeGene(BrainLobeID.Concept, Location, Dimension, null, null, null, 0, 0);
        var Lobe = LobeBuilder.BuildFromGene(Gene, 25, 25);
        Assert.AreEqual(BrainLobeID.Concept, Lobe.LobeID);
        Assert.AreEqual(Location, Lobe.Location);
        Assert.AreEqual(Dimension, Lobe.Dimension);
        Assert.AreEqual(Dimension.x * Dimension.y, Lobe.NumNeurons);

        yield return null;
    }
}
