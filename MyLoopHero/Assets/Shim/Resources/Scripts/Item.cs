using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // { ������ ������ ���� ���� (UI�� ǥ������ ����)
    public int itemID = default;
    public string itemType = default;
    public string itemSprite = default;
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
}
