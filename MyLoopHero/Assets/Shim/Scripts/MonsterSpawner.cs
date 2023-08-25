using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    private static MonsterSpawner monsterSpawner_Instance;
    // �̱������� �����
    public static MonsterSpawner instance
    {
        get
        {
            if (monsterSpawner_Instance == null)
            {
                monsterSpawner_Instance = FindObjectOfType<MonsterSpawner>();
            }
            return monsterSpawner_Instance;
        }
    }


    public MonsterCSVConverter monsterCSVConverter { get; private set; }
    public GameObject monsterPrefab;
    public Enemy[] enemies { get; private set; }
    //public Dictionary<int, Item[]> itemDictionary { get; private set; }
    public Object[] idleSprites { get; private set; }
    public Object[] chargeSprites { get; private set; }
    public Object[] attackSprites { get; private set; }
    public Object[] hurt_0Sprites { get; private set; }
    public Object[] hurt_1Sprites { get; private set; }
    public Object[] deathSprites { get; private set; }


    private void Awake()
    {
        // ! ���߿� monsterSpawner hierarchy ��ġ�� ���� parent �� �ٿ���� �� �� ����
        //Debug.Log(transform.parent.GetComponentInChildren<MonsterCSVConverter>());
        monsterCSVConverter = transform.parent.GetComponentInChildren<MonsterCSVConverter>();
        enemies = new Enemy[monsterCSVConverter.csvRowCount];
        idleSprites = new Object[monsterCSVConverter.csvRowCount];
        chargeSprites = new Object[monsterCSVConverter.csvRowCount];
        attackSprites = new Object[monsterCSVConverter.csvRowCount];
        hurt_0Sprites = new Object[monsterCSVConverter.csvRowCount];
        hurt_1Sprites = new Object[monsterCSVConverter.csvRowCount];
        deathSprites = new Object[monsterCSVConverter.csvRowCount];


        InstantiateEnemy();
        GiveEnemyStat();
        GiveEnemySprite();
    }

    private void InstantiateEnemy()
    {
        for (int i = 0; i < monsterCSVConverter.csvRowCount - 1; i++)
        {
            enemies[i] = Instantiate(monsterPrefab, new Vector3(20f, 0f, 0f), Quaternion.identity, this.transform).GetComponent<Enemy>();
        }
    }


    private void GiveEnemyStat()
    {
        for (int i = 0; i < monsterCSVConverter.csvRowCount - 1; i++)
        {
            enemies[i].enemyID = monsterCSVConverter.enemyID[i];
            enemies[i].enemyName = monsterCSVConverter.enemyName[i];
            enemies[i].enemyHP = monsterCSVConverter.enemyHP[i];
            enemies[i].enemyDMG = monsterCSVConverter.enemyDMG[i];
            enemies[i].enemyDEF = monsterCSVConverter.enemyDEF[i];
            enemies[i].enemySpeed = monsterCSVConverter.enemySpeed[i];
            enemies[i].enemyEvade = monsterCSVConverter.enemyEvade[i];
            enemies[i].enemyRegen = monsterCSVConverter.enemyRegen[i];
            enemies[i].enemyItemChance = monsterCSVConverter.enemyItemChance[i];
            //enemies[i].enemyItemTier = monsterCSVConverter.enemyItemTier[i];
        }
    }


    private void GiveEnemySprite()
    {
        // ! ��������Ʈ �迭�� ���� ���߱� ���ؼ� Equiptest ���� ���� ����
        // ! LoadAll�� ��� ������ �ҷ����Ƿ�, sprite ������ ���δ� texture�� ���� �ҷ���
        // ! �� ���� ������ �迭�� 2��� Ŀ�� -> �޾ƿ� �������� �ڷ����� ����ؾ���
        attackSprites = Resources.LoadAll<Sprite>("Sprites/BattleSprite/Monster/Attack");
        chargeSprites = Resources.LoadAll<Sprite>("Sprites/BattleSprite/Monster/Charge");
        deathSprites = Resources.LoadAll<Sprite>("Sprites/BattleSprite/Monster/Death");
        hurt_0Sprites = Resources.LoadAll<Sprite>("Sprites/BattleSprite/Monster/Hurt0");
        hurt_1Sprites = Resources.LoadAll<Sprite>("Sprites/BattleSprite/Monster/Hurt1");
        idleSprites = Resources.LoadAll<Sprite>("Sprites/BattleSprite/Monster/Idle");




        // csv ������ �غ��� �� Resources.LoadAll�� �ҷ����� ������ ����ؾ���
        for (int i = 0; i < attackSprites.Length; i++)
        {
            if (attackSprites[i].name == monsterCSVConverter.enemyAttack[i])
            {
                enemies[i].enemyAttack = (Sprite)attackSprites[i];
            }
            if (chargeSprites[i].name == monsterCSVConverter.enemyCharge[i])
            {
                enemies[i].enemyCharge = (Sprite)chargeSprites[i];
            }
            if (deathSprites[i].name == monsterCSVConverter.enemyDeath[i])
            {
                enemies[i].enemyDeath = (Sprite)deathSprites[i];
            }
            if (hurt_0Sprites[i].name == monsterCSVConverter.enemyHurt_0[i])
            {
                enemies[i].enemyHurt_0 = (Sprite)hurt_0Sprites[i];
            }
            if (hurt_1Sprites[i].name == monsterCSVConverter.enemyHurt_1[i])
            {
                enemies[i].enemyHurt_1 = (Sprite)hurt_1Sprites[i];
            }
            if (idleSprites[i].name == monsterCSVConverter.enemyIdle[i])
            {
                enemies[i].enemyIdle = (Sprite)idleSprites[i];
            }
        }
    }
}
