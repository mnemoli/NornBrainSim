using System.Collections.Generic;

namespace OpCode
{
    public class Chem0 : IOpCode
    {

        override public float Evaluate(SVDataPacket data)
        {
            //TODO
            return 0;
        }

        public override bool IsOperator()
        {
            return false;
        }

        override public int OperandsRequired()
        {
            return 0;
        }
    }
}