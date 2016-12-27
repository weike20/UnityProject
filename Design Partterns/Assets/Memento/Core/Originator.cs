using UnityEngine;
using System.Collections;

public class Originator
{
    private string state;
    public string State
    {
        get { return state; }
        set { state = value; }
    }

    public Memento CreateMemento()
    {
        return new Memento(state);
    }

    public void SetMemento(Memento memento)
    {
        state = memento.State;
    }

    public void DisplayState()
    {
        Debug.Log("State =" + state);
    }
}
