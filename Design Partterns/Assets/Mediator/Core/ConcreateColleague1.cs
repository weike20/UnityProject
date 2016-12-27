using UnityEngine;
using System.Collections;

public class ConcreateColleague1 : Colleague
{
    public ConcreateColleague1(Mediator mediator) : base(mediator) { }

    public void Send(string message)
    {
        mediator.Send(message, this);
    }
    public void Notify(string message)
    {
        Debug.Log("同事1得到通知：" + message);
    }
}
