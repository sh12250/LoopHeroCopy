using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // { ���� ��������Ʈ (�ִϸ��̼� �Ⱦ��� ���ؼ� 6���� ���¸� ����)
    public Sprite enemyIdle = null;
    public Sprite enemyCharge = null;
    public Sprite enemyAttack = null;
    public Sprite enemyHurt_0 = null;
    public Sprite enemyHurt_1 = null;
    public Sprite enemyDeath = null;
    // } ���� ��������Ʈ

    // { ���� �ɷ�ġ
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
    // } ���� �ɷ�ġ
}
