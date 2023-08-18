using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
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
    public float heroDefence;
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
