using System.Collections.Generic;
using UnityEngine.Profiling;

namespace OpCode
{
    public class True : IOpCode
    {
        override public float Evaluate(SVDataPacket data)
        {
            if(Children[0].Evaluate(data) > 0)
            {
                return Children[1].Evaluate(data);
            }
            else
            {
                return 0;
            }
        }

        override public bool IsOperator()
        {
            return true;
        }

        override public int OperandsRequired()
        {
            return 2;
        }
    }
}