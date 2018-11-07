using System.Collections.Generic;

public class True : OpCode
{

    public int Evaluate(SVDataPacket data, List<OpCode> operands)
    {
        if(data.Result > 0)
        {
            return operands[0].Evaluate(data, null);
        }
        else
        {
            throw new EndNoValueException();
        }
    }

    public bool IsOperator()
    {
        return true;
    }

    public int OperandsRequired()
    {
        return 1;
    }
}
