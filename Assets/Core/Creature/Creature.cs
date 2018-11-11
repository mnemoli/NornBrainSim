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

    public void AddNoun(int noun)
    {
        Brain.AddNoun((StimulusGenus)noun);
    }

    public void AddVerb(int verb)
    {
        Brain.AddVerb((VerbGenus)verb);
    }

    public void AddDrive(int drive, int amount)
    {
        Brain.AddDrive((DriveGenus)drive, amount);
    }

    public void AddDrive(int drive)
    {
        Brain.AddDrive((DriveGenus)drive, 255);
    }

    public void ToggleLobeRender(int lobeIndex)
    {
        Brain.ToggleRender(lobeIndex);
    }

    public void SetDecision(int decision)
    {
        Brain.SetDecision((VerbGenus)decision, 255);
    }
}
