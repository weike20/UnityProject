using UnityEngine;
using UnityEditor;


public class OwnComponentExtension : Editor
{
  
}

[CanEditMultipleObjects()] //支持多对象编辑 意思是同时选中多个对象时候，是否显示这个属性
[CustomEditor(typeof(Camera))]
public class CameraExtension:OwnComponentExtension
{
    public override void OnInspectorGUI()
    {
        base.DrawDefaultInspector();
        if (GUILayout.Button("MyButton"))
        {
            Debug.Log("my button click");
        }
    }
}
