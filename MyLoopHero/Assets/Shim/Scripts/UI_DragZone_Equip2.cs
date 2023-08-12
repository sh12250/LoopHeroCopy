using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DragZone_Equip2 : MonoBehaviour
{
    static public GameObject dragZone_Equip { get; private set; }
    static public GameObject[] equipSlots { get; private set; }
    static public GameObject[] effects { get; private set; }


    // 이 스크립트를 들고 있는 오브젝트의 하위 요소들을 확인(장비 슬롯, 이펙트 슬롯)
    #region 이 스크립트를 들고 있는 오브젝트의 하위 요소 - Equip_Slot 을 배열로 저장
    private void MakeEquipSlotArray()
    {
        dragZone_Equip = this.gameObject;
        equipSlots = new GameObject[dragZone_Equip.transform.childCount];

        for (int i = 0; i < dragZone_Equip.transform.childCount; i++)
        {
            equipSlots[i] = gameObject.transform.GetChild(i).gameObject;
        }
    }
    #endregion


    #region 이 스크립트를 들고 있는 오브젝트의 하위 요소 - Equip_Slot - Effect 을 배열로 저장
    private void MakeEffectArray()
    {
        effects = new GameObject[(equipSlots.Length) * (equipSlots[0].transform.childCount)];

        for (int j = 0; j < equipSlots.Length; j++)
        {
            for (int i = 0; i < equipSlots[j].transform.childCount; i++)
            {
                effects[(equipSlots[0].transform.childCount * j) + i] = equipSlots[j].transform.GetChild(i).gameObject;
            }
        }
    }
    #endregion


    #region 이 스크립트를 들고 있는 오브젝트의 하위 요소 - Equip_Slot - Effect 을 초기 상태로 만드는 함수
    private void TurnAllEquipSlotDefaultStatus()
    {
        for (int i = 0; i < equipSlots.Length; i++)
        {
            // 임시로 Effect 태그 사용, EquipSlot 이라는 태그 추가?
            equipSlots[i].tag = "Effect";
            // 나중에 레이어 추가 생성시 변경
            equipSlots[i].layer = LayerMask.GetMask("Water");
            equipSlots[i].GetComponent<Image>().color = Color.white;
            equipSlots[i].SetActive(false);
            equipSlots[i].SetActive(true);
        }
        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].tag = "Default";
            effects[i].SetActive(false);
        }
    }
    #endregion


    #region 매개변수의 값으로 effects 인덱스를 찾아서 SetActive(false)로 만드는 함수
    private void TurnEquipEffectOff(int effectIdx_)
    {
        effects[effectIdx_].SetActive(false);
    }
    #endregion


    #region 매개변수의 값으로 effects 인덱스를 찾아서 SetActive(true)로 만드는 함수
    private void TurnEquipEffectOn(int effectIdx_)
    {
        effects[effectIdx_].SetActive(true);
    }
    #endregion

    // 슬롯의 콜라이더의 충돌을 감지

    // 현재 장착 중인 아이템들의 정보를 저장하는 기능
}
