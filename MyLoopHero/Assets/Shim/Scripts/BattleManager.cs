using System.Collections;
using UnityEngine;


public class BattleManager : MonoBehaviour
{
    private static BattleManager converter_Instance;
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

    public Knight playerKnight { get; private set; }
    public Enemy[] monstersInBattle { get; private set; }
    public int monsterCount { get; private set; }
    public Enemy target { get; private set; }
    public float hitChance { get; private set; }
    public float playerDMG { get; private set; }
    public bool isPlayerDie { get; private set; }

    private void Awake()
    {

    }

    private void Update()
    {

    }

    #region 
    public void MakeMonsterArray(RaycastHit2D raycasthit_) 
    {
        monsterCount = raycasthit_.collider.transform.childCount - 1;
        monstersInBattle = new Enemy[monsterCount];
    }
    #endregion

    #region 플레이어 캐릭터의 정보 읽어오는 함수
    public void GetPlayerInfo()
    {
        playerKnight = GameObject.FindWithTag("Player").GetComponent<Knight>();
    }
    #endregion

    #region 타일에 있는 몬스터 이름을 비교하여, 미리 만들어진 MonsterBase(Clone) 에서 정보를 뽑아와 monstersInBattle 배열에 담는 함수
    public void UpdateMonsterInfo(RaycastHit2D raycasthit_)
    {
        for (int i = 0; i < monsterCount; i++)
        {
            MakeMonsterArray(raycasthit_);

            // ! Test : Monster(Clone) to Slime
            if (raycasthit_.collider.transform.Find("Monster(Clone)").gameObject != null)
            {
                monstersInBattle[i] = MonsterSpawner.instance.GetComponentsInChildren<Enemy>()[0].CopyEnemyInfo();
                Debug.LogFormat("이 몬스터는 : {0}", monstersInBattle[i].name);
            }
            else if (raycasthit_.collider.transform.Find("Redwolf").gameObject != null)
            {
                monstersInBattle[i] = MonsterSpawner.instance.GetComponentsInChildren<Enemy>()[1].CopyEnemyInfo();
            }
            else if (raycasthit_.collider.transform.Find("Spider").gameObject != null)
            {
                monstersInBattle[i] = MonsterSpawner.instance.GetComponentsInChildren<Enemy>()[2].CopyEnemyInfo();
            }
            else if (raycasthit_.collider.transform.Find("Skeleton").gameObject != null)
            {
                monstersInBattle[i] = MonsterSpawner.instance.GetComponentsInChildren<Enemy>()[3].CopyEnemyInfo();
            }
            else if (raycasthit_.collider.transform.Find("Chest").gameObject != null)
            {
                monstersInBattle[i] = MonsterSpawner.instance.GetComponentsInChildren<Enemy>()[4].CopyEnemyInfo();
            }
            else if (raycasthit_.collider.transform.Find("Ghost").gameObject != null)
            {
                monstersInBattle[i] = MonsterSpawner.instance.GetComponentsInChildren<Enemy>()[5].CopyEnemyInfo();
            }
            else if (raycasthit_.collider.transform.Find("Vampire").gameObject != null)
            {
                monstersInBattle[i] = MonsterSpawner.instance.GetComponentsInChildren<Enemy>()[6].CopyEnemyInfo();
            }
            else if (raycasthit_.collider.transform.Find("Ghoul").gameObject != null)
            {
                monstersInBattle[i] = MonsterSpawner.instance.GetComponentsInChildren<Enemy>()[7].CopyEnemyInfo();
            }
            else if (raycasthit_.collider.transform.Find("Harpy").gameObject != null)
            {
                monstersInBattle[i] = MonsterSpawner.instance.GetComponentsInChildren<Enemy>()[8].CopyEnemyInfo();
            }
            else if (raycasthit_.collider.transform.Find("Gargoyle").gameObject != null)
            {
                monstersInBattle[i] = MonsterSpawner.instance.GetComponentsInChildren<Enemy>()[9].CopyEnemyInfo();
            }
            else if (raycasthit_.collider.transform.Find("Fleshgolem").gameObject != null)
            {
                monstersInBattle[i] = MonsterSpawner.instance.GetComponentsInChildren<Enemy>()[10].CopyEnemyInfo();
            }
            else if (raycasthit_.collider.transform.Find("Mosquito").gameObject != null)
            {
                monstersInBattle[i] = MonsterSpawner.instance.GetComponentsInChildren<Enemy>()[11].CopyEnemyInfo();
            }
            else if (raycasthit_.collider.transform.Find("Scarecrow").gameObject != null)
            {
                monstersInBattle[i] = MonsterSpawner.instance.GetComponentsInChildren<Enemy>()[12].CopyEnemyInfo();
            }
            else
            {
                Debug.Log("else 로 빠졌음");
            }
        }
    }
    #endregion

