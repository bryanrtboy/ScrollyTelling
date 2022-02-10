using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class InputManager : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public float m_scrollSpeed = 1f;
    private Canvas _canvas;
    private RectTransform _rectTransform;

    void Awake()
    {
        _canvas = GetComponentInParent<Canvas>();
        if (_canvas == null)
        {
            Debug.LogError("Get a Canvas buddy!");
            Destroy(this);
        }

        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointer is down!");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Starting Drag at " + Time.time);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Ending Drag at " + Time.time);
    }

    public void OnDrag(PointerEventData eventData)
    {
        var position = eventData.delta / _canvas.scaleFactor;
        _rectTransform.Translate(Vector3.up * position.y * m_scrollSpeed);
    }

}
