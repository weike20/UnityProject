﻿using UnityEngine;
using System.Collections;
using System;

public class ConcreateBuilderA :Builder
{
    private Product product = new Product();

    public override void BuildPartA()
    {
        product.Add("部件A");
    }

    public override void BuildPartB()
    {
        product.Add("部件B");
    }

    public override Product GetResult()
    {
        return product;
    }
}
