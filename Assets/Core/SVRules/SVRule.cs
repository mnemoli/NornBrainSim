using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpCode;
using UnityEngine.Profiling;

public class SVRule {
     
    public readonly List<IOpCode> OpCodes;
    private Stack<IOpCode> operatorStack = new Stack<IOpCode>(8);
    private Stack<IOpCode> operandStack = new Stack<IOpCode>(8);
    private List<IOpCode> Operands = new List<IOpCode>(3);
    private readonly Result Result = new Result();

    public SVRule(List<IOpCode> opCodes)
    {
        OpCodes = opCodes;
    }

    public float Evaluate(SVDataPacket data)
    {
        operatorStack.Clear();
        operandStack.Clear();
        try
        {
            foreach (var Op in OpCodes)
            {
                if(Op.GetType() == typeof(End))
                {
                    goto FinishStack;
                }
                if (Op.IsOperator())
                {
                    Profiler.BeginSample("operator");
                    operatorStack.Push(Op);

                    if (operatorStack.Count > 0 && operandStack.Count >= operatorStack.Peek().OperandsRequired())
                    {
                        Operands.Clear();
                        for (int i = 0; i < operatorStack.Peek().OperandsRequired(); i++)
                        {
                            Profiler.BeginSample("Adding operands");
                            Operands.Add(operandStack.Pop());
                            Profiler.EndSample();
                        }
                        data.Result = operatorStack.Pop().Evaluate(data, Operands);
                        operandStack.Push(Result);
                    }
                    Profiler.EndSample();
                }
                else
                {
                    Profiler.BeginSample("operand");
                    operandStack.Push(Op);

                    Profiler.BeginSample("Loop");
                    if (operatorStack.Count > 0 && (operandStack.Count >= operatorStack.Peek().OperandsRequired()))
                    {
                        Profiler.BeginSample("Inside loop");
                        Operands.Clear();
                        for (int i = 0; i < operatorStack.Peek().OperandsRequired(); i++)
                        {
                            Profiler.BeginSample("Adding operands");
                            Operands.Add(operandStack.Pop());
                            Profiler.EndSample();
                        }
                        Profiler.EndSample();
                        Profiler.BeginSample("Begin eval");
                        data.Result = operatorStack.Pop().Evaluate(data, Operands);
                        operandStack.Push(Result);
                        Profiler.EndSample();
                    }
                    Profiler.EndSample();
                    Profiler.EndSample();
                }
            }
        }
        catch (EndNoValueException e)
        {
            Profiler.EndSample();
            Profiler.EndSample();
            Profiler.EndSample();
            return 0;
        }
        catch (EndException e)
        {
            Profiler.EndSample();
            Profiler.EndSample();
            Profiler.EndSample();
            return data.Result;
        }

    FinishStack:
        if (operandStack.Count > 0)
        {
            // Get the first result off the stack and use it as the result
            // This will normally be an end operand or a Result
            try
            {
                return operandStack.Pop().Evaluate(data, null);
            }
            catch (EndNoValueException e)
            {
                return 0;
            }
            catch (EndException e)
            {
                return data.Result;
            }
        }
        
        return data.Result;
    }
}
