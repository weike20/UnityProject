using UnityEngine;
using System.Collections;

public class CashSuperDemo : MonoBehaviour
{
    CashContex rebate = new CashContex("打8折");
    CashContex moneyReturn = new CashContex("满300返100");
    CashContex normal = new CashContex("正常收费");
    void Start()
    {
        float result = rebate.GetResult(10000);
        Debug.Log("打八折："+result);
        result = moneyReturn.GetResult(10000);
        Debug.Log("返现： " + result);
        result = normal.GetResult(10000);
        Debug.Log("正常：" + result);

    }
}
