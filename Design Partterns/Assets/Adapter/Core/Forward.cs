using UnityEngine;
using System.Collections;
using System;

public class Forward :Player
{
    public Forward(string name) : base(name) { }

    public override void Attack()
    {
        Debug.Log(string.Format("先锋{0}进攻", name));
    }

    public override void Defense()
    {
        Debug.Log(string.Format("先锋{0}防御", name));
    }
}
