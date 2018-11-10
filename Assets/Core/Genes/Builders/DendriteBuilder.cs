using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DendriteBuilder {

	public static List<Dendrite> BuildFromGene(DendriteGene gene, int sourceLobeSize, int destinationCellIndex)
    {
        List<Dendrite> Dendrites = new List<Dendrite>();
        // In C2, it appears that the spread doesn't really make any difference
        // and it's the fanout that actually alters the distribution
        // also, fanout may wrap round (e.g. in a 5-cell lobe, a fanout 1 dendrite may go to cell 4 and cell 0)
        foreach (var r in Enumerable.Range(0, gene.NumDendrites))
        {
            int SourceNeuronIndex = Random.Range(destinationCellIndex - gene.Fanout, destinationCellIndex + gene.Fanout) % sourceLobeSize;
            SourceNeuronIndex = (int)Mathf.Repeat(SourceNeuronIndex, sourceLobeSize);
            Dendrites.Add(new Dendrite(gene.SourceLobeIndex, SourceNeuronIndex, gene));
        }
        return Dendrites;
    }
}
