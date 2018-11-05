using NUnit.Framework;
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
    public void NeuronAboveThreshold()
    {
        Neuron.Fire(150);
        Assert.Equals(150, Neuron.Value);
    }
    [UnityTest]
    public void NeuronBelowThreshold()
    {
        Neuron.Fire(50);
        Assert.Equals(0, Neuron.Value);
    }
}
