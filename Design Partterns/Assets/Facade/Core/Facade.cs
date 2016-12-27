using UnityEngine;
using System.Collections;


/*
 * MVC之间接口交互可以使用外观模式这样使得交互的耦合度更低
 * 外观模式是操作接口和将接口抽象上升到基类是不一样的
 */
public class Facade 
{
    SubSystemOne one;
    SubSystemTwo two;
    SubSystemThree three;
    SubSystemFour four;

    public Facade()
    {
        one = new SubSystemOne();
        two = new SubSystemTwo();
        three = new SubSystemThree();
        four = new SubSystemFour();
    }
    public void MethodGroupA()
    {
        Debug.Log("方法组A");
        one.MethodOne();
        two.MethodTwo();
        three.MethodThree();
    }
    public void MethodGroupB()
    {
        Debug.Log("方法组B");
        two.MethodTwo();
        four.MethodFour();
    }
}
