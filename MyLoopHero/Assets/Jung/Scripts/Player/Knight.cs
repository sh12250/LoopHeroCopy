using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    public int level;
    // 최대 체력 1렙 253
    public float heroHealthMax;
    // 체력
    public float heroHealth;
    // 경험치
    public float heroEXP;
    // 최소 피해 1렙 4
    public float heroDamageMin;
    // 최대 피해 1렙 6
    public float heroDamageMax;
    // 순수피해
    public float heroDamageMagic;
    // 전체피해
    public float heroDamageAll;
    // 방어
    public float heroDefense;
    // 공속
    public float heroAttackSpeed;
    // 회피
    public float heroEvade;
    // 반격
    public float heroCounter;
    // 흡혈
    public float heroVamp;
    // 체젠
    public float heroRegen;
    // 하루당회복
    public float heroRecovery;

    private void Awake()
    {
        // 기본 제공 수치
        heroHealthMax = 253;
        heroHealth = heroHealthMax;
        heroDamageMin = 4;
        heroDamageMax = 6;

        // 나머지는 0
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
        // 나머지는 0
    }

    public void AddStat(Item itemStat_)
    {
        // 최대체력 더하기
        heroHealthMax += itemStat_.itemHP;
        // 체력도 같은 량 증가
        heroHealth += itemStat_.itemHP;

        // 해당하는 스탯 더하기
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
        // 해당하는 스탯 더하기
    }

    public void RemoveStat(Item itemStat_)
    {
        // 최대체력 빼기
        heroHealthMax -= itemStat_.itemHP;
        // 체력도 같은 량 감소
        heroHealth -= itemStat_.itemHP;

        // 해당하는 스탯 빼기
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
        // 해당하는 스탯 더하기
    }
}
