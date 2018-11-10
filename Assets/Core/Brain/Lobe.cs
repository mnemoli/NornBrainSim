using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Lobe {

    public readonly BrainLobeID LobeID;
    public readonly Type NeuronEnumType;
    public readonly Vector2Int Location;
    public readonly Vector2Int Dimension;
    public int NumNeurons
    {
        get { return Neurons.Count; }
    }

    public readonly bool CopyToPerceptionLobe;
    private Lobe PerceptionLobe;
    private int OffsetIntoPerceptionLobe;
    private readonly bool WinnerTakesAll;

    private List<Neuron> Neurons;

    public Lobe(BrainLobeID lobeID, Type neuronEnumType, Vector2Int location, Vector2Int dimension, List<Neuron> neurons, bool copyToPerceptionLobe, bool winnerTakesAll)
    {
        LobeID = lobeID;
        NeuronEnumType = neuronEnumType;
        Location = location;
        Dimension = dimension;
        Neurons = neurons;
        CopyToPerceptionLobe = copyToPerceptionLobe;
        WinnerTakesAll = winnerTakesAll;
    }

    public void SetUpPerceptionLobeLink(int offsetIntoPerceptionLobe, Lobe perceptionLobe)
    {
        OffsetIntoPerceptionLobe = offsetIntoPerceptionLobe;
        PerceptionLobe = perceptionLobe;
    }

    public void Process()
    {
        foreach(var Neuron in Neurons)
        {
            Neuron.Process();
        }
        if(CopyToPerceptionLobe)
        {
            foreach(var Neuron in GetFiringNeurons())
            {
                PerceptionLobe.CopyToNeuron(OffsetIntoPerceptionLobe + Neuron.Index, Neuron.Value);
            }
        }

    }

    public void CopyToNeuron(int neuronIndex, int amount = 255)
    {
        Neurons[neuronIndex].SetState(amount);
    }

    public void FireNeuron(int neuronIndex, int amount = 255)
    {
        Neurons[neuronIndex].SetState(amount);
    }

    public Neuron GetFiringNeuron()
    {
        var N = Neurons.OrderByDescending(n => n.Value).First();
        if (N.Value > 0)
        {
            return N;
        }
        else
        {
            return null;
        }
    }

    public List<Neuron> GetFiringNeurons()
    {
        if(WinnerTakesAll)
        {
            var Neuron = new List<Neuron>();
            var FiringNeuron = GetFiringNeuron();
            if(FiringNeuron != null)
            {
                Neuron.Add(GetFiringNeuron());
            }
            return Neuron;
        }
        else
        {
            return Neurons.FindAll(n => n.Value > n.Gene.RestState);
        }
    }

    public float GetValueOfNeuronAndFire(int index)
    {
        return Neurons[index].Fire();
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
        var Neuron = GetFiringNeuron();
        var NeuronIndex = (Neuron == null) ? -1 : Neuron.Index;
        var NeuronValue = (Neuron == null) ? 0 : Neuron.Value;
        LobeRenderer.Render(Location, Dimension, NeuronEnumType, NeuronIndex, NeuronValue);
    }

    public void RenderDendrites()
    {
        foreach (var Neuron in Neurons)
        {
            if (Neuron.Dendrites0 != null)
            {
                foreach (var Dendrite0 in Neuron.Dendrites0)
                {
                    DendriteRenderer.Render(0, Dendrite0.SourceLobe.Location, Dendrite0.SourceLobe.Dimension, Dendrite0.SourceNeuronIndex, Location, Dimension, Neuron.Index);
                }
            }
            if(Neuron.Dendrites1 != null)
            {
                foreach (var Dendrite1 in Neuron.Dendrites1)
                {
                    DendriteRenderer.Render(1, Dendrite1.SourceLobe.Location, Dendrite1.SourceLobe.Dimension, Dendrite1.SourceNeuronIndex, Location, Dimension, Neuron.Index);
                }
            }
            
        }
    }
}
