using System.Collections.Generic;

namespace OpCode
{
    public class Evaluator : IOpCode
    {
        override public float Evaluate(SVDataPacket data)
        {
            float Result = 0;
            foreach(var Code in Children)
            {
                Result = Code.Evaluate(data);
            }
            return Result;
        }

        override public bool IsOperator()
        {
            return true;
        }

        override public int OperandsRequired()
        {
            return 2;
        }
    }
}