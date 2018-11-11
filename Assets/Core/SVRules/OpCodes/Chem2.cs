using System.Collections.Generic;

namespace OpCode
{
    public class Chem2 : IOpCode
    {
        //For the decision lobe, this is decASH1
        //Which helps the decision dendrites decay constantly

        override public float Evaluate(SVDataPacket data)
        {
            //TODO
            return 1;
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