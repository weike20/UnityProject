using UnityEngine;
using System.Collections;
using System;

public class CashReturn :CashSuperBase
{
    private float cashCondition;
    private float cashReturn;

    public CashReturn(float moneyCondition,float moneyReutrn)
    {
        cashCondition = moneyCondition;
        cashReturn = moneyReutrn;
    }

    public override float CashResult(float money)
    {
        float result = money;
        if (money > cashCondition)
        {
            result = money - Mathf.Floor(money / cashCondition) * cashReturn;
        }
        return result;
    }
}
