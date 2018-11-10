using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DendriteInterpreter {

	public static List<DendriteGene> Interpret(RawGene gene)
    {
        List<DendriteGene> Genes = new List<DendriteGene>();
        int[] Offsets = { 29, 116 };

        foreach (var Offset in Offsets)
        {
            BrainLobeType SourceLobeIndex = (BrainLobeType)gene[Offset];
            Vector2Int DendriteRange = new Vector2Int(gene[Offset+1], gene[Offset+2]);
            DendriteGene.SpreadType Spread = (DendriteGene.SpreadType)gene[Offset+3];
            int Fanout = gene[Offset + 4];
            Vector2Int LTWRange = new Vector2Int(gene[Offset + 5], gene[Offset + 6]);
            Vector2Int StrengthRange = new Vector2Int(gene[Offset + 7], gene[Offset + 8]);
            int LTWGainRate = gene[Offset + 12];
            int SusceptibilityRelaxRate = gene[Offset + 10];
            RawGene SusceptRule = new RawGene(gene.GetRange(Offset + 39, 12).ToArray());
            var SusceptibilitySVRule = SVRuleBuilder.Build(SVRuleInterpreter.Interpret(SusceptRule));

            var DendriteDynamics = new DendriteDynamicsGene(LTWGainRate, SusceptibilityRelaxRate, SusceptibilitySVRule);

            Genes.Add(new DendriteGene(SourceLobeIndex, Spread, Fanout, DendriteRange, LTWRange, StrengthRange, DendriteDynamics));
        }

        return Genes;
    }
}
