using UnityEngine;
using System.Collections;
using System;

public class ConcreateBuilderB :Builder
{
    private Product product = new Product();

    public override void BuildPartA()
    {
        product.Add("部件X");
    }

    public override void BuildPartB()
    {
        product.Add("部件Y");
    }

    public override Product GetResult()
    {
        return product;
    }
}
