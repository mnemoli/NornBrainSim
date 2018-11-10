using OpCode;
using System;
using UnityEngine;

public class OpCodeFactory  {
    public static IOpCode Build(OpCodeType type)
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
                return new OpCode.Input();
            case OpCodeType.move_towards:
                return new MoveTowards();
            case OpCodeType.output:
                return new Output();
            case OpCodeType.suscept:
                return new Suscept();
            case OpCodeType.random:
                return new OpCode.Random();
            case OpCodeType.chem5:
                return new Chem5();
            case OpCodeType.anded0:
                return new Anded0();
            case OpCodeType.MINUS:
                return new Minus();
            case OpCodeType.state:
                return new State();
            case OpCodeType.type0:
                return new Type0();
            case OpCodeType.type1:
                return new Type1();
            default:
                throw new NotImplementedException();
        }
        
    }
}
