using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Neuron {
    private float value;
    public int Value
    {
        get
        {
            return Mathf.RoundToInt(value > Gene.Threshold ? value : Gene.RestState);
        }
    }
    public float State { get; private set; }
    public int Index { get; private set; }
    public List<Dendrite> Dendrites0;
    public List<Dendrite> Dendrites1;
    public NeuronGene Gene;

    public Neuron(int index, NeuronGene neuronGene)
    {
        value = neuronGene.RestState;
        State = neuronGene.RestState;
        Index = index;
        Gene = neuronGene;
    }

    public void Process()
    {
        value = State;
        if (Dendrites0 != null && Dendrites1 != null)
        {
            foreach (var Dendrite in Dendrites0)
            {
                Dendrite.Process(this);
            }
            foreach (var Dendrite in Dendrites1)
            {
                Dendrite.Process(this);
            }
        }
        State = ProcessStateRule();
        State = Mathf.Clamp(State, 0, 255);
        State = ProcessLeakage();
    }

    private float ProcessStateRule()
    {
        SVDataPacket Data = new SVDataPacket
        {
            State = State,
            d0 = Dendrites0,
            d1 = Dendrites1,
            NeuronOutput = Value
        };
        return Gene.SVRule.Evaluate(Data);
    }

    private float ProcessLeakage()
    {
        if(Gene.Leakage == 0)
        {
            return Gene.RestState;
        }
        else
        {
            return Relaxer.Relax(6, Gene.Leakage, State, Gene.RestState);
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

    public void SetState(int strength)
    {
        State = strength;
    }

    public float Fire()
    {
        var ReturnVal = Value;
        State -= Gene.Threshold;
        return ReturnVal;
    }
}
