using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Lobe {

    public readonly BrainLobeType LobeID;
    public readonly Vector2Int Location;
    public readonly Vector2Int Dimension;
    public int NumNeurons
    {
        get { return Neurons.Count; }
    }
    private List<Neuron> Neurons;

    public Lobe(BrainLobeType lobeID, Vector2Int location, Vector2Int dimension, List<Neuron> neurons)
    {
        LobeID = lobeID;
        Location = location;
        Dimension = dimension;
        Neurons = neurons;
    }

    public void FireNeuron(int neuronIndex)
    {
        Neurons[neuronIndex].Fire(255);
    }

    public Neuron GetFiringNeuron()
    {
        return Neurons.OrderByDescending(n => n.Value).First();
    }
}
