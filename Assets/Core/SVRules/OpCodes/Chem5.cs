using System.Collections.Generic;

namespace OpCode
{
    public class Chem5 : IOpCode
    {

        public int Evaluate(SVDataPacket data, List<IOpCode> operands)
        {
            //TODO
            return 0;
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