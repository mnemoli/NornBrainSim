using System.Linq;

public class SVRuleBuilder {

	public static SVRule Build(SVRuleGene gene)
    {
        var OpCodes = gene.OpCodes.Select(t => OpCodeFactory.Build(t)).ToList();
        return new SVRule(OpCodes);
    }
}
