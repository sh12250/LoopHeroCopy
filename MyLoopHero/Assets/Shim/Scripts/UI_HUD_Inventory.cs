using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_HUD_Inventory : MonoBehaviour
{
    #region �ν��Ͻ� ����
    private static UI_HUD_Inventory Inventory_Instance;
    // �̱������� �����
    public static UI_HUD_Inventory instance
    {
        get
        {
            if (Inventory_Instance == null)
            {
                Inventory_Instance = FindObjectOfType<UI_HUD_Inventory>();
            }
            return Inventory_Instance;
        }
    }
    #endregion

    // ���콺�� ȭ�� ��ǥ ��ȯ



    // { ���콺 �ٿ� �� ��ɵ�
    // } ���콺 �ٿ� �� ��ɵ�

    // { ���콺 �巡�� �� ��ɵ�
    // } ���콺 �巡�� �� ��ɵ�

    // { ���콺 �� �� ��ɵ�
    // } ���콺 �� �� ��ɵ�
}
