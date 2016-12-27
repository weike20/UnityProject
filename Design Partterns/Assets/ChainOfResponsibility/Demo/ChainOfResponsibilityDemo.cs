using UnityEngine;
using System.Collections;

public class ChainOfResponsibilityDemo : MonoBehaviour
{
    void Start()
    {
        Handler s1 = new ConcreateHandler1();
        Handler s2 = new ConcreateHandler2();
        Handler s3 = new ConcreateHandler3();

        s1.SetSuccessor(s2);
        s2.SetSuccessor(s3);

        s1.HandleRequest(25);
        
    }
}
