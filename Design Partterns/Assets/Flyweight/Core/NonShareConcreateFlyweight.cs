using UnityEngine;
using System.Collections;
using System;

public class NonShareConcreateFlyweight : Flyweight
{
    public override void Operation(int extrinicState)
    {
        Debug.Log("不共享具体的Flyweight: " + extrinicState);
    }
}
