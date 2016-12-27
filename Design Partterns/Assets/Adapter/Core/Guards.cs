using UnityEngine;
using System.Collections;
using System;

public class Guards : Player
{
    public Guards(string name) : base(name) { }

    public override void Attack()
    {
        Debug.Log(string.Format("后卫{0}进攻", name));
    }

    public override void Defense()
    {
        Debug.Log(string.Format("后卫{0}防御", name));
    }
}
