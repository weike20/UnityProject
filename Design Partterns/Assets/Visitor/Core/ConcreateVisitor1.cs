using UnityEngine;
using System.Collections;
using System;

public class ConcreateVisitor1 : Visitor
{
    public override void VisitConcreateElementA(ConcreateElementA concreateElementA)
    {
        Debug.Log(string.Format("{0} 被 {1}访问，并且执行 {2}",concreateElementA.GetType().Name,this.GetType().Name,concreateElementA.OperationA()));
    }
    public override void VisitConcreateElementB(ConcreateElementB concreateElementB)
    {
        Debug.Log(string.Format("{0} 被 {1} 访问，并且执行 {2}", concreateElementB.GetType().Name, this.GetType().Name, concreateElementB.OperationB()));
    }
}
