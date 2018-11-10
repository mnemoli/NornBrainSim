using System.Collections.Generic;

namespace OpCode
{
    public class Zero : IOpCode
    {

        static bool Operator = false;

        public int Evaluate(SVDataPacket data, List<IOpCode> operands)
        {
            return 0;
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
