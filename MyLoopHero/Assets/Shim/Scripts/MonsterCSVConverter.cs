using UnityEditor;
using UnityEngine;

public class MonsterCSVConverter : MonoBehaviour
{
    private static MonsterCSVConverter monsConverter_Instance;
    // 싱글턴으로 만들기
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

    // 읽어온 TextAsset 파일의 정보를 담을 변수
    private TextAsset monsterDataFile = default;

    // 최종적으로 데이터 파일을 쪼개서 담을 배열
    public string[] monsterDataList { get; private set; }

    // 외부에서 접근할 csv 파일 행 크기 (test csv: 17)
    public int csvRowCount { get; private set; }
    // 외부에서 접근할 csv 파일 열 크기 (test csv: 19)
    public int csvColumnCount { get; private set; }



    // { 몬스터 스프라이트 (애니메이션 안쓰기 위해서 6가지 상태만 선택)
    public string[] enemyIdle { get; private set; }
    public string[] enemyCharge { get; private set; }
    public string[] enemyAttack { get; private set; }
    public string[] enemyHurt_0 { get; private set; }
    public string[] enemyHurt_1 { get; private set; }
    public string[] enemyDeath { get; private set; }
    // } 몬스터 스프라이트

    // { 몬스터 능력치
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
    // } 몬스터 능력치



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

    // { 몬스터 배열 초기화
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
    // } 몬스터 배열 초기화

    private void SortData()
    {
        // TODO : 매직넘버 없애기
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
