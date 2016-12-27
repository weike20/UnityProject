using UnityEngine;
using System.Collections;
using System;

public class ConcreateFlyweight : Flyweight
{
    public override void Operation(int extrinicState)
    {
        Debug.Log("具体的Flyweight :" + extrinicState);
    }
}
