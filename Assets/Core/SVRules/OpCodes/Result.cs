using System.Collections.Generic;

namespace OpCode
{
    public class Result : IOpCode
    {

        public float Evaluate(SVDataPacket data, List<IOpCode> operands)
        {
            return data.Result;
        }

        public bool IsOperator()
        {
            return false;
        }

        public int OperandsRequired()
        {
            return 0;
        }
    }
}