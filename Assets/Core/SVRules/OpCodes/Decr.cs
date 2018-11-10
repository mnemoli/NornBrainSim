using System.Collections.Generic;

namespace OpCode
{
    public class Decr : IOpCode
    {

        public float Evaluate(SVDataPacket data, List<IOpCode> operands)
        {
            return operands[0].Evaluate(data, null) - 1;
        }

        public bool IsOperator()
        {
            return true;
        }

        public int OperandsRequired()
        {
            return 1;
        }
    }
}