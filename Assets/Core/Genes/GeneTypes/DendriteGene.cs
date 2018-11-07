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
    public readonly Vector2Int LTWRange;
    public int InitialLTW
    {
        get
        {
            return Random.Range(LTWRange.x, LTWRange.y);
        }
    }
    public readonly Vector2Int StrengthRange;
    public int InitialStrength
    {
        get
        {
            return StrengthRange.x;
        }
    }
    public readonly DendriteDynamicsGene Dynamics;

    public DendriteGene(BrainLobeType sourceLobeIndex, SpreadType spread, Vector2Int dendriteNumber, Vector2Int ltwRange, Vector2Int strengthRange, DendriteDynamicsGene dynamicsGene)
    {
        SourceLobeIndex = sourceLobeIndex;
        Spread = spread;
        DendriteNumber = dendriteNumber;
        LTWRange = ltwRange;
        StrengthRange = strengthRange;
        Dynamics = dynamicsGene;
    }
}
