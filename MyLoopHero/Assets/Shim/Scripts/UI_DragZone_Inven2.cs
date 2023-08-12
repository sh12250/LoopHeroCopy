using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DragZone_Inven2 : MonoBehaviour
{
    private ItemBuilder itemBuilder;
    static public GameObject dragZone_Inven { get; private set; }
    static public GameObject[] invenSlots { get; private set; }
    static public GameObject[] effects { get; private set; }


    #region �� ��ũ��Ʈ�� ��� �ִ� ������Ʈ�� ���� ��� - Inven_Slot �� �迭�� ����
    private void MakeInvenSlotArray()
    {
        dragZone_Inven = this.gameObject;
        invenSlots = new GameObject[dragZone_Inven.transform.childCount];

        for (int i = 0; i < dragZone_Inven.transform.childCount; i++)
        {
            invenSlots[i] = gameObject.transform.GetChild(i).gameObject;
        }
    }
    #endregion


    #region �� ��ũ��Ʈ�� ��� �ִ� ������Ʈ�� ���� ��� - Equip_Slot - Effect �� �迭�� ����
    private void MakeEffectArray()
    {
        effects = new GameObject[(invenSlots.Length) * (invenSlots[0].transform.childCount)];

        for (int j = 0; j < invenSlots.Length; j++)
        {
            for (int i = 0; i < invenSlots[j].transform.childCount; i++)
            {
                effects[(invenSlots[0].transform.childCount * j) + i] = invenSlots[j].transform.GetChild(i).gameObject;
            }
        }
    }
    #endregion


    #region �� ��ũ��Ʈ�� ��� �ִ� ������Ʈ�� ���� ��� - Inven_Slot - Effect �� �ʱ� ���·� ����� �Լ�
    private void TurnAllInvenSlotDefaultStatus()
    {
        for (int i = 0; i < invenSlots.Length; i++)
        {
            invenSlots[i].tag = "ItemSlot";
            // ���߿� ���̾� �߰� ������ ����
            invenSlots[i].layer = LayerMask.GetMask("UI");
            invenSlots[i].GetComponent<Image>().sprite = null;
            invenSlots[i].GetComponent<Image>().color = Color.black;
            invenSlots[i].SetActive(false);
            invenSlots[i].SetActive(true);
        }
        for (int i = 0; i < effects.Length; i++) 
        {
            effects[i].tag = "Default";
            effects[i].SetActive(false);
        }
    }
    #endregion


    #region �Ű������� ������ effects �ε����� ã�Ƽ� SetActive(false)�� ����� �Լ�
    private void TurnInvenEffectOff(int effectIdx_)
    {
        effects[effectIdx_].SetActive(false);
    }
    #endregion


    #region �Ű������� ������ effects �ε����� ã�Ƽ� SetActive(true)�� ����� �Լ�
    private void TurnInvenEffectOn(int effectIdx_)
    {
        effects[effectIdx_].SetActive(true);
    }
    #endregion


    #region �κ��丮 �ȿ� �������� � �����ϴ��� üũ�ϴ� �Լ�
    private int CheckInventoryStatus() 
    {
        int itemCount = default;

        for (int i = 0; i < dragZone_Inven.transform.childCount; i++)
        {
            if (invenSlots[i].tag != "ItemSlot") 
            {
                itemCount++;
            }
            else 
            {
                /*Do Nothing*/
                continue;
            }
        }
        return itemCount;
    }
    #endregion


    #region �׽�Ʈ�� �Լ� : ����Ű ������ ������ �������� �ϳ� �κ��丮�� ����
    private void SaveItemToInventory(int itemCount_)
    {
        int randomIdx_ = Random.Range(0, itemBuilder.csvConverter.csvRowCount - 1);

        // �κ��丮�� �������� �ϳ��� ���� �� (invenSlots �迭�� ù ��° ��Ұ� ���� ��)
        if (itemCount_ == 0)
        {
            invenSlots[0].tag = itemBuilder.items[randomIdx_].tag;
            invenSlots[0].name = itemBuilder.items[randomIdx_].itemName;
            invenSlots[0].GetComponent<Image>().sprite = itemBuilder.items[randomIdx_].itemSprite;
            invenSlots[0].GetComponent<Image>().color = Color.white;
        }
        // �κ��丮�� �������� �� ������ �� (invenSlots �迭�� ������ ��Ұ� ���� ��)
        else if (itemCount_ == 12) 
        {
            for (int i = (dragZone_Inven.transform.childCount - 1); i > 0 ; i--)
            {
                invenSlots[i].tag = invenSlots[i - 1].tag;
                invenSlots[i].name = invenSlots[i - 1].name;
                invenSlots[i].GetComponent<Image>().sprite = invenSlots[i - 1].GetComponent<Image>().sprite;
                invenSlots[i].GetComponent<Image>().color = Color.white;
            }
            invenSlots[0].tag = itemBuilder.items[randomIdx_].tag;
            invenSlots[0].name = itemBuilder.items[randomIdx_].itemName;
            invenSlots[0].GetComponent<Image>().sprite = itemBuilder.items[randomIdx_].itemSprite;
            invenSlots[0].GetComponent<Image>().color = Color.white;
        }
        // �׿� ��Ȳ (�� ���� ����� �� ���� ������ ��)
        else 
        {
            for (int i = (itemCount_ - 1); i > 0; i--)
            {
                invenSlots[i].tag = invenSlots[i - 1].tag;
                invenSlots[i].name = invenSlots[i - 1].name;
                invenSlots[i].GetComponent<Image>().sprite = invenSlots[i - 1].GetComponent<Image>().sprite;
                invenSlots[i].GetComponent<Image>().color = Color.white;
            }
            invenSlots[0].tag = itemBuilder.items[randomIdx_].tag;
            invenSlots[0].name = itemBuilder.items[randomIdx_].itemName;
            invenSlots[0].GetComponent<Image>().sprite = itemBuilder.items[randomIdx_].itemSprite;
            invenSlots[0].GetComponent<Image>().color = Color.white;
        }
    }
    #endregion

    // �κ� ���� ���� ������ ����ϴ� ���
}
