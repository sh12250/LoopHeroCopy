using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_HUD_Inventory : MonoBehaviour
{
    #region 인스턴스 생성
    private static UI_HUD_Inventory Inventory_Instance;
    // 싱글턴으로 만들기
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

    // 마우스의 화면 좌표 전환



    // { 마우스 다운 시 기능들
    // } 마우스 다운 시 기능들

    // { 마우스 드래그 시 기능들
    // } 마우스 드래그 시 기능들

    // { 마우스 업 시 기능들
    // } 마우스 업 시 기능들
}
