using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TestTools;

public class NeuronTest
{
    private Neuron Neuron;

    [SetUp]
    public void CreateNeuron()
    {
        var OpCodes = new List<OpCode.IOpCode>
        {
            new OpCode.State()
        };
        var SVRule = new SVRule(OpCodes);
        var NeuronGene = new NeuronGene(100, 0, 255, SVRule);
        Neuron = new Neuron(0, NeuronGene);
    }

    [UnityTest]
    public IEnumerator NeuronAboveThreshold()
    {
        Neuron.SetState(150);
        Neuron.Process();
        Assert.That(Neuron.Value > 145 && Neuron.Value <= 150);

        yield return null;
    }
    [UnityTest]
    public IEnumerator NeuronBelowThreshold()
    {
        Neuron.SetState(50);
        Assert.AreEqual(0, Neuron.Value);

        yield return null;
    }
}
