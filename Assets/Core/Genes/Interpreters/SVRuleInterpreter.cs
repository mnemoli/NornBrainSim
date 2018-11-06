using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SVRuleInterpreter {

	public static SVRuleGene Interpret(RawGene gene)
    {
        List<OpCodeType> OpCodes = new List<OpCodeType>();
        foreach(var Byte in gene)
        {
            OpCodes.Add((OpCodeType)Byte);
        }
        return new SVRuleGene(OpCodes);
    }
}
