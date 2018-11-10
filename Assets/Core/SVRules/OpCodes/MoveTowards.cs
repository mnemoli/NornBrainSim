using System.Collections.Generic;
using UnityEngine.Profiling;

namespace OpCode
{
    public class MoveTowards : IOpCode
    {

        public float Evaluate(SVDataPacket data, List<IOpCode> operands)
        {
            Profiler.BeginSample("move towards");
            var Op0 = operands[0].Evaluate(data, null);
            var Op1 = operands[1].Evaluate(data, null);
            var Op2 = operands[2].Evaluate(data, null);
            Profiler.EndSample();
            return Op0 + (Op1 - Op0) / (Op1 / Op2);
        }

        public bool IsOperator()
        {
            return true;
        }

        public int OperandsRequired()
        {
            return 3;
        }
    }
}