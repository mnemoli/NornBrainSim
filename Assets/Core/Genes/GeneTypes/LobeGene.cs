using UnityEngine;

public class LobeGene : Gene
{
    public readonly BrainLobeID LobeID;
    public readonly Vector2Int Location;
    public readonly Vector2Int Dimension;
    public readonly DendriteGene Dendrite0;
    public readonly DendriteGene Dendrite1;
    public readonly NeuronGene NeuronGene;
    public int NumNeurons
    {
        get
        {
            return Dimension.x * Dimension.y;
        }
    }
    public readonly bool CopyToPerceptionLobe;
    public readonly bool WinnerTakesAll;

    public LobeGene(
        BrainLobeID lobeID,
        Vector2Int location,
        Vector2Int dimension,
        DendriteGene dendrite0,
        DendriteGene dendrite1,
        NeuronGene neuronGene,
        int copyToPerceptionLobe,
        int winnerTakesAll
        )
    {
        LobeID = lobeID;
        Location = location;
        Dimension = dimension;
        Dendrite0 = dendrite0;
        Dendrite1 = dendrite1;
        NeuronGene = neuronGene;
        CopyToPerceptionLobe = copyToPerceptionLobe == 1 ? true : false;
        WinnerTakesAll = winnerTakesAll == 1 ? true : false;
    }
}
