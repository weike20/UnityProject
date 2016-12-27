using UnityEngine;
using System.Collections;
using System;

public class OperationAdd :OperationBase
{
    public override float CalculateResult()
    {
        return NumberA + NumberB;
    }
}
