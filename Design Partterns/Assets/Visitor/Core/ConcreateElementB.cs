using UnityEngine;
using System.Collections;
using System;

public class ConcreateElementB :Element
{
    public override void Accept(Visitor visitor)
    {
        visitor.VisitConcreateElementB(this);
    }
    public string OperationB()
    {
        return "ConcreateElementB's OperationB !";
    }
}
