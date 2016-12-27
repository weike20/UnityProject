using UnityEngine;
using System.Collections;
using System;

public class ConcreateHandler1 : Handler
{
    public override bool HandleRequest(int request)
    {
        if(request>=0 && request<=10)
        {
            Debug.Log(string.Format("{0}处理了请求{1}", this.GetType().Name, request));
            return true;
        }
        else if(successor != null)
        {
            return successor.HandleRequest(request);
        }
        else
        {
            Debug.Log("上级为空");
            return false;
        }
    }
}
