using UnityEngine;
using System.Collections;
using System;

public class CashNormal : CashSuperBase
{
    public override float CashResult(float money)
    {
        return money;
    }
}
