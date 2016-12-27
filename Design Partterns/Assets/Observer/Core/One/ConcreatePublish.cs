using UnityEngine;
using System.Collections;

public class ConcreatePublish : Publish
{
    private string publishState;
    public string PublishState
    {
        set
        {
            publishState = value;
        }
        get
        {
            return publishState;
        }
    }
}
