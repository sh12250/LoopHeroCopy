using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BossBattleWindow : MonoBehaviour
{
    public GameObject bossBattleWindow;

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

    public GameObject bossSpace;
    public TMP_Text bossStatus;
    public TMP_Text bossPlus;
    public TMP_Text bossMinus;

    public AnimationClip bossEncounterAni;

    public Sprite bossIdleSprite;
    public Sprite bossChargeSprite;
    public Sprite bossAttackSprite;
    public Sprite bossHurt0Sprite;
    public Sprite bossHurt1Sprite;
    public Sprite bossDeathSprite;

    private void Awake()
    {
        CheckWindowObjects();
        LoadPlayerSprite();
        LoadBossSprite();
    }

    private void CheckWindowObjects()
    {
        bossBattleWindow = this.gameObject;

        playerSpace = bossBattleWindow.transform.Find("PlayerSprite_Boss").gameObject;
        playerStatus = playerSpace.transform.GetComponentsInChildren<TMP_Text>()[0];
        playerPlus = playerSpace.transform.GetComponentsInChildren<TMP_Text>()[1];
        playerMinus = playerSpace.transform.GetComponentsInChildren<TMP_Text>()[2];

        bossSpace = bossBattleWindow.transform.Find("BossSprite_Boss").gameObject;
        bossStatus = bossSpace.transform.GetComponentsInChildren<TMP_Text>()[0];
        bossPlus = bossSpace.transform.GetComponentsInChildren<TMP_Text>()[1];
        bossMinus = bossSpace.transform.GetComponentsInChildren<TMP_Text>()[2];
    }


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


    #region 보스의 스프라이트와 애니메이션을 받아오는 함수
    private void LoadBossSprite()
    {
        bossIdleSprite = Resources.Load<Sprite>("Sprites/BattleSprite/Boss/boss_idle");
        bossChargeSprite = Resources.Load<Sprite>("Sprites/BattleSprite/Boss/boss_charge");
        bossAttackSprite = Resources.Load<Sprite>("Sprites/BattleSprite/Boss/boss_attack");
        bossHurt0Sprite = Resources.Load<Sprite>("Sprites/BattleSprite/Boss/boss_hurt_0");
        bossHurt1Sprite = Resources.Load<Sprite>("Sprites/BattleSprite/Boss/boss_hurt_1");
        bossDeathSprite = Resources.Load<Sprite>("Sprites/BattleSprite/Boss/boss_death");
        bossEncounterAni = Resources.Load<AnimationClip>("Sprites/Anims/boss_encounter/BossAni");
    }
    #endregion


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



    #region 보스 스프라이트를 idle 로 변경
    public void ChangeBossIdle()
    {
        bossSpace.transform.GetComponent<Image>().sprite = bossIdleSprite;
    }
    #endregion

    #region 보스 스프라이트를 charge 로 변경
    public void ChangeBossCharge()
    {
        bossSpace.transform.GetComponent<Image>().sprite = bossChargeSprite;
    }
    #endregion

    #region 보스 스프라이트를 attack 로 변경
    public void ChangeBossAttack()
    {
        bossSpace.transform.GetComponent<Image>().sprite = bossAttackSprite;
    }
    #endregion

    #region 보스 스프라이트를 hurt0 로 변경
    public void ChangeBossHurt0()
    {
        bossSpace.transform.GetComponent<Image>().sprite = bossHurt0Sprite;
    }
    #endregion

    #region 보스 스프라이트를 hurt1 로 변경
    public void ChangeBossHurt1()
    {
        bossSpace.transform.GetComponent<Image>().sprite = bossHurt1Sprite;
    }
    #endregion

    #region 보스 스프라이트를 death 로 변경
    public void ChangeBossDeath()
    {
        bossSpace.transform.GetComponent<Image>().sprite = bossDeathSprite;
    }
    #endregion
}
