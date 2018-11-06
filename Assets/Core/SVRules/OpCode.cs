using System.Collections.Generic;

public interface OpCode
{
    bool IsOperator();
    int OperandsRequired();
    int Evaluate(SVDataPacket data, List<OpCode> operands);
}
