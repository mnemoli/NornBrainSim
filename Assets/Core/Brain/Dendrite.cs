using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dendrite  {
    public Lobe SourceLobe;
    public readonly BrainLobeType SourceLobeIndex;
    public readonly int SourceNeuronIndex;

    public Dendrite(BrainLobeType sourceLobeIndex, int sourceNeuronIndex)
    {
        SourceLobeIndex = sourceLobeIndex;
        SourceNeuronIndex = sourceNeuronIndex;
    }
}