    #region 몬스터 공격 속드 WaitForSecondsRealtime 에 캐싱
    public WaitForSecondsRealtime slimeAttackSpeed = new WaitForSecondsRealtime(0.6f);
    public WaitForSecondsRealtime ratwolfAttackSpeed = new WaitForSecondsRealtime(0.75f);
    public WaitForSecondsRealtime spiderAttackSpeed = new WaitForSecondsRealtime(0.91f);
    public WaitForSecondsRealtime skelGargoFlesh = new WaitForSecondsRealtime(0.3f);
    public WaitForSecondsRealtime chestAttackSpeed = new WaitForSecondsRealtime(0.7f);
    public WaitForSecondsRealtime ghostAttackSpeed = new WaitForSecondsRealtime(0.85f);
    public WaitForSecondsRealtime vampireAttackSpeed = new WaitForSecondsRealtime(0.5f);
    public WaitForSecondsRealtime ghoulAttackSpeed = new WaitForSecondsRealtime(0.32f);
    public WaitForSecondsRealtime harpyAttackSpeed = new WaitForSecondsRealtime(0.8f);
    public WaitForSecondsRealtime mosquitoAttackSpeed = new WaitForSecondsRealtime(1.1f);
    public WaitForSecondsRealtime scarecrowAttackSpeed = new WaitForSecondsRealtime(0.45f);
    #endregion

    public void OpenWindow()
    {
        // StartCoroutine(CycleBattle());
    }

    #region 몬스터의 숫자에 따라서 전투싸이클 수를 조절하는 Coroutine
    IEnumerator CycleBattle()
    {
        if (monstersInBattle.Length == 5)
        {
            StartCoroutine(CyclePlayer(playerKnight, playerKnight.heroAttackSpeed));
            StartCoroutine(CycleMonster(playerKnight, monstersInBattle[0]));
            StartCoroutine(CycleMonster(playerKnight, monstersInBattle[1]));
            StartCoroutine(CycleMonster(playerKnight, monstersInBattle[2]));
            StartCoroutine(CycleMonster(playerKnight, monstersInBattle[3]));
            StartCoroutine(CycleMonster(playerKnight, monstersInBattle[4]));
        }
        else if (monstersInBattle.Length == 4)
        {
            StartCoroutine(CyclePlayer(playerKnight, playerKnight.heroAttackSpeed));
            StartCoroutine(CycleMonster(playerKnight, monstersInBattle[0]));
            StartCoroutine(CycleMonster(playerKnight, monstersInBattle[1]));
            StartCoroutine(CycleMonster(playerKnight, monstersInBattle[2]));
            StartCoroutine(CycleMonster(playerKnight, monstersInBattle[3]));
        }
        else if (monstersInBattle.Length == 3)
        {
            StartCoroutine(CyclePlayer(playerKnight, playerKnight.heroAttackSpeed));
            StartCoroutine(CycleMonster(playerKnight, monstersInBattle[0]));
            StartCoroutine(CycleMonster(playerKnight, monstersInBattle[1]));
            StartCoroutine(CycleMonster(playerKnight, monstersInBattle[2]));
        }
        else if (monstersInBattle.Length == 2)
        {
            StartCoroutine(CyclePlayer(playerKnight, playerKnight.heroAttackSpeed));
            StartCoroutine(CycleMonster(playerKnight, monstersInBattle[0]));
            StartCoroutine(CycleMonster(playerKnight, monstersInBattle[1]));
        }
        else if (monstersInBattle.Length == 1)
        {
            StartCoroutine(CyclePlayer(playerKnight, playerKnight.heroAttackSpeed));
            StartCoroutine(CycleMonster(playerKnight, monstersInBattle[0]));
        }
        else 
        {
            Debug.Log("잘못된 코루틴 실행, 브레이크");
            yield break;
        }
    }
    #endregion

