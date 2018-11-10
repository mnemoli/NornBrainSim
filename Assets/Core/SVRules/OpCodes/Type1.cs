using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace OpCode
{
    public class Type1 : IOpCode
    {

        public float Evaluate(SVDataPacket data, List<IOpCode> operands)
        {
            return data.d1.Sum(d => d.GetValue());
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