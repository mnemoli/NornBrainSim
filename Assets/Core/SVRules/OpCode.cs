using System.Collections.Generic;

namespace OpCode
{
    public interface IOpCode
    {
        bool IsOperator();
        int OperandsRequired();
        int Evaluate(SVDataPacket data, List<IOpCode> operands);
    }
}