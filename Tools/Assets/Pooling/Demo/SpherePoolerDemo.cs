using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpherePoolerDemo : MonoBehaviour
{
    #region Fields / Properties
    [SerializeField]
    StringKeyedPooler pooler;
    [SerializeField]
    InputField keyInput;
    #endregion

    #region MonoBehavior
    void OnEnable()
    {
        pooler.didDequeueForKey = DidDequeueForKey;
    }
    void OnDisable()
    {
        pooler.didDequeueForKey = null;
    }
    #endregion

    #region Event Handlers

    void DidDequeueForKey(Poolable item,string key)
    {
        float xPos = UnityEngine.Random.Range(-6, 6);
        float yPos = UnityEngine.Random.Range(-4, 4);
        float zPos = UnityEngine.Random.Range(-5, 5);
        item.transform.localPosition = new Vector3(xPos, yPos, zPos);
        item.gameObject.SetActive(true);
        item.name = key;
    }

    public void OnAddButton()
    {
        if(!string.IsNullOrEmpty(keyInput.text))
        {
            pooler.DequeueByKey(keyInput.text);
        }
    }
    public void OnRemoveButton()
    {
        pooler.EnqueueByKey(keyInput.text);
    }
    #endregion
}
