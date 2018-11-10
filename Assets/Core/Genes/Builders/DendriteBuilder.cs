using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DendriteBuilder {

	public static List<Dendrite> BuildFromGene(DendriteGene gene, int sourceLobeSize, int destinationCellIndex, bool sourceIsPerception)
    {
        List<Dendrite> Dendrites = new List<Dendrite>();
        // In C2, it appears that the spread doesn't really make any difference
        // and it's the fanout that actually alters the distribution
        // also, fanout may wrap round (e.g. in a 5-cell lobe, a fanout 1 dendrite may go to cell 4 and cell 0)

        //hard coding for perception lobe
        bool Drive = false;
        bool Verb = false;
        foreach (var r in Enumerable.Range(0, gene.NumDendrites))
        {
            int SourceNeuronIndex = Random.Range(destinationCellIndex - gene.Fanout, destinationCellIndex + gene.Fanout) % sourceLobeSize;
            SourceNeuronIndex = (int)Mathf.Repeat(SourceNeuronIndex, sourceLobeSize);
            // Hard code perception lobe for now
            if (sourceIsPerception)
            {
                if (SourceNeuronIndex >= 0 && SourceNeuronIndex <= 15)
                {
                    Dendrites.Add(new Dendrite(gene.SourceLobeIndex, SourceNeuronIndex, gene, !Drive));
                    Drive = true;
                }
                else if (SourceNeuronIndex >= 16 && SourceNeuronIndex <= 31)
                {
                    Dendrites.Add(new Dendrite(gene.SourceLobeIndex, SourceNeuronIndex, gene, !Verb));
                    Verb = true;
                }
            }
            else
            {
                Dendrites.Add(new Dendrite(gene.SourceLobeIndex, SourceNeuronIndex, gene));
            }
        }
        return Dendrites;
    }
}
