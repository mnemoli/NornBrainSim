using System.Collections.Generic;

public class Input : OpCode
{

    public int Evaluate(SVDataPacket data, List<OpCode> operands)
    {
        return data.NeuronInput;
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
