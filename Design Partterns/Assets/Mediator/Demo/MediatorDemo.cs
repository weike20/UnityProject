using UnityEngine;
using System.Collections;

public class MediatorDemo : MonoBehaviour
{
    void Start()
    {
        ConcreateMediator mediator = new ConcreateMediator();

        ConcreateColleague1 colleague1 = new ConcreateColleague1(mediator);
        ConcreateColleague2 colleague2 = new ConcreateColleague2(mediator);

        mediator.Colleague1 = colleague1;
        mediator.Colleague2 = colleague2;

        //实际上都与媒介在交互
        colleague1.Send("你吃饭没有？");
        colleague2.Send("没有呀，好吧一起吃！");
    }
}
