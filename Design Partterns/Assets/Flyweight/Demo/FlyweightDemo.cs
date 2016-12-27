using UnityEngine;
using System.Collections;

public class FlyweightDemo : MonoBehaviour
{
    void Start()
    {
        int extrinisc = 10;
        FlyweightFactory factory = new FlyweightFactory();
        Flyweight xFlyweight = factory.GetFlyweight("X");
        xFlyweight.Operation(--extrinisc);

        Flyweight yFlyweight = factory.GetFlyweight("Y");
        yFlyweight.Operation(--extrinisc);

        Flyweight zFlyweight = factory.GetFlyweight("Z");
        zFlyweight.Operation(--extrinisc);

        NonShareConcreateFlyweight nonShareFlyweight = new NonShareConcreateFlyweight();
        nonShareFlyweight.Operation(--extrinisc);
    }
}
