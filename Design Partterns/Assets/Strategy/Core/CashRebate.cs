using UnityEngine;
using System.Collections;
using System;

public class CashRebate :CashSuperBase
{
    private float rebate;
    public CashRebate(float _rebate)
    {
        rebate = _rebate;
    }
    public override float CashResult(float money)
    {
        return money * rebate;
    }
}
