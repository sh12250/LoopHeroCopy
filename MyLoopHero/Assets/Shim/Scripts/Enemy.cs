using UnityEngine;

public class Enemy : MonoBehaviour
{
    // { 몬스터 스프라이트 (애니메이션 안쓰기 위해서 6가지 상태만 선택)
    public Sprite enemyIdle = null;
    public Sprite enemyCharge = null;
    public Sprite enemyAttack = null;
    public Sprite enemyHurt_0 = null;
    public Sprite enemyHurt_1 = null;
    public Sprite enemyDeath = null;
    // } 몬스터 스프라이트

    // { 몬스터 능력치
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
    // } 몬스터 능력치

    public Enemy CopyEnemyInfo() 
    {
        #region Legacy
        //enemyIdle = enemyInfoBase_.enemyIdle;
        //enemyCharge = enemyInfoBase_.enemyCharge;
        //enemyAttack = enemyInfoBase_.enemyAttack;
        //enemyHurt_0 = enemyInfoBase_.enemyHurt_0;
        //enemyHurt_1 = enemyInfoBase_.enemyHurt_1;
        //enemyDeath = enemyInfoBase_.enemyDeath;

        //enemyID = enemyInfoBase_.enemyID;
        //enemyName = enemyInfoBase_.enemyName;
        //enemyHP = enemyInfoBase_.enemyHP;
        //enemyDMG = enemyInfoBase_.enemyDMG;
        //enemyDEF = enemyInfoBase_.enemyDEF;
        //enemySpeed = enemyInfoBase_.enemySpeed;
        //enemyEvade = enemyInfoBase_.enemyEvade;
        //enemyRegen = enemyInfoBase_.enemyRegen;
        //enemyItemChance = enemyInfoBase_.enemyItemChance;
        //enemyItemTier = enemyInfoBase_.enemyItemTier;
        #endregion
        return (Enemy)this.MemberwiseClone();
    }
}
