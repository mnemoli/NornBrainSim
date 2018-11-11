using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace OpCode
{
    public class Type0 : IOpCode
    {

        override public float Evaluate(SVDataPacket data)
        {
            return data.d0.Sum(d => d.GetValue());
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