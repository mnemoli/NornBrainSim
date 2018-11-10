using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Profiling;

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
    private SVDataPacket SVDataPacket = new SVDataPacket();

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
        Profiler.BeginSample("Dendrites");
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
        Profiler.EndSample();
        Profiler.BeginSample("State rule");
        State = ProcessStateRule();
        Profiler.EndSample();
        State = Mathf.Clamp(State, 0, 255);
        Profiler.BeginSample("Leakage");
        State = ProcessLeakage();
        Profiler.EndSample();
    }

    private float ProcessStateRule()
    {
        SVDataPacket.State = State;
        SVDataPacket.d0 = Dendrites0;
        SVDataPacket.d1 = Dendrites1;
        SVDataPacket.NeuronOutput = Value;
        return Gene.SVRule.Evaluate(SVDataPacket);
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

    public bool AnyDendriteLoose(int type)
    {
        var DendriteType = type == 0 ? Dendrites0 : Dendrites1;
        return DendriteType.Any(n => n.Strength == 0);
    }

    public bool AllDendritesLoose(int type)
    {
        var DendriteType = type == 0 ? Dendrites0 : Dendrites1;
        return DendriteType.All(n => n.Strength == 0);
    }

    public bool CheckForExistingDriveDendrite()
    {
        return Dendrites0.Concat(Dendrites1).Any(n => n.SourceNeuronIndex < 15);
    }

    public bool CheckForExistingVerbDendrite()
    {
        return Dendrites0.Concat(Dendrites1).Any(n => n.SourceNeuronIndex > 16 && n.SourceNeuronIndex < 31);
    }
}
