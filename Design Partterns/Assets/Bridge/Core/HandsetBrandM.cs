using UnityEngine;
using System.Collections;
using System;

public class HandsetBrandM :HandsetBrand
{
    public override void Run()
    {
        Debug.Log("M品牌的手机");
        software.Run();
    }
}
