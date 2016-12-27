using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Json : MonoBehaviour
{
    [Serializable]
    public class MyClass
    {
        public int id;
        public string firstName;
        public string lastName;
    }

    MyClass obj = new MyClass();
    MyClass readObj = new MyClass();
    void Start()
    {
        readObj.id = 110;
        readObj.firstName = "wei";
        readObj.lastName = "ke";
        string jsonMyClass = JsonUtility.ToJson(readObj);
        Debug.Log("json string: "+jsonMyClass);
        obj = JsonUtility.FromJson<MyClass>(jsonMyClass);
        Debug.Log("id: " + obj.id+" first name: "+obj.firstName+" last name: "+obj.lastName);
    }
}
