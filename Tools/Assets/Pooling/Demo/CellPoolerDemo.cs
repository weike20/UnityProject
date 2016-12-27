using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CellPoolerDemo : MonoBehaviour
{
    #region Fields / Properties
    [SerializeField]
    IndexedPooler pooler;
    [SerializeField]
    RectTransform content;
    #endregion

    #region MonoBehavior
    void OnEnable()
    {
        pooler.didEqueueAtIndex = DidDequeueAtIndex;
        pooler.willEqueueAtIndex = WillEnqueueAtIndex;
    }
    void OnDisable()
    {
        pooler.didEqueueAtIndex = null;
        pooler.willEqueueAtIndex = null;
    }
    #endregion

    #region Event Handler
    void DidDequeueAtIndex(Poolable item, int index)
    {
        Button btn = item.GetComponent<Button>();
        btn.transform.SetParent(content, false);
        btn.gameObject.SetActive(true);
        btn.onClick.AddListener(() => { Colorize(btn.GetComponent<Image>()); });
    }
    void WillEnqueueAtIndex(Poolable item, int index)
    {
        Button btn = item.GetComponent<Button>();
        btn.onClick.RemoveAllListeners();
    }
    #endregion

    #region Public
    public void OnAddButton()
    {
        pooler.Dequeue();
    }
    public void OnColorizeButton()
    {
        for (int i = 0; i != pooler.Collection.Count; ++i)
        {
            Colorize(pooler.GetScript<Image>(i));
        }
    }
    #endregion

    #region Private
    void Colorize(Image image)
    {
        float r = Random.value;
        float g = Random.value;
        float b = Random.value;

        image.color = new Color(r, g, b);
    }
    #endregion
}
