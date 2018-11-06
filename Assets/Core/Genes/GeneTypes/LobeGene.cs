using UnityEngine;

public class LobeGene : Gene
{
    public readonly BrainLobeType LobeID;
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

    public LobeGene(BrainLobeType lobeID, Vector2Int location, Vector2Int dimension, DendriteGene dendrite0, DendriteGene dendrite1, NeuronGene neuronGene)
    {
        LobeID = lobeID;
        Location = location;
        Dimension = dimension;
        Dendrite0 = dendrite0;
        Dendrite1 = dendrite1;
        NeuronGene = neuronGene;
    }
}
