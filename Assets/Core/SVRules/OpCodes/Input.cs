using System.Collections.Generic;
using System.Linq;

namespace OpCode
{
    public class Input : IOpCode
    {

        public float Evaluate(SVDataPacket data, List<IOpCode> operands)
        {
            bool d0 = false;
            bool d1 = false;
            if(data.d0 != null)
            {
                d0 = data.d0.Any(d => d.GetValue() > 0);
            }
            if (data.d1 != null)
            {
                d1 = data.d1.Any(d => d.GetValue() > 0);
            }
            return (d0 || d1) ? 1 : 0;
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