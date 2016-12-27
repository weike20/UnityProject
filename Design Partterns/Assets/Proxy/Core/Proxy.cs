using UnityEngine;
using System.Collections;
using System;

public class Proxy : Subject
{
    private RealSubject realSubject;

    public override void Request()
    {
        if(realSubject ==null)
        {
            realSubject = new RealSubject();   
        }
        Debug.Log("代理请求");
        realSubject.Request();
    }
}
