using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dendrite  {
    public Lobe SourceLobe { get; private set; }
    public readonly BrainLobeType SourceLobeIndex;
    public readonly int SourceNeuronIndex;
    private readonly DendriteGene DendriteGene;
    public float LTW { get; protected set; }
    public float STW { get; protected set; }
    private int Strength;

    private static readonly float RelaxationModifier = 6f;
    private static readonly float STWModifier = 255f;

    public Dendrite(BrainLobeType sourceLobeIndex, int sourceNeuronIndex, DendriteGene gene)
    {
        SourceLobeIndex = sourceLobeIndex;
        SourceNeuronIndex = sourceNeuronIndex;
        DendriteGene = gene;
        LTW = gene.InitialLTW;
        STW = gene.InitialLTW;
        Strength = gene.InitialStrength;
    }

    public void SetSourceLobe(Lobe lobe)
    {
        SourceLobe = lobe;
    }

    public float GetValue()
    {
        return SourceLobe.GetValueOfNeuron(SourceNeuronIndex) * (STW / STWModifier);
    }

    public void Process()
    {
        RelaxLTWToSTW();
    }

    private void RelaxLTWToSTW()
    {
        if (DendriteGene.Dynamics.LTWGainRate > 0)
        {
            float t = RelaxationModifier * (1f / DendriteGene.Dynamics.LTWGainRate);
            LTW = Mathf.Lerp(LTW, STW, t);
        } 
    }
}
