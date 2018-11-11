using System.Collections.Generic;

namespace OpCode
{
    public class Chem3 : IOpCode
    {
        //For the decision lobe, this is decASH2
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