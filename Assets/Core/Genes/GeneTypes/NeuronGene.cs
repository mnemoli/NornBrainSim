using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeuronGene {

    public readonly int Threshold;
    public readonly int RestState;

    public NeuronGene(int threshold, int restState)
    {
        Threshold = threshold;
        RestState = restState;
    }
}
