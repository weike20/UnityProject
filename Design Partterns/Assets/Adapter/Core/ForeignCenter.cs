using UnityEngine;
using System.Collections;
using System;

public class ForeignCenter 
{
    private string name;
    public string Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    public  void 攻击()
    {
        Debug.Log(string.Format("外籍中锋{0}进攻", name));
    }

    public  void 防御()
    {
        Debug.Log(string.Format("外籍中锋{0}防御", name));
    }
}
