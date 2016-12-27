using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ConcreateMediator : Mediator
{
    private ConcreateColleague1 colleague1;
    private ConcreateColleague2 colleague2;


    public ConcreateColleague1 Colleague1
    {
        set { colleague1 = value; }
    }
    public ConcreateColleague2 Colleague2
    {
        set { colleague2 = value; }
    }

    public override void Send(string message,Colleague colleague)
    {
        if(colleague == colleague1)
        {
            Debug.Log("同事1发送消息");
            colleague2.Notify(message);
        }
        else
        {
            Debug.Log("同事2发送消息");
            colleague1.Notify(message);
        }
    }
}
