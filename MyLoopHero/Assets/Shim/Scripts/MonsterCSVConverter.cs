using UnityEditor;
using UnityEngine;

public class MonsterCSVConverter : MonoBehaviour
{
    private static MonsterCSVConverter monsConverter_Instance;
    // �̱������� �����
    public static MonsterCSVConverter instance
    {
        get
        {
            if (monsConverter_Instance == null)
            {
                monsConverter_Instance = FindObjectOfType<MonsterCSVConverter>();
            }
            return monsConverter_Instance;
        }
    }

    // �о�� TextAsset ������ ������ ���� ����
    private TextAsset monsterDataFile = default;

    // ���������� ������ ������ �ɰ��� ���� �迭
    public string[] monsterDataList { get; private set; }

    // �ܺο��� ������ csv ���� �� ũ�� (test csv: 17)
    public int csvRowCount { get; private set; }
    // �ܺο��� ������ csv ���� �� ũ�� (test csv: 19)
    public int csvColumnCount { get; private set; }



    // { ���� ��������Ʈ (�ִϸ��̼� �Ⱦ��� ���ؼ� 6���� ���¸� ����)
    public string[] enemyIdle { get; private set; }
    public string[] enemyCharge { get; private set; }
    public string[] enemyAttack { get; private set; }
    public string[] enemyHurt_0 { get; private set; }
    public string[] enemyHurt_1 { get; private set; }
    public string[] enemyDeath { get; private set; }
    // } ���� ��������Ʈ

    // { ���� �ɷ�ġ
    public int[] enemyID { get; private set; }
    public string[] enemyName { get; private set; }
    public float[] enemyHP { get; private set; }
    public float[] enemyDMG { get; private set; }
    public float[] enemyDEF { get; private set; }
    public float[] enemySpeed { get; private set; }
    public float[] enemyEvade { get; private set; }
    public float[] enemyRegen { get; private set; }
    public float[] enemyItemChance { get; private set; }
    //public float[] enemyItemTier { get; private set; }
    // } ���� �ɷ�ġ



    private void Awake()
    {
        ReadCSV();
        CheckCSVRowColumn();

        monsterDataList = new string[(csvRowCount) * (csvColumnCount)];

        //Debug.Log(csvRowCount);
        //Debug.Log(itemDataList.Length);

        SplitData();
        InitArrays();

        //Debug.Log(itemDataList[19]);
        //Debug.Log(itemDataList[304]);

        SortData();
    }



    private void ReadCSV()
    {
        monsterDataFile = Resources.
            Load<TextAsset>
            ("DataFiles/MonsterDatabase");
    }

    private void CheckCSVRowColumn()
    {
        string dataTrimNull_ = monsterDataFile.text.TrimEnd();
        string[] tempRow_ = default;
        string[] tempColumn_ = default;



        tempRow_ = dataTrimNull_.Split("\n");
        csvRowCount = tempRow_.Length;
        //Debug.LogFormat("dd{0}", tempRow_);
        //foreach (var tmp in tempRow_)
        //{
        //    Debug.Log(" / "+tmp);
        //}

        tempColumn_ = tempRow_[0].Split(",");
        csvColumnCount = tempColumn_.Length;
    }

    private void SplitData()
    {
        string dataTrimNull_ = monsterDataFile.text.TrimEnd();
        string[] splitdata_ = default;

        splitdata_ = dataTrimNull_.Split(new char[] { '\n', ',' });

        for (int i = 0; i < csvRowCount * csvColumnCount; i++)
        {
            monsterDataList[i] = splitdata_[i];
        }
    }

    // { ���� �迭 �ʱ�ȭ
    private void InitArrays()
    {
        enemyID = new int[csvRowCount];
        enemyName = new string[csvRowCount];

        enemyIdle = new string[csvRowCount];
        enemyCharge = new string[csvRowCount];
        enemyAttack = new string[csvRowCount];
        enemyHurt_0 = new string[csvRowCount];
        enemyHurt_1 = new string[csvRowCount];
        enemyDeath = new string[csvRowCount];

        enemyHP = new float[csvRowCount];
        enemyDMG = new float[csvRowCount];
        enemyDEF = new float[csvRowCount];
        enemySpeed = new float[csvRowCount];
        enemyEvade = new float[csvRowCount];
        enemyRegen = new float[csvRowCount];
        enemyItemChance = new float[csvRowCount];
        //enemyItemTier = new float[csvRowCount];
    }
    // } ���� �迭 �ʱ�ȭ

    private void SortData()
    {
        // TODO : �����ѹ� ���ֱ�
        for (int i = 0; i < csvRowCount - 1; i++)
        {
            enemyID[i] = int.Parse(monsterDataList[csvColumnCount * (i + 1)]);
            enemyName[i] = monsterDataList[(csvColumnCount * (i + 1)) + 1];

            enemyIdle[i] = monsterDataList[(csvColumnCount * (i + 1)) + 2];
            enemyCharge[i] = monsterDataList[(csvColumnCount * (i + 1)) + 3];
            enemyAttack[i] = monsterDataList[(csvColumnCount * (i + 1)) + 4];
            enemyHurt_0[i] = monsterDataList[(csvColumnCount * (i + 1)) + 5];
            enemyHurt_1[i] = monsterDataList[(csvColumnCount * (i + 1)) + 6];
            enemyDeath[i] = monsterDataList[(csvColumnCount * (i + 1)) + 7];

            enemyHP[i] = float.Parse(monsterDataList[(csvColumnCount * (i + 1)) + 8]);
            enemyDMG[i] = float.Parse(monsterDataList[(csvColumnCount * (i + 1)) + 9]);
            enemyDEF[i] = float.Parse(monsterDataList[(csvColumnCount * (i + 1)) + 10]);
            enemySpeed[i] = float.Parse(monsterDataList[(csvColumnCount * (i + 1)) + 11]);
            enemyEvade[i] = float.Parse(monsterDataList[(csvColumnCount * (i + 1)) + 12]);
            enemyRegen[i] = float.Parse(monsterDataList[(csvColumnCount * (i + 1)) + 13]);
            enemyItemChance[i] = float.Parse(monsterDataList[(csvColumnCount * (i + 1)) + 14]);
            //enemyItemTier[i] = float.Parse(monsterDataList[(csvColumnCount * (i + 1)) + 15]);
        }
    }
}
