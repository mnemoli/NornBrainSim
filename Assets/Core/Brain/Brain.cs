using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Brain : MonoBehaviour {
    private List<Lobe> Lobes = new List<Lobe>();
    private List<Lobe> RenderableLobes;
    public int NumLobes
    {
        get
        {
            return Lobes.Count;
        }
    }

    public void FixedUpdate()
    {
        Lobes.ForEach(l => l.Process());
        AddDrive(DriveGenus.Pain, 255);
    }

    public virtual Lobe LobeFromIndex(BrainLobeType index)
    {
        return Lobes[(int)index];
    }

    public void SetUpLobes()
    {
        var PerceptionLobe = Lobes[0];
        int OffsetIntoPerceptionLobe = 0;

        foreach (var Lobe in Lobes)
        {
            if(Lobe.CopyToPerceptionLobe)
            {
                Lobe.SetUpPerceptionLobeLink(OffsetIntoPerceptionLobe, PerceptionLobe);
                OffsetIntoPerceptionLobe += Lobe.NumNeurons;
            }
            Lobe.SetUpDendrites(this);
        }
        RenderableLobes = new List<Lobe>(Lobes);
    }

    public void AddLobe(Lobe lobe)
    {
        Lobes.Add(lobe);
    }

    public void AddStimulus(StimulusGenus stimulus)
    {
        Lobes[(int)BrainLobeType.StimulusSource].CopyToNeuron((int)stimulus);
    }

    public void SetDecision(VerbGenus decision, int amount)
    {
        Lobes[(int)BrainLobeType.Decision].FireNeuron((int)decision);
    }

    public void AddNoun(StimulusGenus noun)
    {
        Lobes[(int)BrainLobeType.Noun].FireNeuron((int)noun);
    }

    public void AddVerb(VerbGenus verb)
    {
        Lobes[(int)BrainLobeType.Verb].FireNeuron((int)verb);
    }

    public void AddDrive(DriveGenus drive, int amount)
    {
        Lobes[(int)BrainLobeType.Drive].FireNeuron((int)drive, amount);
    }

    public StimulusGenus GetHighestStimulus()
    {
        return (StimulusGenus)Lobes[(int)BrainLobeType.StimulusSource].GetFiringNeuron().Index;
    }

    public void OnGUI()
    {
        foreach (var Record in Lobes)
        {
            Record.Render();
        }
    }

    public void OnRenderObject()
    {
        foreach (var Record in RenderableLobes)
        {
            Record.RenderDendrites();
        }
    }

    public void ToggleRender(int LobeIndex)
    {
        var Lobe = Lobes[LobeIndex];
        if (RenderableLobes.Contains(Lobe))
        {
            RenderableLobes.Remove(Lobe);
        }
        else
        {
            RenderableLobes.Add(Lobe);
        }
    }
}
