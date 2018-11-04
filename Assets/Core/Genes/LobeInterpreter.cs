using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobeInterpreter : ScriptableObject {

	public static Lobe LobeFromGene(Gene gene)
    {
        int LobeID = gene[2];
        Vector2Int Location = new Vector2Int(gene[7], gene[8]);
        Vector2Int Dimension = new Vector2Int(gene[9], gene[10]);
        Lobe Lobe = Lobe.CreateNew(LobeID, Location, Dimension);
        return Lobe;
    }

    public static List<Lobe> CreateAllLobes(List<Gene> genes)
    {
        List<Lobe> Lobes = new List<Lobe>();
        foreach(var LobeGene in genes)
        {
            Lobes.Add(LobeFromGene(LobeGene));
        }
        return Lobes;
    }
}
