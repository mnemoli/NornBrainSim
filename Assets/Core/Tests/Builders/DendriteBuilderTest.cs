using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Linq;

public class DendriteBuilderTest
{
    private class DummyBrain : Brain
    {
        public override Lobe LobeFromIndex(BrainLobeType index)
        {
            return new Lobe(BrainLobeID.Attention, null, new Vector2Int(0, 0), new Vector2Int(0, 0), null, false, false);
        }
    }

    private DendriteGene MakeGene(int numDendrites)
    {
        var Dynamics = new DendriteDynamicsGene(1, 0, null);
        return new DendriteGene(0, DendriteGene.SpreadType.Flat, 0, new Vector2Int(numDendrites, numDendrites), new Vector2Int(0, 0), new Vector2Int(0, 0), Dynamics);
    }

    [UnityTest]
    public IEnumerator BuildSingleFlatDendrite()
    {
        Brain Brain = new DummyBrain();
        DendriteGene Gene = MakeGene(1);
        var Dendrites = DendriteBuilder.BuildFromGene(Gene, 25, 3, false);
        Assert.AreEqual(1, Dendrites.Count);
        Assert.AreEqual(3, Dendrites[0].SourceNeuronIndex);
        yield return null;
    }
    [UnityTest]
    public IEnumerator BuildMultipleFlatDendrites()
    {
        Brain Brain = new DummyBrain();
        DendriteGene Gene = MakeGene(2);
        var Dendrites = DendriteBuilder.BuildFromGene(Gene, 25, 3, false);
        Assert.AreEqual(2, Dendrites.Count);
        Assert.AreEqual(3, Dendrites[0].SourceNeuronIndex);
        yield return null;
    }
}
