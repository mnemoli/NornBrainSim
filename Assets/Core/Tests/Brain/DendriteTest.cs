using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Linq;

public class DendriteTest
{
    private static readonly float FixedUpdateTime = Time.fixedDeltaTime;

    private class TestDendrite : Dendrite
    {
        public TestDendrite(BrainLobeType sourceLobeIndex, int sourceNeuronIndex, DendriteGene gene) : base(sourceLobeIndex, sourceNeuronIndex, gene)
        {
        }

        public void MockSTW(int stw)
        {
            STW = stw;
        }
    }

    [UnityTest]
    public IEnumerator LTWZeroToOne()
    {
        var LTWGainRate = 16;
        var DynamicsGene = new DendriteDynamicsGene(LTWGainRate, 0, null);
        DendriteGene DendriteGene = new DendriteGene(0, DendriteGene.SpreadType.Flat, new Vector2Int(0,0), new Vector2Int(0, 0), new Vector2Int(1, 1), DynamicsGene);
        TestDendrite Dendrite = new TestDendrite(0, 0, DendriteGene);
        Dendrite.MockSTW(1);
        // Process assumes it is being called in FixedUpdate
        // i.e. 10 times a second
        foreach(var i in Enumerable.Range(0, 5))
        {
            Dendrite.Process();
        }
        Assert.AreEqual(1, Mathf.RoundToInt(Dendrite.LTW));

        yield return null;
    }

    [UnityTest]
    public IEnumerator LTW255ToZero()
    {
        var LTWGainRate = 16;
        var Start = 255;
        var End = 3;
        var DynamicsGene = new DendriteDynamicsGene(LTWGainRate, 0, null);
        DendriteGene DendriteGene = new DendriteGene(0, DendriteGene.SpreadType.Flat, new Vector2Int(0, 0), new Vector2Int(Start, Start), new Vector2Int(1, 1), DynamicsGene);
        TestDendrite Dendrite = new TestDendrite(0, 0, DendriteGene);
        Dendrite.MockSTW(1);
        // Process assumes it is being called in FixedUpdate
        // i.e. 10 times a second
        foreach (var i in Enumerable.Range(0, 10))
        {
            Dendrite.Process();
        }
        Assert.AreEqual(End, Mathf.RoundToInt(Dendrite.LTW));

        yield return null;
    }

    [UnityTest]
    public IEnumerator GetValue()
    {
        var DynamicsGene = new DendriteDynamicsGene(1, 0, null);
        DendriteGene DendriteGene = new DendriteGene(0, DendriteGene.SpreadType.Flat, new Vector2Int(0, 0), new Vector2Int(5, 5), new Vector2Int(1, 1), DynamicsGene);
        TestDendrite Dendrite = new TestDendrite(0, 0, DendriteGene);
        NeuronGene NeuronGene = new NeuronGene(0, 0, 0);
        Lobe lobe = new Lobe(0, null, new Vector2Int(0, 0), new Vector2Int(5, 5), Enumerable.Range(0, 25).Select(n => new Neuron(n, NeuronGene)).ToList());
        lobe.FireNeuron(0);
        Dendrite.SetSourceLobe(lobe);
        Dendrite.MockSTW(1);
        var DendriteValue = Dendrite.GetValue();
        Assert.AreEqual(1, DendriteValue);

        Dendrite.MockSTW(255);
        DendriteValue = Dendrite.GetValue();
        Assert.AreEqual(255, DendriteValue);

        yield return null;
    }
}
