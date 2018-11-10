using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuronGene {

    public readonly int Threshold;
    public readonly int RestState;
    public readonly int Leakage;
    public readonly SVRule SVRule;

    public NeuronGene(int threshold, int restState, int leakage, SVRule svRule)
    {
        Threshold = threshold;
        RestState = restState;
        Leakage = leakage;
        SVRule = svRule;
    }
}
