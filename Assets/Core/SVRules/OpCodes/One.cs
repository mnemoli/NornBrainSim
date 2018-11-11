using System.Collections.Generic;

namespace OpCode
{
    public class One : IOpCode
    {

        override public float Evaluate(SVDataPacket data)
        {
            return 1;
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