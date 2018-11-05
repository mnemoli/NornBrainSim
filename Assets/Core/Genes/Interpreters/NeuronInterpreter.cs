using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuronInterpreter
{

    public static NeuronGene Interpret(RawGene gene)
    {
        int Threshold = gene[12];
        int RestState = gene[14];
        return new NeuronGene(Threshold, RestState);
    }
}
