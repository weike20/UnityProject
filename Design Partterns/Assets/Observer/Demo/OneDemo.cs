using UnityEngine;
using System.Collections;

public class OneDemo : MonoBehaviour
{
    void Start()
    {
        ConcreatePublish publish = new ConcreatePublish();
        publish.Attach(new ConcreateSubscribe("weike", publish));
        publish.Attach(new ConcreateSubscribe("wangchunxia", publish));

        publish.PublishState = "weike come for wangchunxia";
        publish.Notify();
        
    }
}
