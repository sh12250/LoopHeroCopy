using System.Collections;
using System.Collections.Generic;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private Canvas ui_Inventory;
    private RectTransform RectHolding;
    private Vector3 mouseLocation;
    private Vector2 rayOrigin;
    private Vector2 rayDirection;
    private bool isDragging = false;


    private void Awake()
    {
        ui_Inventory = GetComponent<Canvas>();
        RectHolding = GetComponent<RectTransform>();
        mouseLocation.z = 0f;
        isDragging = false;
    }

    void Update()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rayOrigin = new Vector2(mouseLocation.x, mouseLocation.y);
        rayDirection = Vector2.zero;

        RaycastHit2D hit_ = Physics2D.Raycast(rayOrigin, rayDirection, Mathf.Infinity, LayerMask.GetMask("UI"));

        if (Input.GetMouseButtonDown(0))
        {
            if (hit_.collider != null)
            {
                RectHolding = (RectTransform)hit_.transform;
                
                    Debug.Log(hit_.collider.tag);
                    isDragging = true;
                    //RectHolding.anchoredPosition = 
            }
            else
            {
                /*Do Nothing*/
            }
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (isDragging == true) 
        {
            RectHolding.anchoredPosition += (eventData.delta / ui_Inventory.scaleFactor);
            Debug.Log("Drag");
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        if (isDragging == true) 
        {
            isDragging = false;
        }
    }
}
