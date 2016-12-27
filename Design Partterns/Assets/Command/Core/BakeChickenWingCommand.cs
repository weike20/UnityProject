using UnityEngine;
using System.Collections;
using System;

public class BakeChickenWingCommand :Command
{
    public BakeChickenWingCommand(Barbecuer reciever) : base(reciever) { }

    public override void Excute()
    {
        reciever.BakeChickenWing();
    }
}
