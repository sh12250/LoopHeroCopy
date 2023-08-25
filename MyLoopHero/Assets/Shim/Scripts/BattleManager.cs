using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class BattleManager : MonoBehaviour
{
    private static BattleManager battleManager_Instance;
    public static BattleManager instance
    {
        get
        {
            if (battleManager_Instance == null)
            {
                battleManager_Instance = FindObjectOfType<BattleManager>();
            }
            return battleManager_Instance;
        }
    }

    #region 배틀 매니저 필드
    // BattleWindow
    private GameObject battleWindow;

    // DeadWindow
    private GameObject deadWindow;

    // rayCastHit_.collider 에서 받아올 플레이어의 정보
    public Knight playerKnight;

    // 플레이어의 공격속도를 캐싱할 변수
    public WaitForSecondsRealtime playerSpeed;

    // rayCastHit_.collider 에서 받아올 몬스터의 정보 리스트
    public List<Enemy> monstersInBattle;

    // rayCastHit_.collider 의 child 수를 담을 변수
    public int monsterCount;

    // 몬스터들의 공격속도를 WaitForSecondsRealtime 에 캐싱할 배열
    public WaitForSecondsRealtime[] monsterSpeedArray;

    // 플레이어의 죽음 여부를 저장할 변수;
    public bool isPlayerDie;



    // 공격 성공 확률을 저장할 변수
    public float hitChance;

    // 플레이어의 데미지 범위에서 결정된 데미지를 저장할 변수
    public float playerDMG;

    // monstersInBattle 에서 플레이어가 공격할 대상
    public Enemy target;
    #endregion


    #region 몬스터 공격 속드 WaitForSecondsRealtime 에 캐싱
    public WaitForSecondsRealtime slimeBossSpeed = new WaitForSecondsRealtime(0.6f);
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


    private void Awake()
    {
        isPlayerDie = false;
        MakeMonsterList();
        GetPlayerInfo();
        CheckBattleWindow();
        CheckDeadWindow();
    }

    private void FixedUpdate()
    {
        CheckPlayerDeath(playerKnight);
    }

    //플레이어 정보 관련 함수////////////////////////////////////////////////////////////////////////////////////

    #region 플레이어 캐릭터의 정보를 읽어오는 함수
    public void GetPlayerInfo()
    {
        playerKnight = GameObject.FindWithTag("Player").GetComponent<Knight>();
    }
    #endregion

    #region 플레이어의 죽음 여부를 판정하는 함수
    public void CheckPlayerDeath(Knight playerKnight_)
    {
        if (playerKnight_.heroHealth > 0)
        {
            isPlayerDie = false;
        }
        else
        {
            isPlayerDie = true;
            OpenDeadWindow();
        }
    }
    #endregion

    //몬스터 정보 관련 함수/////////////////////////////////////////////////////////////////////////////////////

    #region 타일에서 마주친 몬스터들의 정보를 담을 리스트를 만드는 함수
    public void MakeMonsterList()
    {
        monstersInBattle = new List<Enemy>();
    }
    #endregion

    #region 몬스터 리스트 리셋하는 함수
    private void ResetMonsterArray()
    {
        //battleWindow.GetComponent<BattleWindow>().ChangeEnemyNull();
        monstersInBattle.Clear();
    }
    #endregion

    #region 몬스터 공격 속도 WaitForSecondsRealtime 에 캐싱하는 함수
    //private void CachingMonsterSpeed() 
    //{
    //    monsterSpeedArray = new WaitForSecondsRealtime[]{ };

    //    for (int i = 0; i < MonsterSpawner.instance.enemies.Length; i++) 
    //    {
    //        monsterSpeedArray[i] = new WaitForSecondsRealtime(MonsterSpawner.instance.enemies[i].enemySpeed * 2);
    //         ex. Slime 은 monsterSpeedArray[0] 으로 WaitForSecondRealtime(0.6 * 2) 의 값을 가지게 된다.
    //    }
    //}
    #endregion

    #region 타일에 있는 몬스터 이름을 비교하여, 미리 만들어진 MonsterBase(Clone) 에서 정보를 뽑아와 monstersInBattle 리스트에 담는 함수
    public void UpdateMonsterInfo(RaycastHit2D raycasthit_)
    {
        // 마주친 몬스터의 숫자는 raycasthit_ 타일 하위의 (자식 오브젝트 갯수 - 1) 이다.
        monsterCount = raycasthit_.collider.transform.childCount - 1;

        // 리스트에 몬스터 정보를 넣기 전, 리스트를 초기화 한다.
        ResetMonsterArray();

        // for 문을 통해 몬스터의 정보를 순서대로 monstersInBattle 리스트에 넣는다. (타일의 첫번째 자식은 타일 이미지이므로 1번부터 돌린다.)
        for (int i = 1; i < monsterCount + 1; i++)
        {
            #region 이름에 맞추어 알맞은 몬스터 정보값을 복사해 리스트에 넣는다.
            //Debug.LogFormat("리스트 길이 {0}, i 값: {1}, 어떤걸 들고 오지?: {2}", monstersInBattle.Count, i, raycasthit_.collider.transform.GetChild(i).name);
            if (raycasthit_.collider.transform.GetChild(i).name == "Slime")
            {
                monstersInBattle.Add(MonsterSpawner.instance.GetComponentsInChildren<Enemy>()[0].CopyEnemyInfo());
                Debug.LogFormat("리스트 길이 {0}, i 값: {1}", monstersInBattle.Count, i);
                //Debug.LogFormat("이 몬스터는 : {0}", monstersInBattle[i].enemyName);
            }
            else if (raycasthit_.collider.transform.GetChild(i).name == "Redwolf")
            {
                monstersInBattle.Add(MonsterSpawner.instance.GetComponentsInChildren<Enemy>()[1].CopyEnemyInfo());
                //Debug.LogFormat("이 몬스터는 : {0}", monstersInBattle[i].enemyName);
            }
            else if (raycasthit_.collider.transform.GetChild(i).name == "Spider")
            {
                monstersInBattle.Add(MonsterSpawner.instance.GetComponentsInChildren<Enemy>()[2].CopyEnemyInfo());
                //Debug.LogFormat("이 몬스터는 : {0}", monstersInBattle[i].enemyName);
            }
            else if (raycasthit_.collider.transform.GetChild(i).name == "Skeleton")
            {
                monstersInBattle.Add(MonsterSpawner.instance.GetComponentsInChildren<Enemy>()[3].CopyEnemyInfo());
                //Debug.LogFormat("이 몬스터는 : {0}", monstersInBattle[i].enemyName);
            }
            else if (raycasthit_.collider.transform.GetChild(i).name == "Chest")
            {
                monstersInBattle.Add(MonsterSpawner.instance.GetComponentsInChildren<Enemy>()[4].CopyEnemyInfo());
                //Debug.LogFormat("이 몬스터는 : {0}", monstersInBattle[i].enemyName);
            }
            else if (raycasthit_.collider.transform.GetChild(i).name == "Ghost")
            {
                monstersInBattle.Add(MonsterSpawner.instance.GetComponentsInChildren<Enemy>()[5].CopyEnemyInfo());
                //Debug.LogFormat("이 몬스터는 : {0}", monstersInBattle[i].enemyName);
            }
            else if (raycasthit_.collider.transform.GetChild(i).name == "Vampire")
            {
                monstersInBattle.Add(MonsterSpawner.instance.GetComponentsInChildren<Enemy>()[6].CopyEnemyInfo());
                //Debug.LogFormat("이 몬스터는 : {0}", monstersInBattle[i].enemyName);
            }
            else if (raycasthit_.collider.transform.GetChild(i).name == "Ghoul")
            {
                monstersInBattle.Add(MonsterSpawner.instance.GetComponentsInChildren<Enemy>()[7].CopyEnemyInfo());
                //Debug.LogFormat("이 몬스터는 : {0}", monstersInBattle[i].enemyName);
            }
            else if (raycasthit_.collider.transform.GetChild(i).name == "Harpy")
            {
                monstersInBattle.Add(MonsterSpawner.instance.GetComponentsInChildren<Enemy>()[8].CopyEnemyInfo());
                //Debug.LogFormat("이 몬스터는 : {0}", monstersInBattle[i].enemyName);
            }
            else if (raycasthit_.collider.transform.GetChild(i).name == "Gargoyle")
            {
                monstersInBattle.Add(MonsterSpawner.instance.GetComponentsInChildren<Enemy>()[9].CopyEnemyInfo());
                //Debug.LogFormat("이 몬스터는 : {0}", monstersInBattle[i].enemyName);
            }
            else if (raycasthit_.collider.transform.GetChild(i).name == "Fleshgolem")
            {
                monstersInBattle.Add(MonsterSpawner.instance.GetComponentsInChildren<Enemy>()[10].CopyEnemyInfo());
                //Debug.LogFormat("이 몬스터는 : {0}", monstersInBattle[i].enemyName);
            }
            else if (raycasthit_.collider.transform.GetChild(i).name == "Mosquito")
            {
                monstersInBattle.Add(MonsterSpawner.instance.GetComponentsInChildren<Enemy>()[11].CopyEnemyInfo());
                //Debug.LogFormat("이 몬스터는 : {0}", monstersInBattle[i].enemyName);
            }
            else if (raycasthit_.collider.transform.GetChild(i).name == "Scarecrow")
            {
                monstersInBattle.Add(MonsterSpawner.instance.GetComponentsInChildren<Enemy>()[12].CopyEnemyInfo());
                //Debug.LogFormat("이 몬스터는 : {0}", monstersInBattle[i].enemyName);
            }
            else if (raycasthit_.collider.transform.GetChild(i).name == "Scarecrow")
            {
                monstersInBattle.Add(MonsterSpawner.instance.GetComponentsInChildren<Enemy>()[12].CopyEnemyInfo());
                //Debug.LogFormat("이 몬스터는 : {0}", monstersInBattle[i].enemyName);
            }
            // ! 보스 생성시 이름 잘 보고 주석 풀 것

            else if (raycasthit_.collider.transform.GetChild(i).name == "Boss")
            {
                monstersInBattle.Add(MonsterSpawner.instance.GetComponentsInChildren<Enemy>()[13].CopyEnemyInfo());
                //Debug.LogFormat("이 몬스터는 : {0}", monstersInBattle[i].enemyName);
            }
            else
            {
                /*Do Nothing*/
                Debug.LogFormat("리스트에 몬스터가 없습니다. 리스트 길이 : {0}\n타일 하위에 몬스터가 없습니다 : {1}",
                    monstersInBattle.Count, monsterCount);
            }
            #endregion
        }

        target = monstersInBattle[0];
    }
    #endregion

    //게임오버 관련 함수///////////////////////////////////////////////////////////////////////////////////////

    #region DeadWindow 를 찾고 SetActive(false) 하는 함수
    public void CheckDeadWindow()
    {
        deadWindow = GameObject.Find("DeadWindow").gameObject;
        deadWindow.transform.localScale = Vector3.zero;
    }
    #endregion

    #region 게임 오버 함수
    public void OpenDeadWindow()
    {
        StopAllCoroutines();
        deadWindow.transform.localScale = Vector3.one;
    }
    #endregion

    //전투 시작 종료 함수//////////////////////////////////////////////////////////////////////////////////////

    #region BattleWindow 를 찾고 사이즈를 줄이는 함수
    public void CheckBattleWindow() 
    {
        battleWindow = GameObject.Find("BattleWindow").gameObject;
        //battleWindow.GetComponent<BattleWindow>().ChangeEnemyNull();
        battleWindow.transform.localScale = Vector3.zero;
    }
    #endregion

    #region BattlewWindow 를 띄우는 함수
    public void OpenBattleWindow() 
    {
        battleWindow.transform.localScale = Vector3.one;
    }
    #endregion

    #region BattlewWindow 를 닫는 함수
    public void CloseBattleWindow()
    {
        battleWindow.transform.localScale = Vector3.zero;
    }
    #endregion

    #region 전투 시작 함수
    public void StartBattle()
    {
        battleWindow.GetComponent<BattleWindow>().ChangePlayerIdle();
        for (int i = 0; i < monsterCount; i++) 
        {
            battleWindow.GetComponent<BattleWindow>().ChangeEnemyIdle(monstersInBattle[i]);
        }

        OpenBattleWindow();
        StartCoroutine(BattleCycle());
    }
    #endregion

    #region 전투 종료 함수
    public void EndBattle()
    {
        StopAllCoroutines();
        CloseBattleWindow();
        ResetMonsterArray();
        Time.timeScale = 1;
    }
    #endregion

    //코루틴////////////////////////////////////////////////////////////////////////////////////

    #region 몬스터의 숫자에 따라서 전투싸이클 수를 조절하는 Coroutine
    IEnumerator BattleCycle()
    {
        if (monsterCount == 1)
        {
            StartCoroutine(PlayerCycle(playerKnight, target, monstersInBattle));
            StartCoroutine(EnemyCycle(playerKnight, monstersInBattle[0], monstersInBattle));
        }
        else if (monsterCount == 2)
        {
            StartCoroutine(PlayerCycle(playerKnight, target, monstersInBattle));
            StartCoroutine(EnemyCycle(playerKnight, monstersInBattle[0], monstersInBattle));
            StartCoroutine(EnemyCycle(playerKnight, monstersInBattle[1], monstersInBattle));
        }
        else if (monsterCount == 3)
        {
            StartCoroutine(PlayerCycle(playerKnight, target, monstersInBattle));
            StartCoroutine(EnemyCycle(playerKnight, monstersInBattle[0], monstersInBattle));
            StartCoroutine(EnemyCycle(playerKnight, monstersInBattle[1], monstersInBattle));
            StartCoroutine(EnemyCycle(playerKnight, monstersInBattle[2], monstersInBattle));
        }
        else if (monsterCount == 4)
        {
            StartCoroutine(PlayerCycle(playerKnight, target, monstersInBattle));
            StartCoroutine(EnemyCycle(playerKnight, monstersInBattle[0], monstersInBattle));
            StartCoroutine(EnemyCycle(playerKnight, monstersInBattle[1], monstersInBattle));
            StartCoroutine(EnemyCycle(playerKnight, monstersInBattle[2], monstersInBattle));
            StartCoroutine(EnemyCycle(playerKnight, monstersInBattle[3], monstersInBattle));
        }
        else if (monsterCount == 5)
        {
            StartCoroutine(PlayerCycle(playerKnight, target, monstersInBattle));
            StartCoroutine(EnemyCycle(playerKnight, monstersInBattle[0], monstersInBattle));
            StartCoroutine(EnemyCycle(playerKnight, monstersInBattle[1], monstersInBattle));
            StartCoroutine(EnemyCycle(playerKnight, monstersInBattle[2], monstersInBattle));
            StartCoroutine(EnemyCycle(playerKnight, monstersInBattle[3], monstersInBattle));
            StartCoroutine(EnemyCycle(playerKnight, monstersInBattle[4], monstersInBattle));
        }
        else
        {
            Debug.Log("monstersInBattle.Count 가 0 이하");
            yield break;
        }
    }
    #endregion

    #region 플레이어의 전투 코루틴
    public IEnumerator PlayerCycle(Knight playerKnight_, Enemy enemy_, List<Enemy> enemies_)
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1 - (playerKnight.heroAttackSpeed * 0.01f));
            battleWindow.GetComponent<BattleWindow>().ChangePlayerIdle();

            if (playerKnight_.heroHealth <= 0)
            {
                OpenDeadWindow();
                battleWindow.GetComponent<BattleWindow>().ChangePlayerDeath();
                AudioManager.instance.PlaySound_HeroDeath();
                yield break;
            }
            else if (playerKnight_.heroHealth > 0)
            {
                if (enemy_.enemyHP <= 0)
                {
                    enemies_.Remove(enemy_);

                    if (enemies_.Count > 0)
                    {
                        target = enemies_[0];

                        AttackAll(playerKnight_, enemies_);
                        AttackTarget(playerKnight_, enemy_);
                    }
                    else
                    {
                        battleWindow.GetComponent<BattleWindow>().ChangePlayerIdle();
                        Debug.Log("루프 탈출");
                        EndBattle();
                        yield break;
                    }
                }
                else if (enemy_.enemyHP > 0)
                {
                    AttackAll(playerKnight_, enemies_);
                    AttackTarget(playerKnight_, enemy_);
                }
            }
        }
    }
    #endregion

    #region 몬스터의 전투 코루틴
    public IEnumerator EnemyCycle(Knight playerKnight_, Enemy enemy_, List<Enemy> enemies_)
    {
        // enemies_가 빈 상태로 함수를 실행하는 경우 종료
        if (enemies_ == default || enemies_.Count < 1) { yield break; }

        while (true)
        {
            switch (enemy_.enemyID)
            {
                case 100:
                    yield return slimeBossSpeed;
                    break;
                case 101:
                    yield return ratwolfAttackSpeed;
                    break;
                case 102:
                    yield return spiderAttackSpeed;
                    break;
                case 103:
                    yield return skelGargoFlesh;
                    break;
                case 104:
                    yield return chestAttackSpeed;
                    break;
                case 105:
                    yield return ghostAttackSpeed;
                    break;
                case 106:
                    yield return vampireAttackSpeed;
                    break;
                case 107:
                    yield return ghoulAttackSpeed;
                    break;
                case 108:
                    yield return harpyAttackSpeed;
                    break;
                case 109:
                    yield return skelGargoFlesh;
                    break;
                case 110:
                    yield return skelGargoFlesh;
                    break;
                case 111:
                    yield return mosquitoAttackSpeed;
                    break;
                case 112:
                    yield return scarecrowAttackSpeed;
                    break;
                case 113:
                    yield return slimeBossSpeed;
                    break;
            }

            battleWindow.GetComponent<BattleWindow>().ChangeEnemyIdle(enemy_);

            if (enemy_.enemyHP <= 0)
            {
                //Debug.LogFormat("리스트에서 자기자신 : {0}을 제거함, 제거 전 리스트 길이 : {1}", enemy_, enemies_.Count);
                //enemies_.Remove(enemy_);
                //Debug.Log("루프 탈출");
                battleWindow.GetComponent<BattleWindow>().ChangeEnemyDeath(enemy_);
                if (enemy_.enemyID == 113)
                {
                    AudioManager.instance.PlaySound_LichDeath();
                }
                else
                {
                    /*Do Nothing*/
                }

                StopCoroutine(EnemyCycle(playerKnight_, enemy_, enemies_));
                yield break;
            }
            else if (enemy_.enemyHP > 0)
            {
                if (playerKnight_.heroHealth <= 0)
                {
                    OpenDeadWindow();
                    battleWindow.GetComponent<BattleWindow>().ChangePlayerDeath();
                    AudioManager.instance.PlaySound_HeroDeath();
                    yield break;
                }
                else if (playerKnight_.heroHealth > 0)
                {
                    AttackPlayer(playerKnight_, enemy_);
                    CheckCounter(playerKnight_, enemy_);
                }
            }
        }
    }
    #endregion

    //전투관련 함수//////////////////////////////////////////////////////////////////////////////

    #region 플레이어의 카운터 여부를 판정하는 함수
    public void CheckCounter(Knight playerKnight_, Enemy attacker_)
    {
        hitChance = Random.Range(0, 100);

        if (hitChance > playerKnight_.heroCounter)
        {
            /*Do Nothing*/
            Debug.LogFormat("[CheckCounter]: 카운터 발동실패\n확률 : {0}, 카운터확률 : {1}", hitChance, playerKnight_.heroCounter);

        }
        else
        {
            Debug.LogFormat("[CheckCounter]: 카운터 발동\n확률 : {0}, 카운터확률 : {1}", hitChance, playerKnight_.heroCounter);
            AttackTarget(playerKnight_, attacker_);
        }
    }
    #endregion

    #region 플레이어가 몬스터를 공격하는 함수 (몬스터의 방어력에 따라 데미지 감소)
    public void AttackTarget(Knight playerKnight_, Enemy targetEnemy_)
    {
        // 플레이어의 데미지는 최소공격력과 최대 공격력 사이에서 결정된다.
        playerDMG = Random.Range(playerKnight_.heroDamageMin, playerKnight_.heroDamageMax);

        battleWindow.GetComponent<BattleWindow>().ChangePlayerAttack();
        AudioManager.instance.PlaySound_HeroAttack();

        // 만약 적의 방어력이 플레이어 데미지보다 높다면,
        if (targetEnemy_.enemyDEF >= playerDMG)
        {
            Debug.LogFormat("[AttackTarget]: 플레이어의 공격이 가로막혔다\n몬스터 방어력: {0}, 플레이어 공격력 : {1}", targetEnemy_.enemyDEF, playerDMG);
            targetEnemy_.enemyHP -= playerKnight_.heroDamageMagic;
            Debug.LogFormat("[AttackTarget]: 플레이어의 마법데미지 : {0}, 남은 적의 체력 : {1}", playerKnight_.heroDamageMagic, targetEnemy_.enemyHP);
            playerKnight_.heroHealth += (0.01f * playerKnight_.heroVamp * playerKnight_.heroDamageMagic);
            Debug.LogFormat("[AttackTarget]: 플레이어의 흡혈 : {0}, 플레이어의 체력 : {1}", 0.01f * playerKnight_.heroVamp * playerKnight_.heroDamageMagic, playerKnight_.heroHealth);

            battleWindow.GetComponent<BattleWindow>().ChangeEnemyCharge(targetEnemy_);
        }
        // 그 외 상황에서는,
        else
        {
            Debug.LogFormat("[AttackTarget]: 플레이어의 공격\n몬스터 방어력 : {0}, 플레이어 공격력 : {1}", targetEnemy_.enemyDEF, playerDMG);
            targetEnemy_.enemyHP -= (playerKnight_.heroDamageMagic + (playerDMG - targetEnemy_.enemyDEF));
            Debug.LogFormat("[AttackTarget]: 플레이어의 가한데미지 : {0}, 남은 적의 체력 : {1}", playerKnight_.heroDamageMagic + (playerDMG - targetEnemy_.enemyDEF), targetEnemy_.enemyHP);

            battleWindow.GetComponent<BattleWindow>().ChangeEnemyHurt1(targetEnemy_);

            if (playerKnight_.heroHealthMax <= playerKnight_.heroHealth + (0.01f * playerKnight_.heroVamp * (playerKnight_.heroDamageMagic + (playerDMG - targetEnemy_.enemyDEF))))
            {
                playerKnight_.heroHealth = playerKnight_.heroHealthMax;
                Debug.LogFormat("[AttackTarget]: 현재 플레이어의 체력은 최대치이다. {0}", playerKnight_.heroHealth);
            }
            else
            {
                playerKnight_.heroHealth += (0.01f * playerKnight_.heroVamp * (playerKnight_.heroDamageMagic + (playerDMG - targetEnemy_.enemyDEF)));
                Debug.LogFormat("[AttackTarget]: 플레이어의 흡혈 : {0}, 플레이어의 체력 : {1}", 0.01f * playerKnight_.heroVamp * (playerKnight_.heroDamageMagic + (playerDMG - targetEnemy_.enemyDEF)), playerKnight_.heroHealth);
            }
        }
    }
    #endregion

    #region 플레이어가 전체 공격을 가하는 함수
    public void AttackAll(Knight playerKnight_, List<Enemy> enemies_)
    {
        for (int i = 0; i < enemies_.Count; i++)
        {
            enemies_[i].enemyHP -= playerKnight_.heroDamageAll;
            Debug.LogFormat("[AttackAll]: 플레이어의 전체공격 데미지 : {0}", playerKnight_.heroDamageAll);
        }
        AudioManager.instance.PlaySound_HeroAttack();
    }
    #endregion

    #region 몬스터가 플레이어를 공격하는 함수 (플레이어의 방어력에 따라 데미지 감소)
    public void AttackPlayer(Knight playerKnight_, Enemy enemy_)
    {
        battleWindow.GetComponent<BattleWindow>().ChangeEnemyAttack(enemy_);
        if (enemy_.enemyID == 113) 
        {
            AudioManager.instance.PlaySound_LichAttack();
        }
        else 
        {
            AudioManager.instance.PlaySound_EnemyAttack();
        }

        // 만약 플레이어의 방어력이 몬스터의 공격력보다 높다면,
        if (playerKnight_.heroDefense >= enemy_.enemyDMG)
        {
            /*Do Nothing*/
            Debug.LogFormat("[AttackPlayer]: {2}몬스터의 공격이 가로막혔다\n플레이어 방어력 : {0}, 몬스터 공격력 : {1}", playerKnight_.heroDefense, enemy_.enemyDMG, enemy_);
            battleWindow.GetComponent<BattleWindow>().ChangePlayerCharge();
        }
        // 그 외 상황에서는,
        else
        {
            // 데미지(몬스터 공격력 - 플레이어 방어력)를 플레이어 체력에서 뺀다.
            playerKnight_.heroHealth -= enemy_.enemyDMG - playerKnight_.heroDefense;
            Debug.LogFormat("[AttackPlayer]: {2}몬스터의 공격\n플레이어 방어력 : {0}, 몬스터 공격력 : {1}", playerKnight_.heroDefense, enemy_.enemyDMG, enemy_);
            battleWindow.GetComponent<BattleWindow>().ChangePlayerHurt1();
        }
    }
    #endregion
}
