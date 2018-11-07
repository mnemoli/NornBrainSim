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
    private float Susceptibility;

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

    public void Process(Neuron owningNeuron = null)
    {
        RelaxLTWToSTW();
        RelaxSusceptibility();
    }

    private void RelaxLTWToSTW()
    {
        LTW = Relaxer.Relax(RelaxationModifier, DendriteGene.Dynamics.LTWGainRate, LTW, STW);
    }

    private void RelaxSusceptibility()
    {
        Susceptibility = Relaxer.Relax(RelaxationModifier, DendriteGene.Dynamics.SusceptibilityRelaxRate, Susceptibility, 0);
    }

    private void CalculateSusceptibility(Neuron owningNeuron = null)
    {
        var DataPacket = new SVDataPacket();
        DataPacket.Susceptibility = Mathf.RoundToInt(Susceptibility);
        DataPacket.NeuronInput = Mathf.RoundToInt(owningNeuron.Input);
        DataPacket.NeuronOutput = Mathf.RoundToInt(owningNeuron.Value);
        DataPacket.State = Mathf.RoundToInt(owningNeuron.RawValue);

        Susceptibility = DendriteGene.Dynamics.SusceptibilitySVRule.Evaluate(DataPacket);
    }
}
