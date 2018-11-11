using System.Collections.Generic;

namespace OpCode
{
    public class Chem5 : IOpCode
    {

        override public float Evaluate(SVDataPacket data)
        {
            //TODO
            return 0;
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