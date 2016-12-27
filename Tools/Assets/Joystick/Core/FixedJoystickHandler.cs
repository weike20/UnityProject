using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class FixedJoystickHandler : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    #region Fields / Properties
    [Serializable]
    public class JoystickEvent : UnityEvent<Vector3> { }

    public Transform content;
    public UnityEvent beginControl;
    public JoystickEvent controlling;
    public UnityEvent endControl;

    #endregion

    #region Public
    public void OnBeginDrag(PointerEventData eventData)
    {
        beginControl.Invoke();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(content)
            controlling.Invoke(content.localPosition.normalized);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        endControl.Invoke();
    }
    #endregion
}
