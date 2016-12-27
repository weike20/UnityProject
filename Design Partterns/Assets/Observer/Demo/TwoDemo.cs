using UnityEngine;
using System.Collections;

public class TwoDemo : MonoBehaviour
{
    void Start()
    {
        Boss boss = new Boss();
        StockObserver colleague1 = new StockObserver("魏可", boss);
        NBAObserver colleague2 = new NBAObserver("王春霞", boss);
        boss.Update += new Boss.EventHandler(colleague1.CloseStockMarket);
        boss.Update += new Boss.EventHandler(colleague2.CloseNBA);

        boss.SubjectState = "魏可来找王春霞";
        boss.Notify();
    }
}
