using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FirstEditor))]
[ExecuteInEditMode]
public class MyFirstEditor : Editor
{
    public override void OnInspectorGUI()
    {
        FirstEditor firstEditor = (FirstEditor)target;
        firstEditor.rect = EditorGUILayout.RectField("窗口坐标", firstEditor.rect);
        firstEditor.texture = EditorGUILayout.ObjectField("贴图", firstEditor.texture, typeof(Texture), true) as Texture;
        firstEditor.vec2 = EditorGUILayout.Vector2Field("开始和结束时间", firstEditor.vec2);
    }
}
