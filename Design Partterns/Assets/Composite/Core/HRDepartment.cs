using UnityEngine;
using System.Collections;
using System;

public class HRDepartment : Company
{
    public HRDepartment(string name) : base(name) { }

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
        Debug.Log(string.Format("{0}员工招聘培训管理", name));
    }
}
