using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(UnityEditor.SceneAsset))]
public class MyInspector : Editor
{
    public override void OnInspectorGUI()
    {
        string path = AssetDatabase.GetAssetPath(target);
        if(path.EndsWith(".unity"))
        {
            GUILayout.Label("我是场景");
        }
    }
}
