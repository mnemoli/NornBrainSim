using System.Collections.Generic;

public class Zero : OpCode {

    static bool Operator = false;

    public int Evaluate(SVDataPacket data, List<OpCode> operands)
    {
        return 0;
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
