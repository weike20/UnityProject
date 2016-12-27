using UnityEngine;
using System.Collections;
using System;

public class ConcreateClassA :MClass
{
    public override void PrimitiveOperationA()
    {
        Debug.Log("具体的A类的具体A实现");
    }
    public override void PrimitiveOperationB()
    {
        Debug.Log("具体的B类的具体B实现");
    }

}
