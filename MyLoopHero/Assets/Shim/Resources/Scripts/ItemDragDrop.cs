using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class ItemDragDrop: MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    //Ray ray =


    private void Awake()
    {
        Vector3 mousePoint = Camera.main.transform.position;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.DoPointerEnter(eventData);
    }

    public void OnPointerExit(PointerEventData eventData) 
    {
        this.DoPointerExit(eventData);
    }

    public void OnPointerDown(PointerEventData eventData) 
    {
    
    }

    public void OnPointerUp(PointerEventData eventData) 
    {
    
    }

    public void OnDrag(PointerEventData eventData) 
    {
    
    }

    protected virtual void DoPointerEnter(PointerEventData eventData)
    {
        /* Override �޾Ƽ� ����Ѵ�. */
        Debug.Log("���콺�� �÷��� �ִ�.");
        //Image image = GetComponent<Image>();
        //image.color = Color.gray;
    }

    protected virtual void DoPointerExit(PointerEventData eventData)
    {
        /* Override �޾Ƽ� ����Ѵ�. */
        Debug.Log("���콺�� �����.");
        //Image image = GetComponent<Image>();
        //image.color = Color.white;
    }
}
