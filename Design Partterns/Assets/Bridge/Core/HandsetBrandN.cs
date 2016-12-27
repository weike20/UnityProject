using UnityEngine;
using System.Collections;
using System;

public class HandsetBrandN : HandsetBrand
{
    public override void Run()
    {
        Debug.Log("N品牌的手机");
        software.Run();
    }
}
