using UnityEngine;
using System.Collections;
using System;

public class Boss : InterfaceSubject
{
    public delegate void EventHandler();
    public event EventHandler Update;

    private string action;

    public string SubjectState
    {
        get
        {
            return action;
        }
  
        set
        {
            action = value;
        }
    }

    public void Notify()
    {
        if(Update != null)
        {
            Update();
        }
    }

}
