using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // { 아이템 데이터 관련 변수 (UI에 표현되지 않음)
    public int itemID = default;
    public string itemType = default;
    public string itemSprite = default;
    public float itemAbilityRatio = default;
    public int itemAbilityCount = default;
    // } 아이템 데이터 관련 변수 (UI에 표현되지 않음)


    // { 아이템의 능력치 필드
    //아이템 이름
    public string itemName = default;
    //아이템 레벨
    public int itemLevel = default;
    //아이템 능력치 : 최소피해 (무기)
    public float itemMinDamage = default;
    //아이템 능력치 : 최대피해 (무기)
    public float itemMaxDamage = default;
    //아이템 능력치 : HP (방어구)
    public float itemHP = default;
    //아이템 능력치 : 방어력 (방패)
    public float itemDefense = default;
    //아이템 능력치 : 순수피해
    public float itemMagicDamage = default;
    //아이템 능력치 : 공격속도
    public float itemAttackSpeed = default;
    //아이템 능력치 : 전체에게 피해
    public float itemDamageAll = default;
    //아이템 능력치 : 반격
    public float itemCounter = default;
    //아이템 능력치 : 초당 회복량
    public float itemRegen = default;
    //아이템 능력치 : 회피
    public float itemEvade = default;
    //아이템 능력치 : 흡혈
    public float itemVamp = default;
    //아이템 능력치 : 방어력
    public float itemSubDefense = default;
    // } 아이템의 능력치 필드
}
