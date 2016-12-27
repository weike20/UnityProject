using UnityEngine;
using System.Collections;

public class FacadeDemo : MonoBehaviour
{
    void Start()
    {
        Facade systemFacade = new Facade();
        //用户操作的是外观，而外观操作系统具体接口
        systemFacade.MethodGroupA();
        systemFacade.MethodGroupB();
    }
}
