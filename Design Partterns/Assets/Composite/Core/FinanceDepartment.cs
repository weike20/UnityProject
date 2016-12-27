using UnityEngine;
using System.Collections;
using System;

public class FinanceDepartment :Company
{
    public FinanceDepartment(string name) : base(name) { }

    public override void Add(Company c)
    {
       
    }
    public override void Remove(Company c)
    {
        
    }
    public override void Display(int depth)
    {
        Debug.Log(new String('-', depth) + name);
    }
    public override void LineOfDuty()
    {
        Debug.Log(string.Format("{0}公司财务收支管理",name));
    }
}
