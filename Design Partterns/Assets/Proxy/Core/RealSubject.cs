using UnityEngine;
using System.Collections;
using System;

public class RealSubject : Subject
{
    public override void Request()
    {
        Debug.Log("真实的请求");
    }
}
