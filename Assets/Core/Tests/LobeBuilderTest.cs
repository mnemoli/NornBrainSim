using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Creatures;
using System.Linq;

public class LobeBuilderTest
{
    private class DummyBrain : Brain
    {
        public override Lobe LobeFromIndex(BrainLobeType index)
        {
            return new Lobe(BrainLobeType.Attention, new Vector2Int(0, 0), new Vector2Int(0, 0), null);
        }
    }
    [UnityTest]
    public IEnumerator BuildLobe()
    {
        DummyBrain Brain = new DummyBrain();
        var Location = new Vector2Int(1, 2);
        var Dimension = new Vector2Int(3, 4);
        LobeGene Gene = new LobeGene(BrainLobeType.Concept, Location, Dimension, null, null, null);
        var Lobe = LobeBuilder.BuildFromGene(Gene, Brain);
        Assert.AreEqual(BrainLobeType.Concept, Lobe.LobeID);
        Assert.AreEqual(Location, Lobe.Location);
        Assert.AreEqual(Dimension, Lobe.Dimension);
        Assert.AreEqual(Dimension.x * Dimension.y, Lobe.NumNeurons);

        yield return null;
    }
}
