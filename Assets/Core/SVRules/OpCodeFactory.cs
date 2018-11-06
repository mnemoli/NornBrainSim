using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpCodeFactory  {
    public static OpCode Build(OpCodeType type)
    {
        switch(type)
        {
            case OpCodeType._0:
                return new Zero();
            case OpCodeType._32:
                return new ThirtyTwo();
            case OpCodeType.PLUS:
                return new Plus();
            default:
                throw new NotImplementedException();
        }
        
    }
}
