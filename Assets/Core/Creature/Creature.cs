using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Creature : MonoBehaviour {

    public string GeneFilePath = "F:\\Jade\\Documents\\Unity Projects\\BrainSim2\\Assets\\Genes\\norn.gen";
    private Brain Brain;

	// Use this for initialization
	void Start () {
        var RawGenes = GeneFileLoader.LoadGenes(GeneFilePath);
        var Genes = RawGenes.Select(g => GeneFactory.InterpretGene(g));
        var x = Genes.ToList();
        var LobeGenes = x.OfType<LobeGene>().ToList();
        Brain = BrainBuilder.Build(this.gameObject, LobeGenes);
	}

    public void AddStimulus(int stimulus)
    {
        Brain.AddStimulus((StimulusGenus)stimulus);
    }
}
