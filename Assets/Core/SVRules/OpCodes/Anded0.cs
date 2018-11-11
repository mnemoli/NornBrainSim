using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Profiling;

namespace OpCode
{
    public class Anded0 : IOpCode
    {

        override public float Evaluate(SVDataPacket data)
        {
            if (data.d0.Any(d => d.GetValue() == 0))
            {
                return 0;
            }
            else
            {
                var x = data.d0.Sum(d => d.GetValue());
                return x;
            }
        }

        override public bool IsOperator()
        {
            return false;
        }

        override public int OperandsRequired()
        {
            return 0;
        }
    }
}