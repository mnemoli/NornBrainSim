using System.Collections.Generic;

public class Decr : OpCode
{

    public int Evaluate(SVDataPacket data, List<OpCode> operands)
    {
        return operands[0].Evaluate(data, null) - 1;
    }

    public bool IsOperator()
    {
        return true;
    }

    public int OperandsRequired()
    {
        return 1;
    }
}
