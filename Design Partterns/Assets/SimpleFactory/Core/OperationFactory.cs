using UnityEngine;
using System.Collections;

public class OperationFactory  
{
    public OperationBase CreateOperation(string operate)
    {
        OperationBase operation = null;

        switch(operate)
        {
            case "+":
                operation = new OperationAdd();
                break;
            case "-":
                operation = new OperationMinus();
                break;
            case "*":
                operation = new OperationMul();
                break;
            case "/":
                operation = new OperationDivide();
                break;
        }
        return operation;
    }
}
