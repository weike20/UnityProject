using UnityEngine;
using System.Collections;

public class BuilderDemo : MonoBehaviour
{
    void Start()
    {
        Director director = new Director();
        Builder b1 = new ConcreateBuilderA();
        Builder b2 = new ConcreateBuilderB();

        //隐藏了创建的复杂细节
        director.Construct(b1);     
        director.Construct(b2);

        Product p1 = b1.GetResult();
        Product p2 = b2.GetResult();

        p1.Show();
        p2.Show();
    }
}
