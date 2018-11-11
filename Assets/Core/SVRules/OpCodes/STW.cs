using System.Collections.Generic;

namespace OpCode
{
    public class STW : IOpCode
    {

        override public float Evaluate(SVDataPacket data)
        {
            return data.STW;
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