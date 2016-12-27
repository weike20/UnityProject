using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Product
{
    private List<string> parts = new List<string>();
    public void Add(string part)
    {
        parts.Add(part);
    }
    public void Show()
    {
        Debug.Log("产品创建");
        for (int i = 0; i < parts.Count;++i)
        {
            Debug.Log(parts[i]);
        }
    }
}
