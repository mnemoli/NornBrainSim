using System.Collections.Generic;
using System.Linq;

namespace OpCode
{
    public class Input : IOpCode
    {

        public float Evaluate(SVDataPacket data, List<IOpCode> operands)
        {
            return data.d0.Any(d => d.GetValue() > 0) || data.d1.Any(d => d.GetValue() > 0) ? 1 : 0;
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