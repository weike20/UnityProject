using UnityEngine;
using System.Collections;

public class ConcreateSubscribe :Subscribe
{
    private string name;
    private string subscribeState;
    private ConcreatePublish publish;

    public ConcreateSubscribe (string name,ConcreatePublish publish)
    {
        this.name = name;
        this.publish = publish;
    }
    public ConcreatePublish Publish
    {
        get
        {
            return publish;
        }
        set
        {
            publish = value;
        }
    }

    public void Update()
    {
        subscribeState = publish.PublishState;
        Debug.Log(string.Format("观察者{0}的新状态是{1}", name, subscribeState));
    }

}
