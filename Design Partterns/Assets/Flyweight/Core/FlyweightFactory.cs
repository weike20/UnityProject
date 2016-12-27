using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlyweightFactory
{
    private Dictionary<string, ConcreateFlyweight> flyweightTable;
    public FlyweightFactory()
    {
        flyweightTable = new Dictionary<string, ConcreateFlyweight>();
        flyweightTable.Add("X", new ConcreateFlyweight());
        flyweightTable.Add("Y", new ConcreateFlyweight());
        flyweightTable.Add("Z", new ConcreateFlyweight());
    }

    public Flyweight GetFlyweight(string key)
    {
        if(flyweightTable.ContainsKey(key))
        {
            return flyweightTable[key];
        }
        return null;
    }
}
