using UnityEngine;
using System.Collections;
using System;

public class BakeMuttonCommand : Command
{
    public BakeMuttonCommand(Barbecuer reciever) : base(reciever) { }

    public override void Excute()
    {
        reciever.BakeMutton();
    }
}
