using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class BoundBoxCollider : MonoBehaviour
{

    [MenuItem("Custom/BoundBoxCollider")]
    static void CalculateBoxCollider()
    {
        Transform selectTrs = Selection.activeGameObject.transform;
        MeshRenderer[] meshRendererGroup = selectTrs.GetComponentsInChildren<MeshRenderer>();
        for(int i = 0;i != meshRendererGroup.Length; ++i)
        {
            if (!meshRendererGroup[i].gameObject)
                return;
            Debug.Log(meshRendererGroup[i].gameObject.name + " bound center: " + meshRendererGroup[i].bounds.center);
            Debug.Log(meshRendererGroup[i].gameObject.name + " bound size: " + meshRendererGroup[i].bounds.size);
        }
    }
}
