using System.Collections.Generic;

public class TwoFiveFive : OpCode
{
    static bool Operator = false;

    public int Evaluate(SVDataPacket data, List<OpCode> operands)
    {
        return 255;
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
