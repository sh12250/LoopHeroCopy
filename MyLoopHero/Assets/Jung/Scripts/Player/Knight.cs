using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
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
    public float heroDefence;
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
        heroDefence = 0;
        heroAttackSpeed = 0;
        heroEvade = 0;
        heroCounter = 0;
        heroVamp = 0;
        heroRegen = 0;
        heroRecovery = 0;
    }

    public void AddStat(Item equip_)
    {

    }
}
