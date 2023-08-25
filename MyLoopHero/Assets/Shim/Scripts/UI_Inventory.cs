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
    #region 인벤토리 UI 필드 선언
    // UI Canvas의 Scale을 가져오기 위한 변수
    private GameObject ui_Inventory;

    // 현재 드래그 중인 아이콘의 RectTransform.transform 값을 알아오기 위한 변수
    private RectTransform rectHolding;


    // 마우스의 ScreenToWorldPoint 좌표를 저장하기 위한 변수
    private Vector3 mouseLocation;

    // raycast의 ray의 출발점을 저장하기 위한 변수
    private Vector2 rayOrigin;

    // raycast의 ray의 도착점을 저장하기 위한 변수
    private Vector2 rayDirection;

    // 드래그 여부를 판별하기 위한 변수
    private bool isDragging = false;

    // 드래그 시작좌표를 저장하기 위한 변수
    private Vector2 itemDefaultLocation;
    #endregion



    //=========================================================================================

    #region Awake
    private void Awake()
    {
        // ui_Inventory와 RectHolding의 컴포넌트를 불러온다.
        ui_Inventory = this.gameObject;
        rectHolding = GetComponent<RectTransform>();

        #region 로그 확인용 코드
        // GameObject invenEquip = GameObject.FindGameObjectWithTag("InvenEquip");
        // collidertsInUI_Inventory의 하위 box collider를 모두 담는다.
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



        // 아이템의 처음 위치를 각각 anchored position으로 저장한다.
        itemDefaultLocation = rectHolding.anchoredPosition;
        // mouseLocation의 z 값을 0으로 고정해준다.
        //mouseLocation.z = 0f;
        // 혹시 몰라서 isDrag를 false로 다시 초기화
        isDragging = false;

    }
    #endregion

    private void MakeRayOriginAndDirection()
    {
        // 클릭 시의 마우스 좌표를 ScreenToWorldPoint로 변환하여 저장한다.
        mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // ray의 출발점은 마우스의 좌표값이다.
        rayOrigin = new Vector2(mouseLocation.x, mouseLocation.y);
        // ray의 도착점
        rayDirection = Vector2.zero;
    }

    //=========================================================================================

    #region OnPointerDown // ! 아이템 슬롯을 제일 마지막 children으로 변경하는 로직 필요 -> 가려지는 현상 제어
    public void OnPointerDown(PointerEventData eventData)
    {
        MakeRayOriginAndDirection();

        RaycastHit2D hit_ = Physics2D.Raycast(rayOrigin, rayDirection, Mathf.Infinity, LayerMask.GetMask("InvenSlot"));

        #region Debug
        //RaycastHit2D hitTest = Physics2D.Raycast(rayOrigin, rayDirection, Mathf.Infinity, LayerMask.GetMask("Test001"));
        //Debug.LogFormat("[OnPointerDown] hitTest name: {0}, layer: {1} / Test001", 
        //    hitTest.collider.name, hitTest.transform.gameObject.layer);
        #endregion


        // 조건문 { 만약 마우스 좌클릭을 했을 때
        if (Input.GetMouseButtonDown(0))
        {
            // 1. 만약 레이가 검출한 콜라이더가 있을 경우
            if (hit_.collider != null && hit_.collider.GetComponent<Image>().sprite == null)
            {
                // 지금 검출한 아이콘의 transform 값을 RectHolding에 저장한다.
                rectHolding = (RectTransform)hit_.transform;
                // isDragging 값을 true 바꾼다. 드래그를 시작
                isDragging = true;
            }
            // 2. 만약 레이가 검출한 콜라이더가 없을 경우
            else
            {
                /*Do Nothing*/
            }
        }
        // 조건문 } 만약 마우스 좌클릭을 했을 때
    }
    #endregion

    //=========================================================================================

    #region OnDrag
    public void OnDrag(PointerEventData eventData)
    {
        // 조건문 { 만약 드래그 상태일 경우
        if (isDragging == true)
        {
            // RectHolding의 anchoredPosition 값에 마우스의 움직이는 변화량만큼 더해준다.
            // UI의 scaleFactor 만큼 나누어서 오차가 나지 않도록 한다.
            rectHolding.anchoredPosition += (eventData.delta / ui_Inventory.GetComponent<Canvas>().scaleFactor);
        }
        // 조건문 } 만약 드래그 상태일 경우
    }
    #endregion

    //=========================================================================================

    #region OnPointerUp
    public void OnPointerUp(PointerEventData eventData)
    {
        if (isDragging == true)
        {
            MakeRayOriginAndDirection();

            // ! 추후에 레이어를 다시 만들어서 재명명 해야할 필요성이 있을 수 있음 (검출할 장비창 레이어 -> Water)
            RaycastHit2D hit_ = Physics2D.Raycast(rayOrigin, rayDirection, Mathf.Infinity, LayerMask.GetMask("EquipSlot"));
            #region Debug
            //Debug.LogFormat("[OnPointerUp] hitTest name: {0}, layer: {1} / Test001", 
            //    hit_.transform.name, hit_.transform.gameObject.layer);
            #endregion

            if (hit_.collider == null)
            {
                // 드래그 중이고, 검출된 EquipSlot 레이어가 없다면
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
                //Debug.Log("뭔가 이상함");
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
        Debug.Log("장착");
    }
}
