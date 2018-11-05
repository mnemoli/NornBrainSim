using NUnit.Framework;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.TestTools;

public class BrainTest
{ 
    [UnityTest]
    public IEnumerator FireStimulus()
    {
        GameObject go = new GameObject("dummy");
        Brain Brain = go.AddComponent<Brain>();
        var Neurons = Enumerable.Range(0, 100).Select(n => new Neuron(n, new NeuronGene(0, 0))).ToList();
        Brain.AddLobe(new Lobe(BrainLobeType.StimulusSource, new Vector2Int(0, 0), new Vector2Int(10, 10), Neurons));
        Brain.AddStimulus(StimulusGenus.Critter);

        yield return null ; // wait one tick for processing

        var Stim = Brain.GetHighestStimulus();
        Assert.AreEqual(StimulusGenus.Critter, Stim);

        yield return null;
    }
}
