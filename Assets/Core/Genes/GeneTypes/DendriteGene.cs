using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DendriteGene : Gene {

    public enum SpreadType { Flat, Normal, Saw, Was }

    public readonly BrainLobeType SourceLobeIndex;
    public readonly SpreadType Spread;
    public readonly Vector2Int DendriteNumber;
    public int NumDendrites
    {
        get
        {
            return Random.Range(DendriteNumber.x, DendriteNumber.y);
        }
    }

    public DendriteGene(BrainLobeType sourceLobeIndex, SpreadType spread, Vector2Int dendriteNumber)
    {
        SourceLobeIndex = sourceLobeIndex;
        Spread = spread;
        DendriteNumber = dendriteNumber;
    }
}
