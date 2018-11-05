using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Neuron : ScriptableObject {
    private int value;
    public int Value {
        get
        {
            return (value > Gene.Threshold ? value : 0);
        }
        private set
        {
            this.value = value;
        }
    }
    public int Index { get; private set; }
    public List<Dendrite> Dendrites0;
    public List<Dendrite> Dendrites1;
    public NeuronGene Gene;

    public Neuron(int index, NeuronGene neuronGene)
    {
        Value = 0;
        Index = index;
        Gene = neuronGene;
    }

    public void Fire(int strength)
    {
        Value = strength;
    }
}
