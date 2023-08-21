using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public int level;
    // �ִ� ü�� 1�� 253
    public float heroHealthMax;
    // ü��
    public float heroHealth;
    // ����ġ
    public float heroEXP;
    // �ּ� ���� 1�� 4
    public float heroDamageMin;
    // �ִ� ���� 1�� 6
    public float heroDamageMax;
    // ��������
    public float heroDamageMagic;
    // ��ü����
    public float heroDamageAll;
    // ���
    public float heroDefense;
    // ����
    public float heroAttackSpeed;
    // ȸ��
    public float heroEvade;
    // �ݰ�
    public float heroCounter;
    // ����
    public float heroVamp;
    // ü��
    public float heroRegen;
    // �Ϸ��ȸ��
    public float heroRecovery;

    private void Awake()
    {
        // �⺻ ���� ��ġ
        heroHealthMax = 253;
        heroHealth = heroHealthMax;
        heroDamageMin = 4;
        heroDamageMax = 6;

        // �������� 0
        heroEXP = 0;
        heroDamageMagic = 0;
        heroDamageAll = 0;
        heroDefense = 0;
        heroAttackSpeed = 0;
        heroEvade = 0;
        heroCounter = 0;
        heroVamp = 0;
        heroRegen = 0;
        heroRecovery = 0;
        // �������� 0
    }

    public void AddStat(Item itemStat_)
    {
        // �ִ�ü�� ���ϱ�
        heroHealthMax += itemStat_.itemHP;
        // ü�µ� ���� �� ����
        heroHealth += itemStat_.itemHP;

        // �ش��ϴ� ���� ���ϱ�
        heroDamageMin += itemStat_.itemMinDamage;
        heroDamageMax += itemStat_.itemMaxDamage;

        heroDefense += itemStat_.itemDefense;
        heroDefense += itemStat_.itemSubDefense;

        heroDamageMagic += itemStat_.itemMagicDamage;
        heroDamageAll += itemStat_.itemDamageAll;
        heroAttackSpeed += itemStat_.itemAttackSpeed;
        heroEvade += itemStat_.itemEvade;
        heroCounter += itemStat_.itemCounter;
        heroVamp += itemStat_.itemVamp;
        heroRegen += itemStat_.itemRegen;
        // �ش��ϴ� ���� ���ϱ�
    }

    public void RemoveStat(Item itemStat_)
    {
        // �ִ�ü�� ����
        heroHealthMax -= itemStat_.itemHP;
        // ü�µ� ���� �� ����
        heroHealth -= itemStat_.itemHP;

        // �ش��ϴ� ���� ����
        heroDamageMin -= itemStat_.itemMinDamage;
        heroDamageMax -= itemStat_.itemMaxDamage;

        heroDefense -= itemStat_.itemDefense;
        heroDefense -= itemStat_.itemSubDefense;

        heroDamageMagic -= itemStat_.itemMagicDamage;
        heroDamageAll -= itemStat_.itemDamageAll;
        heroAttackSpeed -= itemStat_.itemAttackSpeed;
        heroEvade -= itemStat_.itemEvade;
        heroCounter -= itemStat_.itemCounter;
        heroVamp -= itemStat_.itemVamp;
        heroRegen -= itemStat_.itemRegen;
        // �ش��ϴ� ���� ���ϱ�
    }
}
