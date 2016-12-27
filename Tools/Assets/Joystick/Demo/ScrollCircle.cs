using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollCircle : ScrollRect 
{
    private float radius = 0f;

    protected override void Start()
    {
        base.Start();
        radius = (transform as RectTransform).sizeDelta.x * 0.5f;
    }

    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        base.content.anchoredPosition = Vector3.ClampMagnitude(base.content.anchoredPosition, radius);
    }

}
