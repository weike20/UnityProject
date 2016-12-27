using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class MyEditorWindow : EditorWindow
{

    [MenuItem("Custom/MyEditorWindow")]
    static void AddWindow()
    {
        MyEditorWindow window = EditorWindow.GetWindow(typeof(MyEditorWindow), false, "Window", true) as MyEditorWindow;
        window.Show();
    }

    private Vector2 vec2;
    void OnGUI()
    {
        vec2 = EditorGUILayout.Vector2Field("Vec2", vec2);
        if(GUILayout.Button("Opan Notification",GUILayout.Width(500)))
        {
            this.ShowNotification(new GUIContent("X :" + vec2.x.ToString() +"       "+ "Y:" + vec2.y.ToString(),""));
        }
        if (GUILayout.Button("Close Notifiction", GUILayout.Width(500)))
        {
            this.RemoveNotification();
        }
        EditorGUILayout.LabelField("鼠标窗口位置", Event.current.mousePosition.ToString());
    }
    void Update()
    {
        /*Debug.Log("Update!!");*/
    }
    void OnHierarchyChange()
    {
        Debug.Log("Hierarchy value change");
    }
}
