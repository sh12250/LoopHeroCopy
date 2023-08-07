using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    // { 아이템의 능력치 필드
    //아이템 종류

    enum ItemName 
    {
        
    }
    //아이템 레벨
    public int itemLevel { get; private set; }
    //아이템 능력치 피해 (무기)
    public float itemDamage { get; private set; }
    //아이템 능력치 최대HP (방어구)
    public float itemMaxHP { get; private set; }
    //아이템 능력치 방어력 (방패)
    public float itemDefense { get; private set; }
    //아이템 능력치 순수피해
    public float itemMagicDamage { get; private set; }
    //아이템 능력치 공격속도
    public float itemAttackSpeed { get; private set; }
    //아이템 능력치 전체에게 피해
    public float itemDamageAll { get; private set; }
    //아이템 능력치 반격
    public float itemCounter { get; private set; }
    //아이템 능력치 초당 회복량
    public float itemRegen { get; private set; }
    //아이템 능력치 회피
    public float itemEvade { get; private set; }
    //아이템 능력치 흡혈
    public float itemVampiric { get; private set; }
    //아이템 능력치 방어력
    public float itemSubDefense { get; private set; }
    // } 아이템의 능력치 필드

    // { 아이템 생성
    private void MakeItem() 
    {
        
    }
    // } 아이템 생성
}
