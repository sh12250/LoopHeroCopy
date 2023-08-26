using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using static UnityEngine.GraphicsBuffer;

public class Item : MonoBehaviour
{
    // { 아이템 데이터 관련 변수 (UI에 표현되지 않음)
    public int itemID = default;
    public string itemType = default;
    public Sprite itemSprite = null;
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

    // 아이템의 스탯을 그대로 베껴오는 함수
    public void CopyItemValues(Item target_)
    {
        itemHP = target_.itemHP;

        itemMinDamage = target_.itemMinDamage;
        itemMaxDamage = target_.itemMaxDamage;

        itemDefense = target_.itemDefense;
        itemSubDefense = target_.itemSubDefense;

        itemMagicDamage = target_.itemMagicDamage;
        itemDamageAll = target_.itemDamageAll;
        itemAttackSpeed = target_.itemAttackSpeed;
        itemEvade = target_.itemEvade;
        itemCounter = target_.itemCounter;
        itemVamp = target_.itemVamp;
        itemRegen = target_.itemRegen;
    }

    // 인벤토리 슬롯에 위치한 아이템에 아이템 빌더가 뿌린 아이템 정보 받아오는 함수
    public void SubsItemStats(Item target_)
    {
        itemType = target_.itemType;
        itemLevel = target_.itemLevel + GameManager.instance.loopCnt;
        itemAbilityCount = target_.itemAbilityCount;
        itemAbilityRatio = target_.itemAbilityRatio;

        itemMinDamage = target_.itemMinDamage;
        itemMaxDamage = target_.itemMaxDamage;

        itemHP = target_.itemHP;

        itemDefense = target_.itemDefense;

        itemMagicDamage = target_.itemMagicDamage;
        itemDamageAll = target_.itemDamageAll;
        itemAttackSpeed = target_.itemAttackSpeed;
        itemSubDefense = target_.itemSubDefense;
        itemCounter = target_.itemCounter;
        itemRegen = target_.itemRegen;
        itemEvade = target_.itemEvade;
        itemVamp = target_.itemVamp;
    }

    // 아이템 셋팅 함수들을 묶은 함수
    public void SetItem(Item target_)
    {
        SubsItemStats(target_);
        SetItemInfo();
        SetSubOptionList();
    }

    // 레벨, 레어도에 비례한 아이템 스탯 설정하는 함수
    private void SetItemInfo()
    {
        switch (itemType)
        {
            case "weapon":
                itemMinDamage *= itemLevel * itemAbilityRatio;
                itemMaxDamage *= itemLevel * itemAbilityRatio;
                itemHP = 0;
                itemDefense = 0;

                break;
            case "ring":
                itemMinDamage = 0;
                itemMaxDamage = 0;
                itemHP = 0;
                itemDefense = 0;

                itemAbilityCount += 1;

                break;
            case "shield":
                itemDefense *= itemLevel * itemAbilityRatio;
                itemMinDamage = 0;
                itemMaxDamage = 0;
                itemHP = 0;

                break;
            case "armor":
                itemHP *= itemLevel * itemAbilityRatio;
                itemMinDamage = 0;
                itemMaxDamage = 0;
                itemDefense = 0;

                break;
        }
    }

    private const int SUB_OPTION_COUNT = 8;

    // 부옵으로 들어갈 수 있는 옵션만 선별하는 함수
    private void SetSubOptionList()
    {
        // 부옵션의 수는 8개
        float[] validSub_ = new float[SUB_OPTION_COUNT];

        validSub_[0] = itemMagicDamage;
        validSub_[1] = itemDamageAll;
        validSub_[2] = itemAttackSpeed;
        validSub_[3] = itemSubDefense;
        validSub_[4] = itemCounter;
        validSub_[5] = itemRegen;
        validSub_[6] = itemEvade;
        validSub_[7] = itemVamp;

        for (int i = 0; i < SUB_OPTION_COUNT; i++)
        {
            if (validSub_[i] == -1)
            {
                validSub_[i] = 0;
            }
        }

        itemMagicDamage = 0;
        itemDamageAll = 0;
        itemAttackSpeed = 0;
        itemSubDefense = 0;
        itemCounter = 0;
        itemRegen = 0;
        itemEvade = 0;
        itemVamp = 0;

        SetSubOption(validSub_, itemAbilityCount);
    }


    // 부옵을 랜덤하게 선별하는 함수
    private void SetSubOption(float[] validSub_, int count_)
    {
        if (count_ == 1)
        {
            return;
        }

        int randIdx = Random.Range(0, SUB_OPTION_COUNT);

        switch (randIdx)
        {
            case 0:
                if (itemMagicDamage == 0)
                {
                    itemMagicDamage = validSub_[randIdx] * itemLevel * itemAbilityRatio;
                    count_ -= 1;
                }
                else { /* DoNothing */ }

                break;
            case 1:
                if (itemDamageAll == 0)
                {
                    itemDamageAll = validSub_[randIdx] * itemLevel * itemAbilityRatio;
                    count_ -= 1;
                }
                else { /* DoNothing */ }

                break;
            case 2:
                if (itemAttackSpeed == 0)
                {
                    itemAttackSpeed = validSub_[randIdx] * itemLevel * itemAbilityRatio;
                    count_ -= 1;
                }
                else { /* DoNothing */ }

                break;
            case 3:
                if (itemSubDefense == 0)
                {
                    itemSubDefense = validSub_[randIdx] * itemLevel * itemAbilityRatio;
                    count_ -= 1;
                }
                else { /* DoNothing */ }

                break;
            case 4:
                if (itemCounter == 0)
                {
                    itemCounter = validSub_[randIdx] * itemLevel * itemAbilityRatio;
                    count_ -= 1;
                }
                else { /* DoNothing */ }

                break;
            case 5:
                if (itemRegen == 0)
                {
                    itemRegen = validSub_[randIdx] * itemLevel * itemAbilityRatio;
                    count_ -= 1;
                }
                else { /* DoNothing */ }

                break;
            case 6:
                if (itemEvade == 0)
                {
                    itemEvade = validSub_[randIdx] * itemLevel * itemAbilityRatio;
                    count_ -= 1;
                }
                else { /* DoNothing */ }

                break;
            case 7:
                if (itemVamp == 0)
                {
                    itemVamp = validSub_[randIdx] * itemLevel * itemAbilityRatio;
                    count_ -= 1;
                }
                else { /* DoNothing */ }

                break;
        }

        SetSubOption(validSub_, count_);
    }
}
