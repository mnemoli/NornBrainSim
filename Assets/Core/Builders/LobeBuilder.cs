using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LobeBuilder {
    public static Lobe BuildFromGene(LobeGene gene, int numSourceNeurons0, int numSourceNeurons1)
    {
        var Neurons = Enumerable.Range(0, gene.Dimension.x * gene.Dimension.y).Select(n => new Neuron(n, gene.NeuronGene)).ToList();
        Neurons = SetUpDendrites(Neurons, gene.Dendrite0, gene.Dendrite1, numSourceNeurons0, numSourceNeurons1);
        return new Lobe(gene.LobeID, gene.Location, gene.Dimension, Neurons);
    }

    public static List<Neuron> SetUpDendrites(List<Neuron> neurons, DendriteGene d0, DendriteGene d1, int numSourceNeurons0, int numSourceNeurons1)
    {
        foreach (var Neuron in neurons)
        {
            if (d0 == null || d1 == null)
                return neurons;
            if (d0.NumDendrites > 0)
                Neuron.Dendrites0 = DendriteBuilder.BuildFromGene(d0, numSourceNeurons0, Neuron.Index);
            if (d1.NumDendrites > 0)
                Neuron.Dendrites1 = DendriteBuilder.BuildFromGene(d1, numSourceNeurons1, Neuron.Index);
        }
        return neurons;
    }
}