    #region 플레이어의 정보와 공격속도를 받아서 공격싸이클을 실행하는 Coroutine
    IEnumerator CyclePlayer(Knight playerKnight_, float heroAttackSpeed_)
    {
        while (true)
        {
            if (playerKnight_.heroHealth > 0 && target.enemyHP > 0 )
            {
                yield return new WaitForSecondsRealtime(1 / heroAttackSpeed_);
                CheckTargetEvade(playerKnight_, target);
            }
            else
            {
                Debug.LogFormat("플레이어의 체력이 {0}이 되어 전투가 종료", playerKnight_.heroHealth);
                Time.timeScale = 1;
                yield break;
            }
        }
    }
    #endregion

    #region 몬스터의 정보와 인덱스를 받아서 공격싸이클을 실행하는 Coroutine
    IEnumerator CycleMonster(Knight playerKnight_, Enemy enemy_)
    {
        while (true)
        {
            if (enemy_.enemyHP > 0 && playerKnight.heroHealth > 0)
            {
                if (enemy_.enemyID == 100)
                {
                    yield return slimeAttackSpeed;
                    CheckPlayerEvade(playerKnight_, enemy_);
                }
                else if (enemy_.enemyID == 101)
                {
                    yield return ratwolfAttackSpeed;
                    CheckPlayerEvade(playerKnight_, enemy_);
                }
                else if (enemy_.enemyID == 102)
                {
                    yield return spiderAttackSpeed;
                    CheckPlayerEvade(playerKnight_, enemy_);
                }
                else if (enemy_.enemyID == 103 || enemy_.enemyID == 109 || enemy_.enemyID == 110)
                {
                    yield return skelGargoFlesh;
                    CheckPlayerEvade(playerKnight_, enemy_);
                }
                else if (enemy_.enemyID == 104)
                {
                    yield return chestAttackSpeed;
                    CheckPlayerEvade(playerKnight_, enemy_);
                }
                else if (enemy_.enemyID == 105)
                {
                    yield return ghostAttackSpeed;
                    CheckPlayerEvade(playerKnight_, enemy_);
                }
                else if (enemy_.enemyID == 106)
                {
                    yield return vampireAttackSpeed;
                    CheckPlayerEvade(playerKnight_, enemy_);
                }
                else if (enemy_.enemyID == 107)
                {
                    yield return ghoulAttackSpeed;
                    CheckPlayerEvade(playerKnight_, enemy_);
                }
                else if (enemy_.enemyID == 108)
                {
                    yield return harpyAttackSpeed;
                    CheckPlayerEvade(playerKnight_, enemy_);
                }
                else if (enemy_.enemyID == 111)
                {
                    yield return mosquitoAttackSpeed;
                    CheckPlayerEvade(playerKnight_, enemy_);
                }
                else if (enemy_.enemyID == 112)
                {
                    yield return scarecrowAttackSpeed;
                    CheckPlayerEvade(playerKnight_, enemy_);
                }
            }
            else
            {
                Debug.LogFormat("적의 체력이 {0}이 되어 전투가 종료", enemy_.enemyHP);
                Time.timeScale = 1;
                yield break;
            }
        }
    }
    #endregion

    #region 플레이어가 공격할 타겟을 지정하는 함수
    public void FindHitTarget()
    {
        int targetIdx_ = Random.Range(0, monsterCount);
        //Debug.LogFormat("타겟은 {0}, Hp: {1}", targetIdx_, monstersInBattle[targetIdx_].enemyHP);

        for (int i = 0; i < monsterCount; i++) 
        {
            if (monstersInBattle[targetIdx_].enemyHP <= 0) 
            {
                Debug.LogFormat("찾을 타겟이 없으므로 다시 굴림");
                i--;
                continue;
            }
            else if (monstersInBattle[targetIdx_].enemyHP > 0)
            {
                target = monstersInBattle[targetIdx_];
                Debug.LogFormat("타겟 발견 타겟 : {0}", target);
                break;
            }
        }
    }
    #endregion

