using System.Collections.Generic;

namespace OpCode
{
    public class Chem0 : IOpCode
    {

        public float Evaluate(SVDataPacket data, List<IOpCode> operands)
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