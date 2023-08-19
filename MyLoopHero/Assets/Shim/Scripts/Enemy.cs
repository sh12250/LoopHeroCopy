using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // { 몬스터 스프라이트 (애니메이션 안쓰기 위해서 6가지 상태만 선택)
    public Sprite enemyIdle = null;
    public Sprite enemyCharge = null;
    public Sprite enemyAttack = null;
    public Sprite enemyHurt_0 = null;
    public Sprite enemyHurt_1 = null;
    public Sprite enemyDeath = null;
    // } 몬스터 스프라이트

    // { 몬스터 능력치
    public int enemyID = default;
    public string enemyName = default;
    public float enemyHP = default;
    public float enemyDMG = default;
    public float enemyDEF = default;
    public float enemySpeed = default;
    public float enemyEvade = default;
    public float enemyRegen = default;
    public float enemyItemChance = default;
    public float enemyItemTier = default;
    // } 몬스터 능력치
}
