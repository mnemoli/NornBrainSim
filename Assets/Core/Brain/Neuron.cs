using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Neuron {
    private float value = 0;
    public float Value {
        get
        {
            return (value > Gene.Threshold) ? value : Gene.RestState;
        }
        private set
        {
            this.value = value;
        }
    }
    public float RawValue
    {
        get
        {
            return value;
        }
    }
    private float input = 0;
    public float Input
    {
        get
        {
            return input;
        }
    }
    public int Index { get; private set; }
    public List<Dendrite> Dendrites0;
    public List<Dendrite> Dendrites1;
    public NeuronGene Gene;

    public Neuron(int index, NeuronGene neuronGene)
    {
        Value = neuronGene.RestState;
        Index = index;
        Gene = neuronGene;
    }

    public void Process()
    {
        value = ProcessLeakage();

        if(Dendrites0 != null && Dendrites1 != null)
        {
            foreach (var Dendrite in Dendrites0)
            {
                Dendrite.Process(this);
            }
            foreach (var Dendrite in Dendrites1)
            {
                Dendrite.Process(this);
            }

            //value = ProcessStateRule();
        }
    }

    private float ProcessLeakage()
    {
        if(Gene.Leakage == 0)
        {
            return Gene.RestState;
        }
        else
        {
            return Relaxer.Relax(6, Gene.Leakage, value, Gene.RestState);
        }
    }

    private float GetDendrite0Values()
    {
        return Dendrites0.Aggregate(0f, (agg, n) => agg + n.GetValue());
    }

    private float GetDendrite1Values()
    {
        return Dendrites0.Aggregate(0f, (agg, n) => agg + n.GetValue());
    }

    public void SetStrength(int strength)
    {
        Value = strength;
    }
}
