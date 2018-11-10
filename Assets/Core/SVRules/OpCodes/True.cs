using System.Collections.Generic;
using UnityEngine.Profiling;

namespace OpCode
{
    public class True : IOpCode
    {

        private readonly static EndNoValueException Excpt = new EndNoValueException();

        public float Evaluate(SVDataPacket data, List<IOpCode> operands)
        {
            Profiler.BeginSample("True");
            if(operands[0].Evaluate(data, null) > 0)
            {
                Profiler.EndSample();
                return operands[1].Evaluate(data, null);
            }
            else
            {
                Profiler.EndSample();
                throw Excpt;
            }
        }

        public bool IsOperator()
        {
            return true;
        }

        public int OperandsRequired()
        {
            return 2;
        }
    }
}