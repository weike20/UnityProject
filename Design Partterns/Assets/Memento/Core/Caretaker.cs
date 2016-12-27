using UnityEngine;
using System.Collections;

public class Caretaker 
{
    private Memento memento;
    public Memento Memento
    {
        get { return memento; }
        set { memento = value; }
    }
}
