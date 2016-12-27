using UnityEngine;
using System.Collections;

public class Director 
{
    public void Construct(Builder builder)
    {
        builder.BuildPartA();
        builder.BuildPartB();
    }
}
