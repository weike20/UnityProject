using UnityEngine;
using System.Collections;
using System;

public class ConcreateHandler3 : Handler
{
    public override bool HandleRequest(int request)
    {
        if(request>20&&request<=30)
        {
            Debug.Log(string.Format("{0}处理了请求{1}", this.GetType().Name, request));
            return true;
        }
        else if (successor != null)
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
