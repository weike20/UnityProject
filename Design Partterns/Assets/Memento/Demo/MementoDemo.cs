using UnityEngine;
using System.Collections;

public class MementoDemo : MonoBehaviour
{

    //备忘录可以和命令模式一起使用

    void Start()
    {
        Originator originator = new Originator();
        originator.State = "On";
        originator.DisplayState();

        Caretaker caretaker = new Caretaker();
        caretaker.Memento = originator.CreateMemento();
        originator.State = "Off";
        originator.DisplayState();


        originator.SetMemento(caretaker.Memento);
        originator.DisplayState();

    }
}
