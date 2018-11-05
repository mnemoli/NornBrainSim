using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour {
    private Dictionary<BrainLobeType, Lobe> Lobes = new Dictionary<BrainLobeType, Lobe>();
    public int NumLobes
    {
        get
        {
            return Lobes.Count;
        }
    }

    public virtual Lobe LobeFromIndex(BrainLobeType index)
    {
        return Lobes[index];
    }

    public void AddLobe(Lobe lobe)
    {
        Lobes.Add(lobe.LobeID, lobe);
    }

    public void AddStimulus(StimulusGenus stimulus)
    {
        Lobes[BrainLobeType.StimulusSource].FireNeuron((int)stimulus);
    }

    public StimulusGenus GetHighestStimulus()
    {
        return (StimulusGenus)Lobes[BrainLobeType.StimulusSource].GetFiringNeuron().Index;
    }

    public void OnGUI()
    {
        foreach (var Record in Lobes)
        {
            LobeRenderer.Render(Record.Value.Location, Record.Value.Dimension);
        }
    }
}
