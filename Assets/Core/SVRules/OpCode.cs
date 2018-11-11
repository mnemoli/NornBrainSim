using System.Collections.Generic;

namespace OpCode
{
    public abstract class IOpCode
    {
        public List<IOpCode> Children;
        
        public abstract bool IsOperator();
        public abstract int OperandsRequired();
        public abstract float Evaluate(SVDataPacket data);
    }
}