using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleWindow : MonoBehaviour
{
    private GameObject battleWindow;

    private GameObject[] battleWindwowChild;
    private List<GameObject> monsterCheck;

    private GameObject playerSprite;
    private GameObject monsterSprite1;
    private GameObject monsterSprite2;
    private GameObject monsterSprite3;
    private GameObject monsterSprite4;
    private GameObject monsterSprite5;


    private void Awake()
    {
        MakeEquipSlotArray();
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

        playerSprite = gameObject.transform.Find("PlayerSprite").gameObject;
        monsterSprite1 = gameObject.transform.Find("Monster1").gameObject;
        monsterSprite2 = gameObject.transform.Find("Monster2").gameObject;
        monsterSprite3 = gameObject.transform.Find("Monster3").gameObject;
        monsterSprite4 = gameObject.transform.Find("Monster4").gameObject;
        monsterSprite5 = gameObject.transform.Find("Monster5").gameObject;
    }
    #endregion

    private void ShowBattleScreen()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {

        }
    }

    private void CheckMonsterSprite() 
    {



    }

}
