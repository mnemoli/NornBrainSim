using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Creatures;
using System.Linq;

public class Creature : MonoBehaviour {

    public string GeneFilePath = "F:\\Jade\\Documents\\Unity Projects\\BrainSim2\\Assets\\Genes\\norn.gen";

	// Use this for initialization
	void Start () {
        var RawGenes = GeneFileLoader.LoadGenes(GeneFilePath);
        var Genes = RawGenes.Select(g => GeneFactory.InterpretGene(g));
        var x = Genes.ToList();
        var LobeGenes = x.OfType<LobeGene>().ToList();
        BrainBuilder.Build(this.gameObject, LobeGenes);
	}
}
