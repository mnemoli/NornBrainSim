using System.Collections.Generic;
using UnityEngine.Profiling;

namespace OpCode
{
    public class MoveTowards : IOpCode
    {

        override public float Evaluate(SVDataPacket data)
        {
            Profiler.BeginSample("move towards");
            var Op0 = Children[0].Evaluate(data);
            var Op1 = Children[1].Evaluate(data);
            var Op2 = Children[2].Evaluate(data);
            Profiler.EndSample();
            return Op0 + (Op1 - Op0) / (Op1 / Op2);
        }

        override public bool IsOperator()
        {
            return true;
        }

        override public int OperandsRequired()
        {
            return 3;
        }
    }
}