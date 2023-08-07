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
    #region 인벤토리 UI 필드 선언
    // UI Canvas의 Scale을 가져오기 위한 변수
    private Canvas ui_Inventory;

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
        ui_Inventory = GetComponent<Canvas>();
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
        mouseLocation.z = 0f;
        // 혹시 몰라서 isDrag를 false로 다시 초기화
        isDragging = false;
    }
    #endregion

    //=========================================================================================

    #region OnPointerDown
    public void OnPointerDown(PointerEventData eventData)
    {
        // 클릭 시의 마우스 좌표를 ScreenToWorldPoint로 변환하여 저장한다.
        mouseLocation = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // ray의 출발점은 마우스의 좌표값이다.
        rayOrigin = new Vector2(mouseLocation.x, mouseLocation.y);
        // ray의 도착점
        rayDirection = Vector2.zero;

        // raycast에서 부딪힌 결과를 저장하는 rayCastHit을 통해 ray를 쏴준다.
        // ray의 출발점, 도착점, 길이, 검출할 레이어를 넣어준다.
        RaycastHit2D hit_ = Physics2D.Raycast(rayOrigin, rayDirection, Mathf.Infinity, LayerMask.GetMask("UI"));

        // 조건문 { 만약 마우스 좌클릭을 했을 때
        if (Input.GetMouseButtonDown(0))
        {
            // 1. 만약 레이가 검출한 콜라이더가 있을 경우
            if (hit_.collider != null)
            {
                // 지금 검출한 아이콘의 transform 값을 RectHolding에 저장한다.
                rectHolding = (RectTransform)hit_.transform;
                // isDragging 값을 true 바꾼다. 드래그를 시작
                isDragging = true;
                //Debug.Log(hit_.collider.tag);
                //Debug.LogFormat("클릭 {0}", rectHolding.position);
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
            rectHolding.anchoredPosition += (eventData.delta / ui_Inventory.scaleFactor);
            //Debug.LogFormat("드래그 {0}", rectHolding.position);
        }
        // 조건문 } 만약 드래그 상태일 경우
    }
    #endregion

    //=========================================================================================

    #region OnPointerUp
    public void OnPointerUp(PointerEventData eventData)
    {
        // 드래그가 엉뚱한 곳에 떨어질 시 저장된 첫 위치로 복귀하도록 한다.
        rectHolding.anchoredPosition = itemDefaultLocation;
        isDragging = false;
    }
    #endregion
}
