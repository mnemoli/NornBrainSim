using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GeneFactory {

    public static Gene InterpretGene(RawGene rawGene)
    {
        var GeneTypes = new
        {
            BrainLobe = new byte[] { 0x0, 0x0 }
        };

        byte[] GeneType = { rawGene[0], rawGene[1] };

        if (GeneType.SequenceEqual(GeneTypes.BrainLobe))
        {
            return LobeInterpreter.Interpret(rawGene);
        }
        else
        {
            return null;
        }
    }
}
