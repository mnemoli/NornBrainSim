using System.Collections.Generic;

namespace OpCode
{
    public class State : IOpCode
    {

        override public float Evaluate(SVDataPacket data)
        {
            return data.State;
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