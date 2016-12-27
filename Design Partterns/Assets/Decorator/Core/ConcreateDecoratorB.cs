using UnityEngine;
using System.Collections;

public class ConcreateDecoratorB :Decorator
{
    public override void Operation()
    {
        base.Operation();
        AddBehavoiur();
        Debug.Log("具体装饰B对象操做");
    }
    private void AddBehavoiur()
    {

    }
}
