using System.Collections.Generic;

namespace OpCode
{
    public class End : IOpCode
    {
        override public float Evaluate(SVDataPacket data)
        {
            return 0;
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