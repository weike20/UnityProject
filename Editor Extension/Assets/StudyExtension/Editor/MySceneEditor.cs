using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SceneEditor))]
public class MySceneEditor : Editor
{
    void OnSceneGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 25;
        style.fontStyle = FontStyle.Italic;
        SceneEditor sceneEditor = (SceneEditor)target;

        string content = sceneEditor.transform.name +sceneEditor.transform.position.ToString();
        Vector3 showPos = sceneEditor.transform.position ;
        style.alignment = TextAnchor.MiddleCenter;
        Handles.Label(showPos, content,style);

        Handles.BeginGUI();
        GUILayout.BeginArea(new Rect(0, 0, 100, 100));
        
        GUILayout.Label("sceneBtn");
        if (GUILayout.Button("ScenButton",GUILayout.Width(100)))
        {
            Debug.Log("On Button Click!!");
        }
        GUILayout.EndArea();
        Handles.EndGUI();
    }
}
