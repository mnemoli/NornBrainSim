using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrainBuilder {
    public static Brain Build(GameObject go, List<LobeGene> genes)
    {
        Brain Brain = go.AddComponent<Brain>();
        foreach (var LobeGene in genes)
        {
            Brain.AddLobe(LobeBuilder.BuildFromGene(LobeGene, Brain));
        }
        return Brain;
    }
}
