using System.Collections.Generic;

namespace OpCode
{
    public class State : IOpCode
    {

        public int Evaluate(SVDataPacket data, List<IOpCode> operands)
        {
            return data.State;
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