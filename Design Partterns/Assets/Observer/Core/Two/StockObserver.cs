using UnityEngine;
using System.Collections;

public class StockObserver 
{
    private string name;
    private InterfaceSubject subject;

    public StockObserver(string name,InterfaceSubject subject)
    {
        this.name = name;
        this.subject = subject;
    }

    public void CloseStockMarket()
    {
        Debug.Log(string.Format("{0},{1} 关闭股市详情,继续工作", subject.SubjectState, name));
    }
}
