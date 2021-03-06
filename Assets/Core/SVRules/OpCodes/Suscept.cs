﻿using System.Collections.Generic;

namespace OpCode
{
    public class Suscept : IOpCode
    {

        override public float Evaluate(SVDataPacket data)
        {
            return data.Susceptibility;
        }

        override public bool IsOperator()
        {
            return false;
        }

        override public int OperandsRequired()
        {
            return 0;
        }
    }
}