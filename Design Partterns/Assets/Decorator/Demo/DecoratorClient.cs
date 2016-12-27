using UnityEngine;
using System.Collections;

public class DecoratorClient : MonoBehaviour
{
    void Start()
    {
        ConcreateComponent c = new ConcreateComponent();
        ConcreateDecoratorA decoratorA = new ConcreateDecoratorA();
        ConcreateDecoratorB decoratorB = new ConcreateDecoratorB();

        decoratorA.SetComponent(c);
        decoratorB.SetComponent(decoratorA);

        decoratorB.Operation();

    }
}
