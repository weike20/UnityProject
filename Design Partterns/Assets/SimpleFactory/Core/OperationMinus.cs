using UnityEngine;
using System.Collections;
using System;

public class OperationMinus : OperationBase
{
    public override float CalculateResult()
    {
        return NumberA - NumberB;
    }
}
