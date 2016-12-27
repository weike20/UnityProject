using UnityEngine;
using System.Collections;

public class AdapterDemo : MonoBehaviour
{
    void Start()
    {
        Player b = new Forward("巴蒂尔");
        b.Attack();

        Player m = new Guards("麦克格雷迪");
        m.Attack();

        Player ym = new Translator("姚明");
        ym.Attack();
        ym.Defense();


    }
}
