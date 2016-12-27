using UnityEngine;
using System.Collections;
using System;

public class OperationDivide : OperationBase
{
    public override float CalculateResult()
    {
        return NumberA / NumberB;
    }

}
