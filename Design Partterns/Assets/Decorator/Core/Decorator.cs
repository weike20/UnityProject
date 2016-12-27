using UnityEngine;
using System.Collections;
using System;

public class Decorator:MComponent
{
    protected MComponent mComponent;
    public void SetComponent(MComponent component)
    {
        mComponent = component;
    }
    public override void Operation()
    {
        if(mComponent != null)
        {
            mComponent.Operation();
        }
    }
}
