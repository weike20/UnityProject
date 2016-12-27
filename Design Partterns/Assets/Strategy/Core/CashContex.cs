using UnityEngine;
using System.Collections;

public class CashContex 
{
    CashSuperBase cashSuper = null;
    public CashContex(string type)
    {
        switch(type)
        {
            case "正常收费":
                cashSuper = new CashNormal();
                break;
            case "满300返100":
                cashSuper = new CashReturn(300, 100);
                break;
            case "打8折":
                cashSuper = new CashRebate(0.8f);
                break;
        }
    }
    public float GetResult(float money)
    {
        return cashSuper.CashResult(money);
    }
}
