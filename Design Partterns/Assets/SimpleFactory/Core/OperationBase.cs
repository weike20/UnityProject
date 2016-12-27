using UnityEngine;
using System.Collections;

public abstract class OperationBase
{
    private float numberA;
    private float numberB;

    public float NumberA
    {
        get
        {
            return numberA;
        }
        set
        {
            numberA = value;
        }
    }
    public float NumberB
    {
        get
        {
            return numberB;
        }
        set
        {
            numberB = value;
        }
    }
    public abstract float CalculateResult();

 
}
