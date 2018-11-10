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
        var Neurons = Enumerable.Range(0, 100).Select(n => new Neuron(n, new NeuronGene(0, 0, 0, null))).ToList<Neuron>();
        Brain.AddLobe(new Lobe(BrainLobeID.Perception, null, new Vector2Int(0, 0), new Vector2Int(10, 10), Neurons, false, false));
        Brain.AddLobe(new Lobe(BrainLobeID.Drive, null, new Vector2Int(0, 0), new Vector2Int(10, 10), Neurons, false, false));
        Brain.AddLobe(new Lobe(BrainLobeID.StimulusSource, null, new Vector2Int(0, 0), new Vector2Int(10, 10), Neurons, false, false));
        Brain.AddStimulus(StimulusGenus.Critter);

        yield return null ; // wait one tick for processing

        var Stim = Brain.GetHighestStimulus();
        Assert.AreEqual(StimulusGenus.Critter, Stim);

        yield return null;
    }
}
