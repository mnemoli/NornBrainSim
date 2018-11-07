using NUnit.Framework;
using System.Collections;
using UnityEngine.TestTools;

public class NeuronTest
{
    private Neuron Neuron;

    [SetUp]
    public void CreateNeuron()
    {
        var NeuronGene = new NeuronGene(100, 0);
        Neuron = new Neuron(0, NeuronGene);
    }
    [UnityTest]
    public IEnumerator NeuronAboveThreshold()
    {
        Neuron.Fire(150);
        Assert.AreEqual(150, Neuron.Value);

        yield return null;
    }
    [UnityTest]
    public IEnumerator NeuronBelowThreshold()
    {
        Neuron.Fire(50);
        Assert.AreEqual(0, Neuron.Value);

        yield return null;
    }
}
