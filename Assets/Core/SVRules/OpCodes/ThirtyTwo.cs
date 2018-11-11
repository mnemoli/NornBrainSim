using System.Collections.Generic;

namespace OpCode
{
    public class ThirtyTwo : IOpCode
    {
        static bool Operator = false;

        override public float Evaluate(SVDataPacket data)
        {
            return 32;
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