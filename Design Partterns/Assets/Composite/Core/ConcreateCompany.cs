using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class ConcreateCompany :Company 
{
    private List<Company> children = new List<Company>();
    public ConcreateCompany(string name) : base(name) { }

    public override void Add(Company c)
    {
        children.Add(c);
    }

    public override void Remove(Company c)
    {
        children.Remove(c);
    }

    public override void Display(int depth)
    {
        Debug.Log(new String('-', depth) + name);
        for(int i=0;i<children.Count;++i)
        {
            children[i].Display(depth + 2);
        }
    }

    public override void LineOfDuty()
    {
        for(int i=0;i<children.Count;++i)
        {
            children[i].LineOfDuty();
        }
    }

}
