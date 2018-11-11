using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class Dendrite  {
    public Lobe SourceLobe { get; private set; }
    public readonly BrainLobeType SourceLobeIndex;
    public int SourceNeuronIndex { get; private set; }
    private readonly DendriteGene DendriteGene;
    public float LTW { get; protected set; }
    public float STW { get; protected set; }
    public float Strength { get; private set; }
    private float Susceptibility;
    private float value;
    
    private SVDataPacket SVDataPacket = new SVDataPacket();

    private static readonly float RelaxationModifier = 6f;
    private static readonly float STWModifier = 255f;

    public Dendrite(BrainLobeType sourceLobeIndex, int sourceNeuronIndex, DendriteGene gene, bool noStrength = false)
    {
        SourceLobeIndex = sourceLobeIndex;
        SourceNeuronIndex = sourceNeuronIndex;
        DendriteGene = gene;
        LTW = gene.InitialLTW;
        STW = gene.InitialLTW;
        if(noStrength)
        {
            Strength = 0;
        }
        else
        {
            Strength = gene.InitialStrength;
        }
    }

    public void SetSourceLobe(Lobe lobe)
    {
        SourceLobe = lobe;
    }

    public float GetValue()
    {
        return Strength > 0 ? value : 0;
    }

    public void Process(Neuron owningNeuron = null)
    {
        RelaxLTWToSTW();
        RelaxSusceptibility();
        CalculateSusceptibility(owningNeuron);
        value = SourceLobe.GetValueOfNeuronAndFire(SourceNeuronIndex) * (STW / STWModifier);
        CalculateStrength(owningNeuron);
        Migrate(owningNeuron);
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
        Profiler.BeginSample("Calculate suscept");
        if(owningNeuron != null)
        {
            SVDataPacket.Susceptibility = Susceptibility;
            SVDataPacket.NeuronOutput = owningNeuron.Value;
            SVDataPacket.State = owningNeuron.State;
            Susceptibility = DendriteGene.Dynamics.SusceptibilitySVRule.Evaluate(SVDataPacket);
        }
        Profiler.EndSample();
    }

    private void CalculateStrength(Neuron owningNeuron = null)
    {
        var StrengthTemp = Strength;

        SVDataPacket.Susceptibility = Susceptibility;
        SVDataPacket.NeuronOutput = owningNeuron.Value;
        SVDataPacket.State = owningNeuron.State;
        SVDataPacket.STW = STW;

        Profiler.BeginSample("Strength check");

        var StrengthGainCheck = DendriteGene.Dynamics.StrengthGainSVRule.Evaluate(SVDataPacket);

        Profiler.EndSample();

        if (StrengthGainCheck > 0)
        {
            StrengthTemp = Relaxer.Relax(1, DendriteGene.Dynamics.StrengthGain, Strength, 255f);
        }

        Profiler.BeginSample("Strength check 2");
        if(Strength > 0)
        {
            var StrengthLossCheck = DendriteGene.Dynamics.StrengthLossSVRule.Evaluate(SVDataPacket);

            if (StrengthLossCheck > 0)
            {
                StrengthTemp = Relaxer.Relax(1, DendriteGene.Dynamics.StrengthGain, Strength, 0f);
            }
        }
        Profiler.EndSample();

    }

    private void ProcessMigration(Neuron owningNeuron = null)
    {
        if (owningNeuron == null)
            return;
        switch(DendriteGene.Dynamics.MigrateWhen)
        {
            case 0:
                return;
            case 1:
                MigrateWhenAny(owningNeuron);
                break;
            case 2:
                MigrateWhenAll(owningNeuron);
                break;
        }
    }

    private void MigrateWhenAny(Neuron owningNeuron)
    {
        if(owningNeuron.AnyDendriteLoose(DendriteGene.Type))
        {
            Migrate(owningNeuron);
        }
    }

    private void MigrateWhenAll(Neuron owningNeuron)
    {
        if(owningNeuron.AllDendritesLoose(DendriteGene.Type))
        {
            Migrate(owningNeuron);
        }
    }

    private void Migrate(Neuron owningNeuron)
    {
        // Hard coding for perception lobe
        int SourceNeuronIndex = Random.Range(owningNeuron.Index - DendriteGene.Fanout, owningNeuron.Index + DendriteGene.Fanout) % SourceLobe.NumNeurons;
        SourceNeuronIndex = (int)Mathf.Repeat(SourceNeuronIndex, SourceLobe.NumNeurons);
        if (SourceLobe.LobeID == BrainLobeID.Perception)
        {
            if (SourceNeuronIndex > 0 && SourceNeuronIndex <= 15 && owningNeuron.CheckForExistingDriveDendrite())
            {

            }
            else if (SourceNeuronIndex >= 16 && SourceNeuronIndex <= 31 && owningNeuron.CheckForExistingVerbDendrite())
            {

            }
            else
            {
                this.SourceNeuronIndex = SourceNeuronIndex;
                Strength = DendriteGene.InitialStrength;
            }
        }
    }
}
