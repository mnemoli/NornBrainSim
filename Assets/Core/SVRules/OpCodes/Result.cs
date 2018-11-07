using System.Collections.Generic;

public class Result : OpCode
{

    public int Evaluate(SVDataPacket data, List<OpCode> operands)
    {
        return data.Result;
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
