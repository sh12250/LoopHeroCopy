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


    #region �÷��̾��� ��������Ʈ�� �޾ƿ��� �Լ�
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


    #region ������ ��������Ʈ�� �ִϸ��̼��� �޾ƿ��� �Լ�
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


    #region �÷��̾� ��������Ʈ�� idle �� ����
    public void ChangePlayerIdle()
    {
        playerSpace.transform.GetComponent<Image>().sprite = idleSprite;
    }
    #endregion

    #region �÷��̾� ��������Ʈ�� charge �� ����
    public void ChangePlayerCharge()
    {
        playerSpace.transform.GetComponent<Image>().sprite = chargeSprite;
    }
    #endregion

    #region �÷��̾� ��������Ʈ�� attack �� ����
    public void ChangePlayerAttack()
    {
        playerSpace.transform.GetComponent<Image>().sprite = attackSprite;
    }
    #endregion

    #region �÷��̾� ��������Ʈ�� hurt0 �� ����
    public void ChangePlayerHurt0()
    {
        playerSpace.transform.GetComponent<Image>().sprite = hurt0Sprite;
    }
    #endregion

    #region �÷��̾� ��������Ʈ�� hurt1 �� ����
    public void ChangePlayerHurt1()
    {
        playerSpace.transform.GetComponent<Image>().sprite = hurt1Sprite;
    }
    #endregion

    #region �÷��̾� ��������Ʈ�� death �� ����
    public void ChangePlayerDeath()
    {
        playerSpace.transform.GetComponent<Image>().sprite = deathSprite;
    }
    #endregion



    #region ���� ��������Ʈ�� idle �� ����
    public void ChangeBossIdle()
    {
        bossSpace.transform.GetComponent<Image>().sprite = bossIdleSprite;
    }
    #endregion

    #region ���� ��������Ʈ�� charge �� ����
    public void ChangeBossCharge()
    {
        bossSpace.transform.GetComponent<Image>().sprite = bossChargeSprite;
    }
    #endregion

    #region ���� ��������Ʈ�� attack �� ����
    public void ChangeBossAttack()
    {
        bossSpace.transform.GetComponent<Image>().sprite = bossAttackSprite;
    }
    #endregion

    #region ���� ��������Ʈ�� hurt0 �� ����
    public void ChangeBossHurt0()
    {
        bossSpace.transform.GetComponent<Image>().sprite = bossHurt0Sprite;
    }
    #endregion

    #region ���� ��������Ʈ�� hurt1 �� ����
    public void ChangeBossHurt1()
    {
        bossSpace.transform.GetComponent<Image>().sprite = bossHurt1Sprite;
    }
    #endregion

    #region ���� ��������Ʈ�� death �� ����
    public void ChangeBossDeath()
    {
        bossSpace.transform.GetComponent<Image>().sprite = bossDeathSprite;
    }
    #endregion
}
