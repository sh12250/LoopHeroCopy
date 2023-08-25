
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleWindow : MonoBehaviour
{
    public GameObject battleWindow;

    public GameObject playerSpace;
    public TMP_Text playerStatus;
    public TMP_Text playerPlus;
    public TMP_Text playerMinus;

    public Sprite idleSprite;
    public Sprite chargeSprite;
    public Sprite attackSprite;
    public Sprite hurt0Sprite;
    public Sprite hurt1Sprite;
    public Sprite deathSprite;

    public GameObject[] monsterSpaces;
    public TMP_Text[] monsterStatus;
    public TMP_Text[] monsterPlus;
    public TMP_Text[] monsterMinus;

    private string monsterMaxHP;


    private void Awake()
    {
        CheckWindowObjects();
        LoadPlayerSprite();
    }

    
    private void InitMonsterArrays()
    {
        monsterSpaces = new GameObject[battleWindow.transform.childCount - 3];
        monsterStatus = new TMP_Text[battleWindow.transform.childCount - 3];
        monsterPlus = new TMP_Text[battleWindow.transform.childCount - 3];
        monsterMinus = new TMP_Text[battleWindow.transform.childCount - 3];
    }

    #region 이 스크립트를 들고 있는 오브젝트(배틀 윈도우) 하위의 게임 오브젝트들을 설정
    private void CheckWindowObjects()
    {
        battleWindow = this.gameObject;

        playerSpace = battleWindow.transform.Find("PlayerSprite").gameObject;
        playerStatus = playerSpace.transform.GetComponentsInChildren<TMP_Text>()[0];
        playerPlus = playerSpace.transform.GetComponentsInChildren<TMP_Text>()[1];
        playerMinus = playerSpace.transform.GetComponentsInChildren<TMP_Text>()[2];

        InitMonsterArrays();

        for (int i = 0; i < battleWindow.transform.childCount - 3; i++)
        {
            monsterSpaces[i] = gameObject.transform.GetChild(i + 3).gameObject;
            monsterStatus[i] = monsterSpaces[i].transform.GetComponentsInChildren<TMP_Text>()[0];
            monsterPlus[i] = monsterSpaces[i].transform.GetComponentsInChildren<TMP_Text>()[1];
            monsterMinus[i] = monsterSpaces[i].transform.GetComponentsInChildren<TMP_Text>()[2];
        }
    }
    #endregion

    #region 플레이어의 스프라이트를 받아오는 함수
    private void LoadPlayerSprite()
    {
        idleSprite = Resources.Load<Sprite>("Sprites/BattleSprite/Hero/hero_idle");
        chargeSprite = Resources.Load<Sprite>("Sprites/BattleSprite/Hero/hero_charge");
        attackSprite = Resources.Load<Sprite>("Sprites/BattleSprite/Hero/hero_attack");
        hurt0Sprite = Resources.Load<Sprite>("Sprites/BattleSprite/Hero/hero_hurt_0");
        hurt1Sprite = Resources.Load<Sprite>("Sprites/BattleSprite/Hero/hero_hurt_1");
        deathSprite = Resources.Load<Sprite>("Sprites/BattleSprite/Hero/hero_death");
    }
    #endregion

    //#region 플레이어의 TMP 텍스트를 설정해주는 함수
    //public void ShowPlayerHPText(Knight knight_) 
    //{
    //    BattleManager.instance.GetPlayerInfo();
    //    playerStatus.text = knight_.heroHealth.ToString("F0") +
    //        "/" + knight_.heroHealthMax.ToString("F0");
    //}
    //#endregion

    //#region 플레이어 Plus TMP 텍스트를 설정해주는 함수
    //public void ShowPlayerPlusText(Knight knight_) 
    //{
    //    BattleManager.instance.GetPlayerInfo();
    //    playerPlus.text = knight_.
    //}
    //#endregion

    //#region 플레이어 Minus TMP 텍스트를 설정해주는 함수
    //public void ShowPlayerMinusText(Knight knight_)
    //{
    //    BattleManager.instance.GetPlayerInfo();

    //}
    //#endregion

    //#region 몬스터의 TMP 텍스트를 설정해주는 함수
    //public void ShowEnemyHPText(List<Enemy> enemies_)
    //{
    //    for (int i = 0; i < enemies_.Count - 1; i++) 
    //    {
    //        monsterMaxHP = enemies_[i].enemyHP.ToString("F0");
    //        monsterStatus[i].text = enemies_[i].enemyHP.ToString("F0") +
    //            "/" + monsterMaxHP;
    //    }
    //}
    //#endregion

    #region 플레이어 스프라이트를 idle 로 변경
    public void ChangePlayerIdle() 
    {
        playerSpace.transform.GetComponent<Image>().sprite = idleSprite;
    }
    #endregion

    #region 플레이어 스프라이트를 charge 로 변경
    public void ChangePlayerCharge()
    {
        playerSpace.transform.GetComponent<Image>().sprite = chargeSprite;
    }
    #endregion

    #region 플레이어 스프라이트를 attack 로 변경
    public void ChangePlayerAttack()
    {
        playerSpace.transform.GetComponent<Image>().sprite = attackSprite;
    }
    #endregion

    #region 플레이어 스프라이트를 hurt0 로 변경
    public void ChangePlayerHurt0()
    {
        playerSpace.transform.GetComponent<Image>().sprite = hurt0Sprite;
    }
    #endregion

    #region 플레이어 스프라이트를 hurt1 로 변경
    public void ChangePlayerHurt1()
    {
        playerSpace.transform.GetComponent<Image>().sprite = hurt1Sprite;
    }
    #endregion

    #region 플레이어 스프라이트를 death 로 변경
    public void ChangePlayerDeath()
    {
        playerSpace.transform.GetComponent<Image>().sprite = deathSprite;
    }
    #endregion

    #region 적 스프라이트를 idle 로 변경
    public void ChangeEnemyIdle(Enemy enemy_)
    {
        for (int i = 0; i < BattleManager.instance.monsterCount; i++) 
        {
            if (enemy_.enemyID == 100)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[0].enemyIdle;
            }
            else if (enemy_.enemyID == 101)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[1].enemyIdle;
            }
            else if (enemy_.enemyID == 102)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[2].enemyIdle;
            }
            else if (enemy_.enemyID == 103)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[3].enemyIdle;
            }
            else if (enemy_.enemyID == 104)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[4].enemyIdle;
            }
            else if (enemy_.enemyID == 105)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[5].enemyIdle;
            }
            else if (enemy_.enemyID == 106)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[6].enemyIdle;
            }
            else if (enemy_.enemyID == 107)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[7].enemyIdle;
            }
            else if (enemy_.enemyID == 108)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[8].enemyIdle;
            }
            else if (enemy_.enemyID == 109)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[9].enemyIdle;
            }
            else if (enemy_.enemyID == 110)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[10].enemyIdle;
            }
            else if (enemy_.enemyID == 111)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[11].enemyIdle;
            }
            else if (enemy_.enemyID == 112)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[12].enemyIdle;
            }
            else if (enemy_.enemyID == 113)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[13].enemyIdle;

            }
            else 
            {
                /*Do Nothing*/
            }
        }
    }
    #endregion

    #region 적 스프라이트를 charge 로 변경
    public void ChangeEnemyCharge(Enemy enemy_)
    {
        for (int i = 0; i < BattleManager.instance.monsterCount; i++)
        {
            if (enemy_.enemyID == 100)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[0].enemyCharge;
            }
            else if (enemy_.enemyID == 101)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[1].enemyCharge;
            }
            else if (enemy_.enemyID == 102)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[2].enemyCharge;
            }
            else if (enemy_.enemyID == 103)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[3].enemyCharge;
            }
            else if (enemy_.enemyID == 104)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[4].enemyCharge;
            }
            else if (enemy_.enemyID == 105)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[5].enemyCharge;
            }
            else if (enemy_.enemyID == 106)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[6].enemyCharge;
            }
            else if (enemy_.enemyID == 107)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[7].enemyCharge;
            }
            else if (enemy_.enemyID == 108)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[8].enemyCharge;
            }
            else if (enemy_.enemyID == 109)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[9].enemyCharge;
            }
            else if (enemy_.enemyID == 110)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[10].enemyCharge;
            }
            else if (enemy_.enemyID == 111)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[11].enemyCharge;
            }
            else if (enemy_.enemyID == 112)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[12].enemyCharge;
            }
            else if (enemy_.enemyID == 113)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[13].enemyCharge;
            }
            else
            {
                /*Do Nothing*/
            }
        }
    }
    #endregion

    #region 적 스프라이트를 attack 로 변경
    public void ChangeEnemyAttack(Enemy enemy_)
    {
        for (int i = 0; i < BattleManager.instance.monsterCount; i++)
        {
            if (enemy_.enemyID == 100)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[0].enemyAttack;
            }
            else if (enemy_.enemyID == 101)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[1].enemyAttack;
            }
            else if (enemy_.enemyID == 102)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[2].enemyAttack;
            }
            else if (enemy_.enemyID == 103)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[3].enemyAttack;
            }
            else if (enemy_.enemyID == 104)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[4].enemyAttack;
            }
            else if (enemy_.enemyID == 105)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[5].enemyAttack;
            }
            else if (enemy_.enemyID == 106)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[6].enemyAttack;
            }
            else if (enemy_.enemyID == 107)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[7].enemyAttack;
            }
            else if (enemy_.enemyID == 108)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[8].enemyAttack;
            }
            else if (enemy_.enemyID == 109)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[9].enemyAttack;
            }
            else if (enemy_.enemyID == 110)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[10].enemyAttack;
            }
            else if (enemy_.enemyID == 111)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[11].enemyAttack;
            }
            else if (enemy_.enemyID == 112)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[12].enemyAttack;
            }
            else if (enemy_.enemyID == 113)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[13].enemyAttack;
            }
            else
            {
                /*Do Nothing*/
            }
        }
    }
    #endregion

    #region 적 스프라이트를 hurt0 로 변경
    public void ChangeEnemyHurt0(Enemy enemy_)
    {
        for (int i = 0; i < BattleManager.instance.monsterCount; i++)
        {
            if (enemy_.enemyID == 100)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[0].enemyHurt_0;
            }
            else if (enemy_.enemyID == 101)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[1].enemyHurt_0;
            }
            else if (enemy_.enemyID == 102)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[2].enemyHurt_0;
            }
            else if (enemy_.enemyID == 103)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[3].enemyHurt_0;
            }
            else if (enemy_.enemyID == 104)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[4].enemyHurt_0;
            }
            else if (enemy_.enemyID == 105)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[5].enemyHurt_0;
            }
            else if (enemy_.enemyID == 106)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[6].enemyHurt_0;
            }
            else if (enemy_.enemyID == 107)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[7].enemyHurt_0;
            }
            else if (enemy_.enemyID == 108)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[8].enemyHurt_0;
            }
            else if (enemy_.enemyID == 109)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[9].enemyHurt_0;
            }
            else if (enemy_.enemyID == 110)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[10].enemyHurt_0;
            }
            else if (enemy_.enemyID == 111)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[11].enemyHurt_0;
            }
            else if (enemy_.enemyID == 112)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[12].enemyHurt_0;
            }
            else if (enemy_.enemyID == 113)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[13].enemyHurt_0;
            }
            else
            {
                /*Do Nothing*/
            }
        }
    }
    #endregion

    #region 적 스프라이트를 hurt1 로 변경
    public void ChangeEnemyHurt1(Enemy enemy_)
    {
        for (int i = 0; i < BattleManager.instance.monsterCount; i++)
        {
            if (enemy_.enemyID == 100)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[0].enemyHurt_1;
            }
            else if (enemy_.enemyID == 101)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[1].enemyHurt_1;
            }
            else if (enemy_.enemyID == 102)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[2].enemyHurt_1;
            }
            else if (enemy_.enemyID == 103)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[3].enemyHurt_1;
            }
            else if (enemy_.enemyID == 104)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[4].enemyHurt_1;
            }
            else if (enemy_.enemyID == 105)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[5].enemyHurt_1;
            }
            else if (enemy_.enemyID == 106)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[6].enemyHurt_1;
            }
            else if (enemy_.enemyID == 107)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[7].enemyHurt_1;
            }
            else if (enemy_.enemyID == 108)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[8].enemyHurt_1;
            }
            else if (enemy_.enemyID == 109)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[9].enemyHurt_1;
            }
            else if (enemy_.enemyID == 110)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[10].enemyHurt_1;
            }
            else if (enemy_.enemyID == 111)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[11].enemyHurt_1;
            }
            else if (enemy_.enemyID == 112)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[12].enemyHurt_1;
            }
            else if (enemy_.enemyID == 113)
            {
                
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[13].enemyHurt_1;
            }
            else
            {
                /*Do Nothing*/
            }
        }
    }
    #endregion

    #region 적 스프라이트를 death 로 변경
    public void ChangeEnemyDeath(Enemy enemy_)
    {
        for (int i = 0; i < BattleManager.instance.monsterCount; i++)
        {
            if (enemy_.enemyID == 100)
            {
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[0].enemyDeath;
            }
            else if (enemy_.enemyID == 101)
            {
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[1].enemyDeath;
            }
            else if (enemy_.enemyID == 102)
            {
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[2].enemyDeath;
            }
            else if (enemy_.enemyID == 103)
            {
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[3].enemyDeath;
            }
            else if (enemy_.enemyID == 104)
            {
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[4].enemyDeath;
            }
            else if (enemy_.enemyID == 105)
            {
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[5].enemyDeath;
            }
            else if (enemy_.enemyID == 106)
            {
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[6].enemyDeath;
            }
            else if (enemy_.enemyID == 107)
            {
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[7].enemyDeath;
            }
            else if (enemy_.enemyID == 108)
            {
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[8].enemyDeath;
            }
            else if (enemy_.enemyID == 109)
            {
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[9].enemyDeath;
            }
            else if (enemy_.enemyID == 110)
            {
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[10].enemyDeath;
            }
            else if (enemy_.enemyID == 111)
            {
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[11].enemyDeath;
            }
            else if (enemy_.enemyID == 112)
            {
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[12].enemyDeath;
            }
            else if (enemy_.enemyID == 113)
            {
                monsterSpaces[i].transform.GetComponent<Image>().sprite = MonsterSpawner.instance.enemies[13].enemyDeath;
            }
            else
            {
                /*Do Nothing*/
            }
        }
    }
    #endregion

    //#region 적 스프라이트를 Null 로 변경
    //public void ChangeEnemyNull()
    //{
    //    for (int i = 0; i < BattleManager.instance.monsterCount; i++)
    //    {
    //        monsterSpaces[i].transform.GetComponent<Image>().color = Color.black;
    //    }
    //}
    //#endregion
}
