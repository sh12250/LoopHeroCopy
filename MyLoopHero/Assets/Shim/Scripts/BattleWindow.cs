using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleWindow : MonoBehaviour
{
    private GameObject battleWindow;
    private GameObject[] battleWindwowChild;
    private GameObject playerSprite;



    private void Awake()
    {
        
    }

    #region FindingEquipSlot
    private void MakeEquipSlotArray()
    {
        battleWindow = this.gameObject;
        battleWindwowChild = new GameObject[battleWindow.transform.childCount];

        for (int i = 0; i < battleWindow.transform.childCount; i++)
        {
            battleWindwowChild[i] = gameObject.transform.GetChild(i).gameObject;
        }
    }
    #endregion

    private void ShowBattleScreen() 
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) 
        {
            
        }
    }
}
