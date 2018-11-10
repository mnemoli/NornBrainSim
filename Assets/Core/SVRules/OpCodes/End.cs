using System.Collections.Generic;

namespace OpCode
{
    public class End : IOpCode
    {
        private readonly static EndException Excpt = new EndException();
        public float Evaluate(SVDataPacket data, List<IOpCode> operands)
        {
            throw Excpt;
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