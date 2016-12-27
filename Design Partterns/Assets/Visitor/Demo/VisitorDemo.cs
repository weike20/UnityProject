using UnityEngine;
using System.Collections;

public class VisitorDemo : MonoBehaviour
{
    void Start()
    {
        //高层管理
        //ObjectStructure objectStructure = new ObjectStructure();

        ConcreateElementA elementA = new ConcreateElementA();
        ConcreateElementB elementB = new ConcreateElementB();
        //objectStructure.Add(elementA);
        //objectStructure.Add(elementB);

        Visitor visitor1 = new ConcreateVisitor1();
        Visitor visitor2 = new ConcreateVisitor2();
        elementA.Accept(visitor1);
        elementB.Accept(visitor2);

    }
	
}
