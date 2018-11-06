using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SVRuleGene {
    public readonly List<OpCodeType> OpCodes;

    public SVRuleGene(List<OpCodeType> opCodes)
    {
        OpCodes = opCodes;
    }
}
