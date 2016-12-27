using UnityEngine;
using System.Collections;

public class UngraduateFactory: IFactory
{
    public LeiFeng CreateLeiFeng()
    {
        return new Ungraduate();
    }
}
