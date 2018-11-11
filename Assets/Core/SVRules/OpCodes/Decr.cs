using System.Collections.Generic;

namespace OpCode
{
    public class Decr : IOpCode
    {

        override public float Evaluate(SVDataPacket data)
        {
            return Children[0].Evaluate(data) - 1;
        }

        override public bool IsOperator()
        {
            return true;
        }

        override public int OperandsRequired()
        {
            return 1;
        }
    }
}