    #region 공격할 타겟의 회피를 판정하는 함수 (성공 : 회피, 실패 : 데미지)
    public void CheckTargetEvade(Knight playerKnight_, Enemy targetEnemy_)
    {
        hitChance = Random.Range(0, 100);

        if (playerKnight_.heroHealth > 0 && targetEnemy_.enemyHP > 0)
        {
            Debug.LogFormat("플레이어 체력 : {0}, 몬스터 체력 : {1}", playerKnight_.heroHealth, targetEnemy_.enemyHP);
            if (hitChance <= targetEnemy_.enemyEvade)
            {
                /*Do Nothing*/
                Debug.LogFormat("플레이어의 공격은 빗나갔다\n확률 : {0}, 적의 회피 : {1}", hitChance, targetEnemy_.enemyEvade);
            }
            else
            {
                //FindHitTarget();
                AttackToAll(playerKnight_, targetEnemy_);
                AttackToTarget(playerKnight_, targetEnemy_);
            }
        }
        else
        {
            /*Do Nothing*/
            Debug.LogFormat("플레이어 체력 : {0}, 몬스터 체력 : {1}", playerKnight_.heroHealth, targetEnemy_.enemyHP);
        }
    }
    #endregion

    #region 플레이어의 회피를 판정하는 함수 (성공 : 회피, 실패 : 데미지)
    public void CheckPlayerEvade(Knight playerKnight_, Enemy enemy_)
    {
        hitChance = Random.Range(0, 100);

        if (playerKnight_.heroHealth > 0 && enemy_.enemyHP > 0)
        {
            Debug.LogFormat("플레이어 체력 : {0}, 몬스터 체력 : {1}", playerKnight_.heroHealth, enemy_.enemyHP);
            if (hitChance <= playerKnight_.heroEvade)
            {
                /*Do Nothing*/
                Debug.LogFormat("몬스터의 공격은 빗나갔다\n확률 : {0}, 플레이어의 회피 : {1}", hitChance, playerKnight_.heroEvade);
            }
            else
            {
                AttackToPlayer(playerKnight_, enemy_);
                CheckCounter(playerKnight_, enemy_);
            }
        }
        else
        {
            /*Do Nothing*/
            Debug.LogFormat("플레이어 체력 : {0}, 몬스터 체력 : {1}", playerKnight_.heroHealth, enemy_.enemyHP);
        }
    }
    #endregion

    #region 플레이어의 카운터 여부를 판정하는 함수
    public void CheckCounter(Knight playerKnight_, Enemy enemy_)
    {
        hitChance = Random.Range(0, 100);

        if (playerKnight_.heroHealth > 0 && enemy_.enemyHP > 0)
        {
            Debug.LogFormat("플레이어 체력 : {0}, 몬스터 체력 : {1}", playerKnight_.heroHealth, enemy_.enemyHP);
            if (hitChance > playerKnight_.heroCounter)
            {
                /*Do Nothing*/
                Debug.LogFormat("카운터 발동실패\n확률 : {0}, 카운터확률 : {1}", hitChance, playerKnight_.heroCounter);
            }
            else
            {
                Debug.LogFormat("카운터 발동\n확률 : {0}, 카운터확률 : {1}", hitChance, playerKnight_.heroCounter);
                AttackToTarget(playerKnight_, enemy_);
            }
        }
        else 
        {
            /*Do Nothing*/
            Debug.LogFormat("플레이어 체력 : {0}, 몬스터 체력 : {1}", playerKnight_.heroHealth, enemy_.enemyHP);
        }
    }
    #endregion

