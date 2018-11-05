using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LobeBuilder {
    public static Lobe BuildFromGene(LobeGene gene, Brain brain)
    {
        var Neurons = Enumerable.Range(0, gene.Dimension.x * gene.Dimension.y).Select(n => new Neuron(n, gene.NeuronGene)).ToList();
        if (gene.Dendrite0 != null && gene.Dendrite1 != null)
        {
            Neurons = SetUpDendrites(Neurons, gene.Dendrite0, gene.Dendrite1, brain);
        }
        
        return new Lobe(gene.LobeID, gene.Location, gene.Dimension, Neurons);
    }

    private static List<Neuron> SetUpDendrites(List<Neuron> neurons, DendriteGene d0, DendriteGene d1, Brain brain)
    {
        foreach (var Neuron in neurons)
        {
            Neuron.Dendrites0 = DendriteBuilder.BuildFromGene(d0, brain, Neuron.Index);
            Neuron.Dendrites1 = DendriteBuilder.BuildFromGene(d1, brain, Neuron.Index);
        }
        return neurons;
    }
}
