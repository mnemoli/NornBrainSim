using System.Collections.Generic;

public class Plus : OpCode
{

    public int Evaluate(SVDataPacket data, List<OpCode> operands)
    {
        return operands[0].Evaluate(data, null) + operands[1].Evaluate(data, null);
    }

    public bool IsOperator()
    {
        return true ;
    }

    public int OperandsRequired()
    {
        return 2;
    }
}
