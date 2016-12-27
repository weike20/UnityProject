using UnityEngine;
using System.Collections;

public interface InterfaceSubject 
{
    void Notify();
    string SubjectState { get; set; }
}
