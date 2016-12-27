using UnityEngine;
using System.Collections;

public abstract class CompositeComponent
{
    protected string name;

    public CompositeComponent(string name)
    {
        this.name = name;
    }

    public abstract void Add(CompositeComponent c);
    public abstract void Remove(CompositeComponent c);
    public abstract void Display(int depth);

}
