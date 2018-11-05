using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DendriteBuilder {

	public static List<Dendrite> BuildFromGene(DendriteGene gene, Brain brain, int destinationCellIndex)
    {
        List<Dendrite> Dendrites = new List<Dendrite>();
        Lobe Lobe = brain.LobeFromIndex(gene.SourceLobeIndex);
        // Always use a flat spread for now - TODO
        int SourceNeuronIndex = destinationCellIndex;
        foreach (var r in Enumerable.Range(0, gene.NumDendrites))
        {
            Dendrites.Add(new Dendrite(Lobe, SourceNeuronIndex));
        }
        return Dendrites;
    }
}
