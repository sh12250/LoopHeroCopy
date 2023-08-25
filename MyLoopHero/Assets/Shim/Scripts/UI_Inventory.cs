using System.Collections;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Unity.VisualScripting;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    #region �κ��丮 UI �ʵ� ����
    // UI Canvas�� Scale�� �������� ���� ����
    private GameObject ui_Inventory;

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
        ui_Inventory = this.gameObject;
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
        //mouseLocation.z = 0f;
        // Ȥ�� ���� isDrag�� false�� �ٽ� �ʱ�ȭ
        isDragging = false;

    }
    #endregion

    private void MakeRayOriginAndDirection()
    {
        // Ŭ�� ���� ���콺 ��ǥ�� ScreenToWorldPoint�� ��ȯ�Ͽ� �����Ѵ�.
        mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // ray�� ������� ���콺�� ��ǥ���̴�.
        rayOrigin = new Vector2(mouseLocation.x, mouseLocation.y);
        // ray�� ������
        rayDirection = Vector2.zero;
    }

    //=========================================================================================

    #region OnPointerDown // ! ������ ������ ���� ������ children���� �����ϴ� ���� �ʿ� -> �������� ���� ����
    public void OnPointerDown(PointerEventData eventData)
    {
        MakeRayOriginAndDirection();

        RaycastHit2D hit_ = Physics2D.Raycast(rayOrigin, rayDirection, Mathf.Infinity, LayerMask.GetMask("InvenSlot"));

        #region Debug
        //RaycastHit2D hitTest = Physics2D.Raycast(rayOrigin, rayDirection, Mathf.Infinity, LayerMask.GetMask("Test001"));
        //Debug.LogFormat("[OnPointerDown] hitTest name: {0}, layer: {1} / Test001", 
        //    hitTest.collider.name, hitTest.transform.gameObject.layer);
        #endregion


        // ���ǹ� { ���� ���콺 ��Ŭ���� ���� ��
        if (Input.GetMouseButtonDown(0))
        {
            // 1. ���� ���̰� ������ �ݶ��̴��� ���� ���
            if (hit_.collider != null && hit_.collider.GetComponent<Image>().sprite == null)
            {
                // ���� ������ �������� transform ���� RectHolding�� �����Ѵ�.
                rectHolding = (RectTransform)hit_.transform;
                // isDragging ���� true �ٲ۴�. �巡�׸� ����
                isDragging = true;
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
            rectHolding.anchoredPosition += (eventData.delta / ui_Inventory.GetComponent<Canvas>().scaleFactor);
        }
        // ���ǹ� } ���� �巡�� ������ ���
    }
    #endregion

    //=========================================================================================

    #region OnPointerUp
    public void OnPointerUp(PointerEventData eventData)
    {
        if (isDragging == true)
        {
            MakeRayOriginAndDirection();

            // ! ���Ŀ� ���̾ �ٽ� ���� ���� �ؾ��� �ʿ伺�� ���� �� ���� (������ ���â ���̾� -> Water)
            RaycastHit2D hit_ = Physics2D.Raycast(rayOrigin, rayDirection, Mathf.Infinity, LayerMask.GetMask("EquipSlot"));
            #region Debug
            //Debug.LogFormat("[OnPointerUp] hitTest name: {0}, layer: {1} / Test001", 
            //    hit_.transform.name, hit_.transform.gameObject.layer);
            #endregion

            if (hit_.collider == null)
            {
                // �巡�� ���̰�, ����� EquipSlot ���̾ ���ٸ�
                rectHolding.anchoredPosition = itemDefaultLocation;
                isDragging = false;
            }
            else if (hit_.collider != null)
            {
                if (hit_.collider.name == "Equip_Slot_Weapon" && rectHolding.CompareTag("Weapon"))
                {
                    ChangeItem(0);

                    UI_DragZone_Equip.equipSlots[0].GetComponent<Image>().sprite =
                            rectHolding.GetComponentsInChildren<Image>()[1].sprite;

                    rectHolding.tag = "Inven";
                    rectHolding.GetComponentsInChildren<Image>()[1].sprite = null;
                    rectHolding.GetComponentsInChildren<Image>()[1].color = Color.black;

                    UI_DragZone_Inven.instance.itemInInvenCnt -= 1;

                    rectHolding.anchoredPosition = itemDefaultLocation;
                    isDragging = false;
                }
                else if (hit_.collider.name == "Equip_Slot_Ring" && rectHolding.CompareTag("Ring"))
                {
                    ChangeItem(1);

                    UI_DragZone_Equip.equipSlots[1].GetComponent<Image>().sprite =
                            rectHolding.GetComponentsInChildren<Image>()[1].sprite;

                    rectHolding.tag = "Inven";
                    rectHolding.GetComponentsInChildren<Image>()[1].sprite = null;
                    rectHolding.GetComponentsInChildren<Image>()[1].color = Color.black;

                    UI_DragZone_Inven.instance.itemInInvenCnt -= 1;

                    rectHolding.anchoredPosition = itemDefaultLocation;
                    isDragging = false;
                }
                else if (hit_.collider.name == "Equip_Slot_Shield" && rectHolding.CompareTag("Shield"))
                {
                    ChangeItem(2);

                    UI_DragZone_Equip.equipSlots[2].GetComponent<Image>().sprite =
                            rectHolding.GetComponentsInChildren<Image>()[1].sprite;

                    rectHolding.tag = "Inven";
                    rectHolding.GetComponentsInChildren<Image>()[1].sprite = null;
                    rectHolding.GetComponentsInChildren<Image>()[1].color = Color.black;

                    UI_DragZone_Inven.instance.itemInInvenCnt -= 1;

                    rectHolding.anchoredPosition = itemDefaultLocation;
                    isDragging = false;
                }
                else if (hit_.collider.name == "Equip_Slot_Armor" && rectHolding.CompareTag("Armor"))
                {
                    ChangeItem(3);

                    UI_DragZone_Equip.equipSlots[3].GetComponent<Image>().sprite =
                            rectHolding.GetComponentsInChildren<Image>()[1].sprite;

                    rectHolding.tag = "Inven";
                    rectHolding.GetComponentsInChildren<Image>()[1].sprite = null;
                    rectHolding.GetComponentsInChildren<Image>()[1].color = Color.black;

                    UI_DragZone_Inven.instance.itemInInvenCnt -= 1;

                    rectHolding.anchoredPosition = itemDefaultLocation;
                    isDragging = false;
                }
                else
                {
                    rectHolding.anchoredPosition = itemDefaultLocation;
                    isDragging = false;
                }
            }
            else
            {
                /*Do Nothing*/
                //Debug.Log("���� �̻���");
            }
            #region LEGACY
            //else if (rectHolding.tag == UI_DragZone_Equip.equipSlots[3].tag)
            //{
            //    UI_DragZone_Equip.ChangeSlotSprite(UI_DragZone_Equip.equipSlots[3]);
            //}
            #endregion
        }
        else if (isDragging == false)
        {
            /*Do Nothing*/
        }
    }
    #endregion

    private void ChangeItem(int idx_)
    {
        Item prevStat_ = UI_DragZone_Equip.equipSlots[idx_].GetComponent<Item>();
        Item currStat_ = rectHolding.GetComponent<Item>();
        Knight player_ = FindObjectOfType<Knight>();


        player_.RemoveStat(prevStat_);
        prevStat_.CopyItemValues(currStat_);
        player_.AddStat(currStat_);
        Debug.Log("����");
    }
}
