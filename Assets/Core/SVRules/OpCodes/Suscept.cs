using System.Collections.Generic;

public class Suscept : OpCode
{

    public int Evaluate(SVDataPacket data, List<OpCode> operands)
    {
        return data.Susceptibility;
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
