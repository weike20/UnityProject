using UnityEngine;
using System.Collections;

public abstract class Handler
{
    protected Handler successor;
    public void SetSuccessor(Handler successor)
    {
        this.successor = successor;
    }
    public abstract bool HandleRequest(int request);
}
