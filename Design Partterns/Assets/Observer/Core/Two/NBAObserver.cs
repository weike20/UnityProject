using UnityEngine;
using System.Collections;

public class NBAObserver 
{
    private string name;
    private InterfaceSubject subject;

    public NBAObserver(string name,InterfaceSubject subject)
    {
        this.name = name;
        this.subject = subject;
    }

    public void CloseNBA()
    {
        Debug.Log(string.Format("{0},{1} 关闭NBA视频,继续工作", subject.SubjectState, name));
    }
}
