using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Publish 
{
    private List<Subscribe> subscribes = new List<Subscribe>();

    public void Attach(Subscribe subscribe)
    {
        subscribes.Add(subscribe);
    }

    public void Detach(Subscribe subscribe)
    {
        subscribes.Remove(subscribe);
    }

    public void Notify()
    {
        for(int i = 0 ; i < subscribes.Count ; i++)
        {
            subscribes[i].Update();
        }
    }
}
