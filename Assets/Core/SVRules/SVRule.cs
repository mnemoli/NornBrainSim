using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SVRule {

    public readonly List<OpCode> OpCodes;

    public SVRule(List<OpCode> opCodes)
    {
        OpCodes = opCodes;
    }

    public int Evaluate(SVDataPacket data)
    {
        Stack<OpCode> operatorStack = new Stack<OpCode>();
        Stack<OpCode> operandStack = new Stack<OpCode>();

        foreach(var Op in OpCodes)
        {
            if(Op.IsOperator())
            {
                operatorStack.Push(Op);

                if (operatorStack.Count > 0 && operandStack.Count >= operatorStack.Peek().OperandsRequired())
                {
                    var Operands = new List<OpCode>();
                    for (int i = 0; i < operatorStack.Peek().OperandsRequired(); i++)
                    {
                        Operands.Add(operandStack.Pop());
                    }
                    data.Output = operatorStack.Pop().Evaluate(data, Operands);
                    operandStack.Push(new Output());
                }
            }
            else
            {
                operandStack.Push(Op);

                if(operatorStack.Count > 0 && operatorStack.Peek().OperandsRequired() >= operandStack.Count)
                {
                    var Operands = new List<OpCode>();
                    for(int i = 0; i < operatorStack.Peek().OperandsRequired(); i++)
                    {
                        Operands.Add(operandStack.Pop());
                    }
                    data.Output = operatorStack.Pop().Evaluate(data, Operands);
                    operandStack.Push(new Output());
                }
            }
        }
        return data.Output;
    }
}
