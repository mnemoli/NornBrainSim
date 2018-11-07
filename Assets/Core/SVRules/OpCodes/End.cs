using System.Collections.Generic;

public class End : OpCode
{

    public int Evaluate(SVDataPacket data, List<OpCode> operands)
    {
        throw new EndException();
    }

    public bool IsOperator()
    {
        return false;
    }

    public int OperandsRequired()
    {
        return 0;
    }
}
