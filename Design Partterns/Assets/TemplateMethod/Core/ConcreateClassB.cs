using UnityEngine;
using System.Collections;
using System;

public class ConcreateClassB : MClass
{
    public override void PrimitiveOperationA()
    {
        Debug.Log("具体的B类的具体A操做");
    }
    public override void PrimitiveOperationB()
    {
        Debug.Log("具体的B类的具体B操做");
    }
}
