using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DragZone_Inven2 : MonoBehaviour
{
    private ItemBuilder itemBuilder;
    static public GameObject dragZone_Inven { get; private set; }
    static public GameObject[] invenSlots { get; private set; }
    static public GameObject[] effects { get; private set; }


    #region 이 스크립트를 들고 있는 오브젝트의 하위 요소 - Inven_Slot 을 배열로 저장
    private void MakeInvenSlotArray()
    {
        dragZone_Inven = this.gameObject;
        invenSlots = new GameObject[dragZone_Inven.transform.childCount];

        for (int i = 0; i < dragZone_Inven.transform.childCount; i++)
        {
            invenSlots[i] = gameObject.transform.GetChild(i).gameObject;
        }
    }
    #endregion


    #region 이 스크립트를 들고 있는 오브젝트의 하위 요소 - Equip_Slot - Effect 을 배열로 저장
    private void MakeEffectArray()
    {
        effects = new GameObject[(invenSlots.Length) * (invenSlots[0].transform.childCount)];

        for (int j = 0; j < invenSlots.Length; j++)
        {
            for (int i = 0; i < invenSlots[j].transform.childCount; i++)
            {
                effects[(invenSlots[0].transform.childCount * j) + i] = invenSlots[j].transform.GetChild(i).gameObject;
            }
        }
    }
    #endregion


    #region 이 스크립트를 들고 있는 오브젝트의 하위 요소 - Inven_Slot - Effect 을 초기 상태로 만드는 함수
    private void TurnAllInvenSlotDefaultStatus()
    {
        for (int i = 0; i < invenSlots.Length; i++)
        {
            invenSlots[i].tag = "ItemSlot";
            // 나중에 레이어 추가 생성시 변경
            invenSlots[i].layer = LayerMask.GetMask("UI");
            invenSlots[i].GetComponent<Image>().sprite = null;
            invenSlots[i].GetComponent<Image>().color = Color.black;
            invenSlots[i].SetActive(false);
            invenSlots[i].SetActive(true);
        }
        for (int i = 0; i < effects.Length; i++) 
        {
            effects[i].tag = "Default";
            effects[i].SetActive(false);
        }
    }
    #endregion


    #region 매개변수의 값으로 effects 인덱스를 찾아서 SetActive(false)로 만드는 함수
    private void TurnInvenEffectOff(int effectIdx_)
    {
        effects[effectIdx_].SetActive(false);
    }
    #endregion


    #region 매개변수의 값으로 effects 인덱스를 찾아서 SetActive(true)로 만드는 함수
    private void TurnInvenEffectOn(int effectIdx_)
    {
        effects[effectIdx_].SetActive(true);
    }
    #endregion


    #region 인벤토리 안에 아이템이 몇개 존재하는지 체크하는 함수
    private int CheckInventoryStatus() 
    {
        int itemCount = default;

        for (int i = 0; i < dragZone_Inven.transform.childCount; i++)
        {
            if (invenSlots[i].tag != "ItemSlot") 
            {
                itemCount++;
            }
            else 
            {
                /*Do Nothing*/
                continue;
            }
        }
        return itemCount;
    }
    #endregion


    #region 테스트용 함수 : 방향키 우측을 누르면 아이템이 하나 인벤토리에 생성
    private void SaveItemToInventory(int itemCount_)
    {
        int randomIdx_ = Random.Range(0, itemBuilder.csvConverter.csvRowCount - 1);

        // 인벤토리에 아이템이 하나도 없을 때 (invenSlots 배열의 첫 번째 요소가 없을 때)
        if (itemCount_ == 0)
        {
            invenSlots[0].tag = itemBuilder.items[randomIdx_].tag;
            invenSlots[0].name = itemBuilder.items[randomIdx_].itemName;
            invenSlots[0].GetComponent<Image>().sprite = itemBuilder.items[randomIdx_].itemSprite;
            invenSlots[0].GetComponent<Image>().color = Color.white;
        }
        // 인벤토리에 아이템이 꽉 차있을 때 (invenSlots 배열의 마지막 요소가 있을 때)
        else if (itemCount_ == 12) 
        {
            for (int i = (dragZone_Inven.transform.childCount - 1); i > 0 ; i--)
            {
                invenSlots[i].tag = invenSlots[i - 1].tag;
                invenSlots[i].name = invenSlots[i - 1].name;
                invenSlots[i].GetComponent<Image>().sprite = invenSlots[i - 1].GetComponent<Image>().sprite;
                invenSlots[i].GetComponent<Image>().color = Color.white;
            }
            invenSlots[0].tag = itemBuilder.items[randomIdx_].tag;
            invenSlots[0].name = itemBuilder.items[randomIdx_].itemName;
            invenSlots[0].GetComponent<Image>().sprite = itemBuilder.items[randomIdx_].itemSprite;
            invenSlots[0].GetComponent<Image>().color = Color.white;
        }
        // 그외 상황 (몇 개는 비었고 몇 개는 차있을 때)
        else 
        {
            for (int i = (itemCount_ - 1); i > 0; i--)
            {
                invenSlots[i].tag = invenSlots[i - 1].tag;
                invenSlots[i].name = invenSlots[i - 1].name;
                invenSlots[i].GetComponent<Image>().sprite = invenSlots[i - 1].GetComponent<Image>().sprite;
                invenSlots[i].GetComponent<Image>().color = Color.white;
            }
            invenSlots[0].tag = itemBuilder.items[randomIdx_].tag;
            invenSlots[0].name = itemBuilder.items[randomIdx_].itemName;
            invenSlots[0].GetComponent<Image>().sprite = itemBuilder.items[randomIdx_].itemSprite;
            invenSlots[0].GetComponent<Image>().color = Color.white;
        }
    }
    #endregion

    // 인벤 슬롯 간에 정렬을 담당하는 기능
}
