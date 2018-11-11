using System.Collections.Generic;

namespace OpCode
{
    public class Result : IOpCode
    {

        override public float Evaluate(SVDataPacket data)
        {
            return data.Result;
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