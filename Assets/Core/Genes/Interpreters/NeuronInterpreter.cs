using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuronInterpreter
{

    public static NeuronGene Interpret(RawGene gene)
    {
        int Threshold = gene[12];
        int RestState = gene[14];
        int Leakage = gene[13];
        RawGene SVRule = new RawGene(gene.GetRange(16, 12).ToArray());
        var StateRule = SVRuleBuilder.Build(SVRuleInterpreter.Interpret(SVRule));
        return new NeuronGene(Threshold, RestState, Leakage, StateRule);
    }
}
