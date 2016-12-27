using UnityEngine;
using System.Collections;
using System;

public class OperationMul : OperationBase
{
    public override float CalculateResult()
    {
        return NumberA * NumberB;
    }
}
