using System.Collections.Generic;

namespace OpCode
{
    public class Suscept : IOpCode
    {

        public float Evaluate(SVDataPacket data, List<IOpCode> operands)
        {
            return data.Susceptibility;
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