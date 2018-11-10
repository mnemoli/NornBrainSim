using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace OpCode
{
    public class Type0 : IOpCode
    {

        public int Evaluate(SVDataPacket data, List<IOpCode> operands)
        {
            return Mathf.RoundToInt(data.d0.Sum(d => d.GetValue()));
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