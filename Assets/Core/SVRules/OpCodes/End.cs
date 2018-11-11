using System.Collections.Generic;

namespace OpCode
{
    public class End : IOpCode
    {
        private readonly static EndException Excpt = new EndException();
        override public float Evaluate(SVDataPacket data)
        {
            throw Excpt;
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