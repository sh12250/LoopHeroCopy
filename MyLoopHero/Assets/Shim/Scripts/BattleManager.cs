using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    private static BattleManager converter_Instance;
    // �̱������� �����
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
