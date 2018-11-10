using System.Collections.Generic;
using UnityEngine;

public class LobeInterpreter {

	public static LobeGene Interpret(RawGene gene)
    {
        BrainLobeID LobeID = (BrainLobeID)gene[2];
        Vector2Int Location = new Vector2Int(gene[7], gene[8]);
        Vector2Int Dimension = new Vector2Int(gene[9], gene[10]);
        int CopyToPerceptionLobe = gene[11];
        int WinnerTakesAll = gene[28];
        var Dendrites = GetDendrites(gene);
        var Neuron = GetNeuron(gene);
        return new LobeGene(LobeID, Location, Dimension, Dendrites[0], Dendrites[1], Neuron, CopyToPerceptionLobe, WinnerTakesAll);
    }

    private static List<DendriteGene> GetDendrites(RawGene gene)
    {
        return DendriteInterpreter.Interpret(gene);
    }

    private static NeuronGene GetNeuron(RawGene gene)
    {
        return NeuronInterpreter.Interpret(gene);
    }
}
