using System.Collections.Generic;

namespace OpCode
{
    public class Output : IOpCode
    {

        override public float Evaluate(SVDataPacket data)
        {
            return data.NeuronOutput;
        }

        override public bool IsOperator()
        {
            return false;
        }

        override public int OperandsRequired()
        {
            return -1;
        }
    }
}