    #region 플레이어가 타겟을 공격하고 타겟의 체력의 변화시키는 함수
    public void AttackToTarget(Knight playerKnight_, Enemy targetEnemy_)
    {
        playerDMG = Random.Range(playerKnight_.heroDamageMin, playerKnight_.heroDamageMax);

        if (playerKnight_.heroHealth > 0 && targetEnemy_.enemyHP > 0) 
        {
            Debug.LogFormat("플레이어 체력 : {0}, 몬스터 체력 : {1}", playerKnight_.heroHealth, targetEnemy_.enemyHP);
            if (targetEnemy_.enemyDEF >= playerDMG)
            {
                Debug.LogFormat("플레이어의 공격이 가로막혔다\n몬스터 방어력: {0}, 플레이어 공격력 : {1}", targetEnemy_.enemyDEF, playerDMG);
                targetEnemy_.enemyHP -= playerKnight_.heroDamageMagic;
                Debug.LogFormat("플레이어의 마법데미지 : {0}, 남은 적의 체력 : {1}", playerKnight_.heroDamageMagic, targetEnemy_.enemyHP);
                playerKnight_.heroHealth += (playerKnight_.heroVamp * playerKnight_.heroDamageMagic);
                Debug.LogFormat("플레이어의 흡혈 : {0}, 플레이어의 체력 : {1}", playerKnight_.heroVamp * playerKnight_.heroDamageMagic, playerKnight_.heroHealth);
            }
            else
            {
                Debug.LogFormat("플레이어의 공격\n몬스터 방어력 : {0}, 플레이어 공격력 : {1}", targetEnemy_.enemyDEF, playerDMG);
                targetEnemy_.enemyHP -= (playerKnight_.heroDamageMagic + (playerDMG - targetEnemy_.enemyDEF));
                Debug.LogFormat("플레이어의 가한데미지 : {0}, 남은 적의 체력 : {1}", playerKnight_.heroDamageMagic + (playerDMG - targetEnemy_.enemyDEF), targetEnemy_.enemyHP);
                
                if (playerKnight_.heroHealthMax <= playerKnight_.heroHealth + (playerKnight_.heroVamp * (playerKnight_.heroDamageMagic + (playerDMG - targetEnemy_.enemyDEF)))) 
                {
                    playerKnight_.heroHealth = playerKnight_.heroHealthMax;
                    Debug.LogFormat("현재 플레이어의 체력은 최대치이다. {0}", playerKnight_.heroHealth);
                }
                else
                {
                    playerKnight_.heroHealth += (playerKnight_.heroVamp * (playerKnight_.heroDamageMagic + (playerDMG - targetEnemy_.enemyDEF)));
                    Debug.LogFormat("플레이어의 흡혈 : {0}, 플레이어의 체력 : {1}", playerKnight_.heroVamp * (playerKnight_.heroDamageMagic + (playerDMG - targetEnemy_.enemyDEF)), playerKnight_.heroHealth);
                }
            }
        }
        else 
        {
            /*Do Nothing*/
            Debug.LogFormat("플레이어 체력 : {0}, 몬스터 체력 : {1}", playerKnight_.heroHealth, targetEnemy_.enemyHP);
        }
    }
    #endregion

    #region 플레이어가 전체 공격을 가하는 함수
    public void AttackToAll(Knight playerKnight_, Enemy enemy_)
    {
        if (playerKnight_.heroHealth > 0 && enemy_.enemyHP > 0)
        {
            Debug.LogFormat("플레이어 체력 : {0}, 몬스터 체력 : {1}", playerKnight_.heroHealth, enemy_.enemyHP);
            for (int i = 0; i < monsterCount; i++)
            {
                monstersInBattle[i].enemyHP -= playerKnight_.heroDamageAll;
                Debug.LogFormat("플레이어의 전체공격 데미지 : {0}", playerKnight_.heroDamageAll);
            }
        }
        else 
        {
            /*Do Nothing*/
            Debug.LogFormat("플레이어 체력 : {0}, 몬스터 체력 : {1}", playerKnight_.heroHealth, enemy_.enemyHP);
        }
    }
    #endregion

    #region monstersInBattle 의 인덱스를 받아서 플레이어를 공격하고 체력을 변화시키는 함수 
    // ! 타겟 뿐만이 아니라 다른 전체 몬스터의 공격 함수가 필요
    public void AttackToPlayer(Knight playerKnight_, Enemy enemy_)
    {
        if (playerKnight_.heroHealth > 0 && enemy_.enemyHP > 0) 
        {
            Debug.LogFormat("플레이어 체력 : {0}, 몬스터 체력 : {1}", playerKnight_.heroHealth, enemy_.enemyHP);
            if (playerKnight_.heroDefense >= enemy_.enemyDMG)
            {
                /*Do Nothing*/
                Debug.LogFormat("몬스터의 공격이 가로막혔다\n플레이어 방어력 : {0}, 몬스터 공격력 : {1}", playerKnight_.heroDefense, enemy_.enemyDMG);
            }
            else
            {
                playerKnight_.heroHealth -= enemy_.enemyDMG - playerKnight_.heroDefense;
                Debug.LogFormat("몬스터의 공격\n플레이어 방어력 : {0}, 몬스터 공격력 : {1}", playerKnight_.heroDefense, enemy_.enemyDMG);
            }
        }
        else 
        {
            /*Do Nothing*/
            Debug.LogFormat("플레이어 체력 : {0}, 몬스터 체력 : {1}", playerKnight_.heroHealth, enemy_.enemyHP);
        }
    }
    #endregion
}
