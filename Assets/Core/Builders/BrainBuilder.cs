using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BrainBuilder {
    public static Brain Build(GameObject go, List<LobeGene> genes)
    {
        Brain Brain = go.AddComponent<Brain>();
        foreach (var LobeGene in genes)
        {
            int NumNeurons0 = 0;
            int NumNeurons1 = 0;
            try
            {
                NumNeurons0 = genes[(int)LobeGene.Dendrite0.SourceLobeIndex].NumNeurons;
                NumNeurons1 = genes[(int)LobeGene.Dendrite1.SourceLobeIndex].NumNeurons;
            }
            catch(Exception e)
            {
                // OK - we have no source lobe - probably from a test
            }
            var Lobe = LobeBuilder.BuildFromGene(LobeGene, NumNeurons0, NumNeurons1);
            Brain.AddLobe(Lobe);
        }
        Brain.SetUpLobes();
        return Brain;
    }
}
