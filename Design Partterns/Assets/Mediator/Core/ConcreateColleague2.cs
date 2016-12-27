using UnityEngine;
using System.Collections;

public class ConcreateColleague2 : Colleague
{
    public ConcreateColleague2(Mediator mediator) : base(mediator) { }

    public void Send(string message)
    {
        mediator.Send(message, this);
    }

    public void Notify(string message)
    {
        Debug.Log("同事2得到通知：" + message);
    }
}
