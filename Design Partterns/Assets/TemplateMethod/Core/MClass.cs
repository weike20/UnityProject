using UnityEngine;
using System.Collections;

public abstract class MClass 
{
    /*将相同的东西升到基类处理*/
    public void TemplateMethod()
    {
        PrimitiveOperationA();
        PrimitiveOperationB();
    }

    /*将具体不同的变化的东西，降到子类处理*/
    public abstract void PrimitiveOperationA();
    public abstract void PrimitiveOperationB();

}
