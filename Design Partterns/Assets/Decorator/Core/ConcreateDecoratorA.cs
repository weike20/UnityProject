using UnityEngine;
using System.Collections;

public class ConcreateDecoratorA :Decorator
{
    public override void Operation()
    {
        base.Operation();
        AddState();
        Debug.Log("具体装饰A对象操做");
    }
    private void AddState()
    {

    }
}
