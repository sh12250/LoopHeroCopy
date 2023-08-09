//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    #region �κ��丮 UI �ʵ� ����
    // UI Canvas�� Scale�� �������� ���� ����
    private Canvas ui_Inventory;

    // ���� �巡�� ���� �������� RectTransform.transform ���� �˾ƿ��� ���� ����
    private RectTransform rectHolding;

    // ���콺�� ScreenToWorldPoint ��ǥ�� �����ϱ� ���� ����
    private Vector3 mouseLocation;

    // raycast�� ray�� ������� �����ϱ� ���� ����
    private Vector2 rayOrigin;

    // raycast�� ray�� �������� �����ϱ� ���� ����
    private Vector2 rayDirection;

    // �巡�� ���θ� �Ǻ��ϱ� ���� ����
    private bool isDragging = false;

    // �巡�� ������ǥ�� �����ϱ� ���� ����
    private Vector2 itemDefaultLocation;
    #endregion

    //=========================================================================================

    #region Awake
    private void Awake()
    {
        // ui_Inventory�� RectHolding�� ������Ʈ�� �ҷ��´�.
        ui_Inventory = GetComponent<Canvas>();
        rectHolding = GetComponent<RectTransform>();

        #region �α� Ȯ�ο� �ڵ�
        // GameObject invenEquip = GameObject.FindGameObjectWithTag("InvenEquip");
        // collidertsInUI_Inventory�� ���� box collider�� ��� ��´�.
        // collidertsInUI_Inventory = new GameObject[invenEquip.transform.childCount];
        // for(int i=0; i<invenEquip.transform.childCount; i++)
        // {
        //     collidertsInUI_Inventory[i] = invenEquip.transform.GetChild(i).gameObject;
        // }
        //collidertsInUI_Inventory[0].GetComponent<Image>();
        //Debug.Log(collidertsInUI_Inventory[0].tag);
        //Debug.Log(collidertsInUI_Inventory[1].tag);
        //Debug.Log(collidertsInUI_Inventory[2].tag);
        //Debug.Log(collidertsInUI_Inventory[3].tag);
        //Debug.Log(collidertsInUI_Inventory[4].tag);
        //Debug.Log(collidertsInUI_Inventory[0].CompareTag(rectHolding.GetComponentsInChildren<Image>()[1].tag));
        //Debug.Log(collidertsInUI_Inventory[3].CompareTag(rectHolding.GetComponentsInChildren<Image>()[0].tag));
        #endregion

        // �������� ó�� ��ġ�� ���� anchored position���� �����Ѵ�.
        itemDefaultLocation = rectHolding.anchoredPosition;
        // mouseLocation�� z ���� 0���� �������ش�.
        mouseLocation.z = 0f;
        // Ȥ�� ���� isDrag�� false�� �ٽ� �ʱ�ȭ
        isDragging = false;
    }
    #endregion

    //=========================================================================================

    #region OnPointerDown
    public void OnPointerDown(PointerEventData eventData)
    {
        // Ŭ�� ���� ���콺 ��ǥ�� ScreenToWorldPoint�� ��ȯ�Ͽ� �����Ѵ�.
        mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // ray�� ������� ���콺�� ��ǥ���̴�.
        rayOrigin = new Vector2(mouseLocation.x, mouseLocation.y);
        // ray�� ������
        rayDirection = Vector2.zero;

        // raycast���� �ε��� ����� �����ϴ� rayCastHit�� ���� ray�� ���ش�.
        // ray�� �����, ������, ����, ������ ���̾ �־��ش�.
        RaycastHit2D hit_ = Physics2D.Raycast(rayOrigin, rayDirection, Mathf.Infinity, LayerMask.GetMask("UI"));

        // ���ǹ� { ���� ���콺 ��Ŭ���� ���� ��
        if (Input.GetMouseButtonDown(0))
        {
            // 1. ���� ���̰� ������ �ݶ��̴��� ���� ���
            if (hit_.collider != null)
            {
                // ���� ������ �������� transform ���� RectHolding�� �����Ѵ�.
                rectHolding = (RectTransform)hit_.transform;
                // isDragging ���� true �ٲ۴�. �巡�׸� ����
                isDragging = true;
                //Debug.Log(hit_.collider.tag);
                //Debug.LogFormat("Ŭ�� {0}", rectHolding.position);
            }
            // 2. ���� ���̰� ������ �ݶ��̴��� ���� ���
            else
            {
                /*Do Nothing*/
            }
        }
        // ���ǹ� } ���� ���콺 ��Ŭ���� ���� ��
    }
    #endregion

    //=========================================================================================

    #region OnDrag
    public void OnDrag(PointerEventData eventData)
    {
        // ���ǹ� { ���� �巡�� ������ ���
        if (isDragging == true) 
        {
            // RectHolding�� anchoredPosition ���� ���콺�� �����̴� ��ȭ����ŭ �����ش�.
            // UI�� scaleFactor ��ŭ ����� ������ ���� �ʵ��� �Ѵ�.
            rectHolding.anchoredPosition += (eventData.delta / ui_Inventory.scaleFactor);
            //Debug.LogFormat("�巡�� {0}", rectHolding.position);
        }
        // ���ǹ� } ���� �巡�� ������ ���
    }
    #endregion

    //=========================================================================================

    #region OnPointerUp
    public void OnPointerUp(PointerEventData eventData)
    {
        // �巡�װ� ������ ���� ������ �� ����� ù ��ġ�� �����ϵ��� �Ѵ�.
        rectHolding.anchoredPosition = itemDefaultLocation;
        isDragging = false;
    }
    #endregion
}
