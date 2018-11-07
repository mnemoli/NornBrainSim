using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

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

    public float GetValueOfNeuron(int index)
    {
        return Neurons[index].Value;
    }
    
    public void SetUpDendrites(Brain brain)
    {
        if (Neurons.Any(n => n.Dendrites0 == null && n.Dendrites1 == null))
        {
            return;
        }
        foreach(var Neuron in Neurons)
        {
            if (Neuron.Dendrites0 != null)
            {
                foreach (var Dendrite0 in Neuron.Dendrites0)
                {
                    Dendrite0.SetSourceLobe(brain.LobeFromIndex(Dendrite0.SourceLobeIndex));
                }
            }
            if (Neuron.Dendrites1 != null)
            {
                foreach (var Dendrite1 in Neuron.Dendrites1)
                {
                    Dendrite1.SetSourceLobe(brain.LobeFromIndex(Dendrite1.SourceLobeIndex));
                }
            }
            
        }
        
    }

    public void Render()
    {
        LobeRenderer.Render(Location, Dimension);
    }

    public void RenderDendrites()
    {
        foreach (var Neuron in Neurons)
        {
            if (Neuron.Dendrites0 == null)
                continue;
            foreach(var Dendrite0 in Neuron.Dendrites0)
            {
                DendriteRenderer.Render(Dendrite0.SourceLobe.Location, Dendrite0.SourceLobe.Dimension, Dendrite0.SourceNeuronIndex, Location, Dimension, Neuron.Index); 
            }
        }
    }
}
