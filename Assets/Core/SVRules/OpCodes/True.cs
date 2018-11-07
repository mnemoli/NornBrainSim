using System.Collections.Generic;

public class True : OpCode
{

    public int Evaluate(SVDataPacket data, List<OpCode> operands)
    {
        if(data.Result > 0)
        {
            return data.Result;
        }
        else
        {
            throw new System.Exception("Result not over zero");
        }
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
