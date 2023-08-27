using UnityEngine;

public class Enemy : MonoBehaviour
{
    // { ���� ��������Ʈ (�ִϸ��̼� �Ⱦ��� ���ؼ� 6���� ���¸� ����)
    public Sprite enemyIdle = null;
    public Sprite enemyCharge = null;
    public Sprite enemyAttack = null;
    public Sprite enemyHurt_0 = null;
    public Sprite enemyHurt_1 = null;
    public Sprite enemyDeath = null;
    // } ���� ��������Ʈ

    // { ���� �ɷ�ġ
    public int enemyID = default;
    public string enemyName = default;
    public float enemyHP = default;
    public float enemyDMG = default;
    public float enemyDEF = default;
    public float enemySpeed = default;
    public float enemyEvade = default;
    public float enemyRegen = default;
    public float enemyItemChance = default;
    //public float enemyItemTier = default;
    // } ���� �ɷ�ġ

    public Enemy CopyEnemyInfo(Enemy enemy_) 
    {
        enemyIdle = enemy_.enemyIdle;
        enemyCharge = enemy_.enemyCharge;
        enemyAttack = enemy_.enemyAttack;
        enemyHurt_0 = enemy_.enemyHurt_0;
        enemyHurt_1 = enemy_.enemyHurt_1;
        enemyDeath = enemy_.enemyDeath;

        enemyID = enemy_.enemyID;
        enemyName = enemy_.enemyName;
        enemyHP = enemy_.enemyHP * (1 + (GameManager.instance.loopCnt * 0.6f));
        enemyDMG = enemy_.enemyDMG * (1 + (GameManager.instance.loopCnt * 0.6f));
        enemyDEF = enemy_.enemyDEF * (1 + (GameManager.instance.loopCnt * 0.6f));
        enemySpeed = enemy_.enemySpeed;
        enemyEvade = enemy_.enemyEvade;
        enemyRegen = enemy_.enemyRegen;
        enemyItemChance = enemy_.enemyItemChance;

        return (Enemy)this.MemberwiseClone();
    }
}
