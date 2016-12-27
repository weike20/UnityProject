using UnityEngine;
using System.Collections;
using System;

public class Leaf : CompositeComponent
{
    public Leaf(string name) : base(name) { }

    public override void Add(CompositeComponent c)
    {
        Debug.Log("Can not add to a leaf ");
    }
    public override void Remove(CompositeComponent c)
    {
        Debug.Log("Can not remove from leaf");
    }
    public override void Display(int depth)
    {
        Debug.Log(new String('-', depth) + name);
    }
}
