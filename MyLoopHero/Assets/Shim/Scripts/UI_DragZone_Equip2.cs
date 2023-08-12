using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DragZone_Equip2 : MonoBehaviour
{
    static public GameObject dragZone_Equip { get; private set; }
    static public GameObject[] equipSlots { get; private set; }
    static public GameObject[] effects { get; private set; }


    // �� ��ũ��Ʈ�� ��� �ִ� ������Ʈ�� ���� ��ҵ��� Ȯ��(��� ����, ����Ʈ ����)
    #region �� ��ũ��Ʈ�� ��� �ִ� ������Ʈ�� ���� ��� - Equip_Slot �� �迭�� ����
    private void MakeEquipSlotArray()
    {
        dragZone_Equip = this.gameObject;
        equipSlots = new GameObject[dragZone_Equip.transform.childCount];

        for (int i = 0; i < dragZone_Equip.transform.childCount; i++)
        {
            equipSlots[i] = gameObject.transform.GetChild(i).gameObject;
        }
    }
    #endregion


    #region �� ��ũ��Ʈ�� ��� �ִ� ������Ʈ�� ���� ��� - Equip_Slot - Effect �� �迭�� ����
    private void MakeEffectArray()
    {
        effects = new GameObject[(equipSlots.Length) * (equipSlots[0].transform.childCount)];

        for (int j = 0; j < equipSlots.Length; j++)
        {
            for (int i = 0; i < equipSlots[j].transform.childCount; i++)
            {
                effects[(equipSlots[0].transform.childCount * j) + i] = equipSlots[j].transform.GetChild(i).gameObject;
            }
        }
    }
    #endregion


    #region �� ��ũ��Ʈ�� ��� �ִ� ������Ʈ�� ���� ��� - Equip_Slot - Effect �� �ʱ� ���·� ����� �Լ�
    private void TurnAllEquipSlotDefaultStatus()
    {
        for (int i = 0; i < equipSlots.Length; i++)
        {
            // �ӽ÷� Effect �±� ���, EquipSlot �̶�� �±� �߰�?
            equipSlots[i].tag = "Effect";
            // ���߿� ���̾� �߰� ������ ����
            equipSlots[i].layer = LayerMask.GetMask("Water");
            equipSlots[i].GetComponent<Image>().color = Color.white;
            equipSlots[i].SetActive(false);
            equipSlots[i].SetActive(true);
        }
        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].tag = "Default";
            effects[i].SetActive(false);
        }
    }
    #endregion


    #region �Ű������� ������ effects �ε����� ã�Ƽ� SetActive(false)�� ����� �Լ�
    private void TurnEquipEffectOff(int effectIdx_)
    {
        effects[effectIdx_].SetActive(false);
    }
    #endregion


    #region �Ű������� ������ effects �ε����� ã�Ƽ� SetActive(true)�� ����� �Լ�
    private void TurnEquipEffectOn(int effectIdx_)
    {
        effects[effectIdx_].SetActive(true);
    }
    #endregion

    // ������ �ݶ��̴��� �浹�� ����

    // ���� ���� ���� �����۵��� ������ �����ϴ� ���
}
