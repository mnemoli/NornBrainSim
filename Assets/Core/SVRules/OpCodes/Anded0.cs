using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace OpCode
{
    public class Anded0 : IOpCode
    {

        public float Evaluate(SVDataPacket data, List<IOpCode> operands)
        {
            if (data.d0.Any(d => d.GetValue() == 0))
            {
                return 0;
            }
            else
            {
                return Mathf.RoundToInt(data.d0.Sum(d => d.GetValue()));
            }
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