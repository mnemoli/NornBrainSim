using System.Collections.Generic;

namespace OpCode
{
    public class SixtyFour : IOpCode
    {
        static bool Operator = false;

        public float Evaluate(SVDataPacket data, List<IOpCode> operands)
        {
            return 64;
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