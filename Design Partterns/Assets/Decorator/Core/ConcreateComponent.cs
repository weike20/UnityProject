using UnityEngine;
using System.Collections;
using System;

public class ConcreateComponent :MComponent
{
    public override void Operation()
    {
        Debug.Log("对象具体的操做");
    }
}
