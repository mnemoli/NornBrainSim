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
            case OpCodeType._255:
                return new TwoFiveFive();
            case OpCodeType._64:
                return new SixtyFour();
            case OpCodeType.PLUS:
                return new Plus();
            case OpCodeType.end:
                return new End();
            case OpCodeType.DECR:
                return new Decr();
            case OpCodeType.TRUE:
                return new True();
            case OpCodeType.input:
                return new Input();
            case OpCodeType.move_towards:
                return new MoveTowards();
            case OpCodeType.output:
                return new Output();
            case OpCodeType.suscept:
                return new Suscept();
            default:
                throw new NotImplementedException();
        }
        
    }
}
