using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DendriteInterpreter {

	public static List<DendriteGene> Interpret(RawGene gene)
    {
        List<DendriteGene> Genes = new List<DendriteGene>();
        int[] Offsets = { 29, 116 };

        for(int i = 0; i < Offsets.Length; i++)
        {
            var Offset = Offsets[i];
            BrainLobeType SourceLobeIndex = (BrainLobeType)gene[Offset];
            Vector2Int DendriteRange = new Vector2Int(gene[Offset+1], gene[Offset+2]);
            DendriteGene.SpreadType Spread = (DendriteGene.SpreadType)gene[Offset+3];
            int Fanout = gene[Offset + 4];
            Vector2Int LTWRange = new Vector2Int(gene[Offset + 5], gene[Offset + 6]);
            Vector2Int StrengthRange = new Vector2Int(gene[Offset + 7], gene[Offset + 8]);
            int LTWGainRate = gene[Offset + 12];
            int STWGainRate = gene[Offset + 11];
            int SusceptibilityRelaxRate = gene[Offset + 10];
            RawGene SusceptRule = new RawGene(gene.GetRange(Offset + 39, 12).ToArray());
            var SusceptibilitySVRule = SVRuleBuilder.Build(SVRuleInterpreter.Interpret(SusceptRule));
            var StrengthGain = gene[Offset + 13];
            RawGene StrengthRule = new RawGene(gene.GetRange(Offset + 14, 12).ToArray());
            var StrengthSVRule = SVRuleBuilder.Build(SVRuleInterpreter.Interpret(StrengthRule));
            var StrengthLoss = gene[Offset + 26];
            StrengthRule = new RawGene(gene.GetRange(Offset + 27, 12).ToArray());
            var StrengthLossSVRule = SVRuleBuilder.Build(SVRuleInterpreter.Interpret(StrengthRule));
            var ReinforcementRule = new RawGene(gene.GetRange(Offset + 51, 12).ToArray());
            var ReinforcementSVRule = SVRuleBuilder.Build(SVRuleInterpreter.Interpret(ReinforcementRule));
            var MigrateWhen = gene[Offset + 9];

            var DendriteDynamics = new DendriteDynamicsGene(LTWGainRate, STWGainRate, SusceptibilityRelaxRate, SusceptibilitySVRule, StrengthGain, StrengthSVRule, StrengthLoss, StrengthLossSVRule, ReinforcementSVRule, MigrateWhen);

            Genes.Add(new DendriteGene(i, SourceLobeIndex, Spread, Fanout, DendriteRange, LTWRange, StrengthRange, DendriteDynamics));
        }

        return Genes;
    }
}
