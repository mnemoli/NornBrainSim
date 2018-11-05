using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Creatures;
using System.Linq;

public class DendriteBuilderTest
{
    private class DummyBrain : Brain
    {
        public override Lobe LobeFromIndex(BrainLobeType index)
        {
            return new Lobe(BrainLobeType.Attention, new Vector2Int(0, 0), new Vector2Int(0, 0), null);
        }
    }
    [UnityTest]
    public IEnumerator BuildSingleFlatDendrite()
    {
        Brain Brain = new DummyBrain();
        DendriteGene Gene = new DendriteGene(0, DendriteGene.SpreadType.Flat, new Vector2Int(1,1));
        var Dendrites = DendriteBuilder.BuildFromGene(Gene, Brain, 3);
        Assert.AreEqual(1, Dendrites.Count);
        Assert.AreEqual(3, Dendrites[0].SourceNeuronIndex);
        yield return null;
    }
    [UnityTest]
    public IEnumerator BuildMultipleFlatDendrites()
    {
        Brain Brain = new DummyBrain();
        DendriteGene Gene = new DendriteGene(0, DendriteGene.SpreadType.Flat, new Vector2Int(2,2));
        var Dendrites = DendriteBuilder.BuildFromGene(Gene, Brain, 3);
        Assert.AreEqual(2, Dendrites.Count);
        Assert.AreEqual(3, Dendrites[0].SourceNeuronIndex);
        yield return null;
    }
}
