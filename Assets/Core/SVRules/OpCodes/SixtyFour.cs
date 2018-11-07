using System.Collections.Generic;

public class SixtyFour : OpCode
{
    static bool Operator = false;

    public int Evaluate(SVDataPacket data, List<OpCode> operands)
    {
        return 64;
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
