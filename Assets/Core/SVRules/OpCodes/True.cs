using System.Collections.Generic;
using UnityEngine.Profiling;

namespace OpCode
{
    public class True : IOpCode
    {

        private readonly static EndNoValueException Excpt = new EndNoValueException();

        override public float Evaluate(SVDataPacket data)
        {
            if(Children[0].Evaluate(data) > 0)
            {
                return 1;
            }
            else
            {
                throw Excpt;
            }
        }

        override public bool IsOperator()
        {
            return true;
        }

        override public int OperandsRequired()
        {
            return 1;
        }
    }
}