using System.Collections.Generic;

namespace OpCode
{
    public class Random : IOpCode
    {

        override public float Evaluate(SVDataPacket data)
        {
            return UnityEngine.Random.Range(Children[0].Evaluate(data), Children[1].Evaluate(data));
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