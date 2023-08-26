using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
using static UnityEngine.GraphicsBuffer;

public class Item : MonoBehaviour
{
    // { ������ ������ ���� ���� (UI�� ǥ������ ����)
    public int itemID = default;
    public string itemType = default;
    public Sprite itemSprite = null;
    public float itemAbilityRatio = default;
    public int itemAbilityCount = default;
    // } ������ ������ ���� ���� (UI�� ǥ������ ����)

    // { �������� �ɷ�ġ �ʵ�
    //������ �̸�
    public string itemName = default;
    //������ ����
    public int itemLevel = default;
    //������ �ɷ�ġ : �ּ����� (����)
    public float itemMinDamage = default;
    //������ �ɷ�ġ : �ִ����� (����)
    public float itemMaxDamage = default;
    //������ �ɷ�ġ : HP (��)
    public float itemHP = default;
    //������ �ɷ�ġ : ���� (����)
    public float itemDefense = default;
    //������ �ɷ�ġ : ��������
    public float itemMagicDamage = default;
    //������ �ɷ�ġ : ���ݼӵ�
    public float itemAttackSpeed = default;
    //������ �ɷ�ġ : ��ü���� ����
    public float itemDamageAll = default;
    //������ �ɷ�ġ : �ݰ�
    public float itemCounter = default;
    //������ �ɷ�ġ : �ʴ� ȸ����
    public float itemRegen = default;
    //������ �ɷ�ġ : ȸ��
    public float itemEvade = default;
    //������ �ɷ�ġ : ����
    public float itemVamp = default;
    //������ �ɷ�ġ : ����
    public float itemSubDefense = default;
    // } �������� �ɷ�ġ �ʵ�

    // �������� ������ �״�� �������� �Լ�
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

    // �κ��丮 ���Կ� ��ġ�� �����ۿ� ������ ������ �Ѹ� ������ ���� �޾ƿ��� �Լ�
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

    // ������ ���� �Լ����� ���� �Լ�
    public void SetItem(Item target_)
    {
        SubsItemStats(target_);
        SetItemInfo();
        SetSubOptionList();
    }

    // ����, ����� ����� ������ ���� �����ϴ� �Լ�
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

    // �ο����� �� �� �ִ� �ɼǸ� �����ϴ� �Լ�
    private void SetSubOptionList()
    {
        // �οɼ��� ���� 8��
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


    // �ο��� �����ϰ� �����ϴ� �Լ�
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
