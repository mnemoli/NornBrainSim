using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpCode;
using UnityEngine.Profiling;
using System.Linq;

public class SVRule {
     
    public readonly List<IOpCode> OpCodes;
    public readonly IOpCode Head;

    public SVRule(List<IOpCode> opCodes)
    {
        if(opCodes.First().GetType() == typeof(End))
        {
            Head = opCodes.First();
            return;
        }
        Stack<IOpCode> Operators = new Stack<IOpCode>();
        Stack<IOpCode> Operands = new Stack<IOpCode>();
        Stack<IOpCode> Outputs = new Stack<IOpCode>();

        foreach (var Code in opCodes)
        {
            if(Code.GetType() == typeof(End))
            {
                break;
            }
            if(!Code.IsOperator())
            {
                Operands.Push(Code);
            }
            else
            {
                Operators.Push(Code);
            }
            if(Operators.Count > 0 && Operands.Count >= Operators.Peek().OperandsRequired())
            {
                var Op = Operators.Pop();
                Op.Children = Enumerable.Range(0, Op.OperandsRequired()).Select(i => Operands.Pop()).Reverse().ToList();
                if(Code.GetType() == typeof(True))
                {
                    Outputs.Push(Op);
                }
                else
                {
                    Operands.Push(Op);
                }
            }
        }
        if (Outputs.Count > 0)
        {
            Head = new Evaluator
            {
                Children = Outputs.Concat(Operands).ToList()
            };
        }
        else
        {
             Head = Operands.Pop();
        }
    }

    public float Evaluate(SVDataPacket data)
    {
        if(Head.GetType() == typeof(End))
        {
            return 0;
        }
        try
        {
            return Head.Evaluate(data);
        }
        catch(EndNoValueException)
        {
            return 0;
        }
        
    }
}
