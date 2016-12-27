using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CubePoolerDemo : MonoBehaviour
{
    #region Field / Properties
    [SerializeField] SetPooler pooler;
    #endregion

    #region MonoBehavior
    void OnEnable()
    {
        pooler.willEnqueue = OnEnqueue;
        pooler.didDequeue = OnDequeue;
    }
    void OnDisable()
    {
        pooler.willEnqueue = null;
        pooler.didDequeue = null;
    }
    #endregion

    #region Event Handler
    void OnEnqueue(Poolable item)
    {
        Button button = item.GetComponent<Button>();
        button.onClick.RemoveAllListeners();
    }
    void OnDequeue(Poolable item)
    {
        float xPos = UnityEngine.Random.Range(10, -10);
        float yPos = UnityEngine.Random.Range(10, -10);
        float zPos = UnityEngine.Random.Range(10, -10);

        item.transform.position = new Vector3(xPos, yPos, zPos);
        item.gameObject.SetActive(true);

        Button button = item.GetComponent<Button>();

        button.onClick.AddListener(() => { pooler.Enqueue(item); Debug.Log("Test"); });
    }
    #endregion

    #region
    public void OnAddButton()
    {
        pooler.Dequeue();
    }
    #endregion
}
