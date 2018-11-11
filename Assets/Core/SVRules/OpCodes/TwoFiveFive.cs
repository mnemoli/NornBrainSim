using System.Collections.Generic;

namespace OpCode
{
    public class TwoFiveFive : IOpCode
    {
        static bool Operator = false;

        override public float Evaluate(SVDataPacket data)
        {
            return 255;
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
