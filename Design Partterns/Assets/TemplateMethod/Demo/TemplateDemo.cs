using UnityEngine;
using System.Collections;

public class TemplateDemo : MonoBehaviour
{
    void Start()
    {
        MClass myClass;
        myClass = new ConcreateClassA();
        myClass.TemplateMethod();

        myClass = new ConcreateClassB();
        myClass.TemplateMethod();

    }
}
