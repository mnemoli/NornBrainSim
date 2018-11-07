using System.Collections.Generic;

public class MoveTowards : OpCode
{

    public int Evaluate(SVDataPacket data, List<OpCode> operands)
    {
        var Op0 = operands[0].Evaluate(data, null);
        var Op1 = operands[1].Evaluate(data, null);
        var Op2 = operands[2].Evaluate(data, null);
        return Op0 + (Op1 - Op0) / (Op1 / Op2);
    }

    public bool IsOperator()
    {
        return true;
    }

    public int OperandsRequired()
    {
        return 3;
    }
}
