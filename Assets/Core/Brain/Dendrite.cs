using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dendrite  {
    private readonly Lobe SourceLobe;
    public readonly int SourceNeuronIndex;

    public Dendrite(Lobe sourceLobe, int sourceNeuronIndex)
    {
        SourceLobe = sourceLobe;
        SourceNeuronIndex = sourceNeuronIndex;
    }
}
