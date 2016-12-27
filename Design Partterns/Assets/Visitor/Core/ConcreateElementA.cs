using UnityEngine;
using System.Collections;
using System;

public class ConcreateElementA :Element
{
    public override void Accept(Visitor visitor)
    {
        visitor.VisitConcreateElementA(this);
    }
    public string OperationA()
    {
        return "ConcreateElementB's OperationA ! ";
    }
}
