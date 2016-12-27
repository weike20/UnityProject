using UnityEngine;
using System.Collections;
using System;

public class ConcreateWebsite : Website
{
    private string name;
    public ConcreateWebsite(string name)
    {
        this.name = name;
    }

    public override void Use()
    {
        Debug.Log("网站分类: " + name);
    }
}
