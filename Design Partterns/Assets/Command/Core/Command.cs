using UnityEngine;
using System.Collections;

public abstract class Command 
{
    protected Barbecuer reciever;
    public Command(Barbecuer reciever)
    {
        this.reciever = reciever;
    }
    public abstract void Excute();
}
