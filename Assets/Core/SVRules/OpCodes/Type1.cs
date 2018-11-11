using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace OpCode
{
    public class Type1 : IOpCode
    {

        override public float Evaluate(SVDataPacket data)
        {
            return data.d1.Sum(d => d.GetValue());
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