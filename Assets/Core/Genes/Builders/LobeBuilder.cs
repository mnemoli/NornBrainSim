using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LobeBuilder {
    public static Lobe BuildFromGene(LobeGene gene, int numSourceNeurons0, int numSourceNeurons1)
    {
        var Neurons = Enumerable.Range(0, gene.Dimension.x * gene.Dimension.y).Select(n => new Neuron(n, gene.NeuronGene)).ToList();
        Neurons = SetUpDendrites(Neurons, gene.Dendrite0, gene.Dendrite1, numSourceNeurons0, numSourceNeurons1, gene.LobeID == BrainLobeID.Perception);
        Type NeuronEnumType = null;
        switch(gene.LobeID)
        {
            case BrainLobeID.StimulusSource:
                NeuronEnumType = typeof(StimulusGenus);
                break;
            case BrainLobeID.Drive:
                NeuronEnumType = typeof(DriveGenus);
                break;
            case BrainLobeID.Verb:
                NeuronEnumType = typeof(VerbGenus);
                break;
            case BrainLobeID.Noun:
                NeuronEnumType = typeof(StimulusGenus);
                break;
            case BrainLobeID.Decision:
                NeuronEnumType = typeof(VerbGenus);
                break;
            case BrainLobeID.Attention:
                NeuronEnumType = typeof(StimulusGenus);
                break;
        }
        return new Lobe(gene.LobeID, NeuronEnumType, gene.Location, gene.Dimension, Neurons, gene.CopyToPerceptionLobe, gene.WinnerTakesAll);
    }

    public static List<Neuron> SetUpDendrites(List<Neuron> neurons, DendriteGene d0, DendriteGene d1, int numSourceNeurons0, int numSourceNeurons1, bool sourceIsPerception)
    {
        foreach (var Neuron in neurons)
        {
            if (d0 == null || d1 == null)
                return neurons;
            if (d0.NumDendrites > 0)
                Neuron.Dendrites0 = DendriteBuilder.BuildFromGene(d0, numSourceNeurons0, Neuron.Index, sourceIsPerception);
            if (d1.NumDendrites > 0)
                Neuron.Dendrites1 = DendriteBuilder.BuildFromGene(d1, numSourceNeurons1, Neuron.Index, sourceIsPerception);
        }
        return neurons;
    }
}
