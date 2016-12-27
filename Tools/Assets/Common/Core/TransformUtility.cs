using UnityEngine;
using System.Collections;

public class TransformUtilty
{
    public static Transform FindDeepChild(GameObject root, string childName)
    {
        Transform resultTrans = null;
        resultTrans = root.gameObject.transform.FindChild(childName);
        if (!resultTrans)
        {
            foreach (Transform trs in root.transform)
            {
                resultTrans = TransformUtilty.FindDeepChild(trs.gameObject, childName);
                if (resultTrans)
                    return resultTrans;
            }
        }
        return resultTrans;
    }
    public static T FindDeepChild<T>(GameObject root, string childName) where T : Component
    {
        Transform trs = TransformUtilty.FindDeepChild(root, childName);
        if (trs)
            return trs.GetComponent<T>();
        return (T)((object)null);
    }
}
