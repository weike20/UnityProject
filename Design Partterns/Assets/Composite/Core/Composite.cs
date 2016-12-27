using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Composite :CompositeComponent
{
    private List<CompositeComponent> children = new List<CompositeComponent>();

    public Composite(string name) : base(name) { }

    public override void Add(CompositeComponent c)
    {
        children.Add(c);
    }
    public override void Remove(CompositeComponent c)
    {
        children.Remove(c);
    }
    public override void Display(int depth)
    {
        Debug.Log(new String('-', depth) + name);
        for(int i = 0 ; i < children.Count ; ++i)
        {
            children[i].Display(depth + 2);
        }
    }
}
