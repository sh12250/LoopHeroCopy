using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private static BattleManager converter_Instance;
    // 싱글턴으로 만들기
    public static BattleManager instance
    {
        get
        {
            if (converter_Instance == null)
            {
                converter_Instance = FindObjectOfType<BattleManager>();
            }
            return converter_Instance;
        }
    }

    private void Update()
    {

    }

    private void UpdatePlayerInfo() 
    {
    
    }

    private void UpdateMonsterInfo() 
    {
    
    }

    private void PopUpWindow() 
    {
    
    }
}
