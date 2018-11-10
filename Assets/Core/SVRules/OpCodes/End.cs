﻿using System.Collections.Generic;

namespace OpCode
{
    public class End : IOpCode
    {

        public float Evaluate(SVDataPacket data, List<IOpCode> operands)
        {
            throw new EndException();
        }

        public bool IsOperator()
        {
            return false;
        }

        public int OperandsRequired()
        {
            return 0;
        }
    }
}