using System.Collections.Generic;

namespace OpCode
{
    public class Zero : IOpCode
    {

        static bool Operator = false;

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
