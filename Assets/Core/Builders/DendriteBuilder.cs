using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DendriteBuilder {

	public static List<Dendrite> BuildFromGene(DendriteGene gene, int sourceLobeSize, int destinationCellIndex)
    {
        List<Dendrite> Dendrites = new List<Dendrite>();
        int SourceNeuronIndex;
        if (gene.Spread == DendriteGene.SpreadType.Flat)
        {
            SourceNeuronIndex = destinationCellIndex;
        }
        else
        {
            // choose a random distribution for now -- TODO
            SourceNeuronIndex = Random.Range(0, sourceLobeSize - 1);
        }
        foreach (var r in Enumerable.Range(0, gene.NumDendrites))
        {
            Dendrites.Add(new Dendrite(gene.SourceLobeIndex, SourceNeuronIndex, gene));
        }
        return Dendrites;
    }
}
