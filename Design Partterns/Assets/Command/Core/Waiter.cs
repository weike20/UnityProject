using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Waiter
{
    private List<Command> orders = new List<Command>();

    public void AddOrder(Command command)
    {
        if(command.ToString() == "BakeChickenWingCommand")
        {
            Debug.Log("服务员：鸡翅没有了，请点其他吃的");
        }
        else
        {
            orders.Add(command);
            Debug.Log("增加订单： " + command.ToString() + " 时间： " + DateTime.Now.ToString());
        }
    }

    public void RemoveOrder(Command command)
    {
        orders.Remove(command);
        Debug.Log("取消订单： " + command.ToString() + " 时间： " + DateTime.Now.ToString());
    }

    public void Notify()
    {
        for(int i=0;i<orders.Count; ++i)
        {
            orders[i].Excute();
        }
    }
}
