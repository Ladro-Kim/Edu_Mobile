using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickInput : MonoBehaviourPun, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public RectTransform background;
    public RectTransform stick;

    public Vector3 dir;

    float radius;
    public bool isTouch;

    void Start()
    {
        radius = background.rect.width * 0.5f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        stick.position = eventData.position;
        stick.anchoredPosition = Vector2.ClampMagnitude(stick.anchoredPosition, radius);
        dir = new Vector3(stick.anchoredPosition.x, 0, stick.anchoredPosition.y) / radius;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isTouch = false;
        stick.anchoredPosition = Vector2.zero;
        dir = Vector3.zero;
    }



}
