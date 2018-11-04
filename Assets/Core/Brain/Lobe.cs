using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobe : ScriptableObject {

    private int LobeID;
    public Vector2Int Location { get; private set; }
    public Vector2Int Dimension { get; private set; }

    public static Lobe CreateNew(int lobeID, Vector2Int location, Vector2Int dimension)
    {
        Lobe Lobe = ScriptableObject.CreateInstance<Lobe>();
        Lobe.Init(lobeID, location, dimension);
        return Lobe;
    }

    private void Init(int lobeID, Vector2Int location, Vector2Int dimension)
    {
        this.LobeID = lobeID;
        this.Location = location;
        this.Dimension = dimension;
    }
}
