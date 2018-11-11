using System.Collections.Generic;

namespace OpCode
{
    public class SixtyFour : IOpCode
    {
        static bool Operator = false;

        override public float Evaluate(SVDataPacket data)
        {
            return 64;
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