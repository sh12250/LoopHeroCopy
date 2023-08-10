//using Mono.Cecil;
//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting.FullSerializer;
using UnityEditor;
//using UnityEditor.UIElements;
//using UnityEditor.VersionControl;
using UnityEngine;
//using UnityEngine.Rendering;

public class CSVConverter : MonoBehaviour
{
    private static CSVConverter converter_Instance;
    // 싱글턴으로 만들기
    public static CSVConverter instance
    {
        get
        {
            if (converter_Instance == null)
            {
                converter_Instance = FindObjectOfType<CSVConverter>();
            }
            return converter_Instance;
        }
    }

    // 읽어온 TextAsset 파일의 정보를 담을 변수
    private TextAsset itemDataFile = default;

    // 최종적으로 데이터 파일을 쪼개서 담을 배열
    public string[] itemDataList { get; private set; }

    // 외부에서 접근할 csv 파일 행 크기 (test csv: 17)
    public int csvRowCount { get; private set; }
    // 외부에서 접근할 csv 파일 열 크기 (test csv: 19)
    public int csvColumnCount { get; private set; }



    // { 아이템 데이터 관련 변수 (UI에 표현되지 않음)
    public int[] itemID { get; private set; }
    public string[] itemType { get; private set; }
    public string[] itemSprite { get; private set; }
    public float[] itemAbilityRatio { get; private set; }
    public int[] itemAbilityCount { get; private set; }
    // } 아이템 데이터 관련 변수 (UI에 표현되지 않음)



    // { 아이템의 능력치 필드
    //아이템 이름
    public string[] itemName { get; private set; }
    //아이템 레벨
    public int[] itemLevel { get; private set; }
    //아이템 능력치 : 최소피해 (무기)
    public float[] itemMinDamage { get; private set; }
    //아이템 능력치 : 최대피해 (무기)
    public float[] itemMaxDamage { get; private set; }
    //아이템 능력치 : HP (방어구)
    public float[] itemHP { get; private set; }
    //아이템 능력치 : 방어력 (방패)
    public float[] itemDefense { get; private set; }
    //아이템 능력치 : 순수피해
    public float[] itemMagicDamage { get; private set; }
    //아이템 능력치 : 공격속도
    public float[] itemAttackSpeed { get; private set; }
    //아이템 능력치 : 전체에게 피해
    public float[] itemDamageAll { get; private set; }
    //아이템 능력치 : 반격
    public float[] itemCounter { get; private set; }
    //아이템 능력치 : 초당 회복량
    public float[] itemRegen { get; private set; }
    //아이템 능력치 : 회피
    public float[] itemEvade { get; private set; }
    //아이템 능력치 : 흡혈
    public float[] itemVamp { get; private set; }
    //아이템 능력치 : 방어력
    public float[] itemSubDefense { get; private set; }
    // } 아이템의 능력치 필드



    private void Awake()
    {
        ReadCSV();
        CheckCSVRowColumn();

        itemDataList = new string[csvRowCount * csvColumnCount];
        
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
        itemDataFile = AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/Shim/Resources/DataFiles/ItemDatabase_Test.csv");
        //Debug.Log(itemDataFile);
    }

    private void CheckCSVRowColumn()
    {
        string dataTrimNull_ = itemDataFile.text.TrimEnd();
        string[] tempRow_ = default;
        string[] tempColumn_ = default;

        tempRow_ = dataTrimNull_.Split("\n");
        csvRowCount = tempRow_.Length;

        tempColumn_ = tempRow_[0].Split(",");
        csvColumnCount = tempColumn_.Length;
    }

    private void SplitData()
    {
        Debug.Log(itemDataFile.text);
        string dataTrimNull_ = itemDataFile.text.TrimEnd();
        string[] splitdata_ = default;

        splitdata_ = dataTrimNull_.Split(new char[] {'\n' , ','});


        for (int i = 0; i < csvRowCount * csvColumnCount; i++)
        {
            itemDataList[i] = splitdata_[i];
        }
    }

    private void InitArrays()
    {
        itemID = new int[csvRowCount];
        itemType = new string[csvRowCount];
        itemName = new string[csvRowCount];
        itemSprite = new string[csvRowCount];
        itemAbilityRatio = new float[csvRowCount];
        itemAbilityCount = new int[csvRowCount];
        itemLevel = new int[csvRowCount];
        itemMinDamage = new float[csvRowCount];
        itemMaxDamage = new float[csvRowCount];
        itemHP = new float[csvRowCount];
        itemDefense = new float[csvRowCount];
        itemMagicDamage = new float[csvRowCount];
        itemAttackSpeed = new float[csvRowCount];
        itemDamageAll = new float[csvRowCount];
        itemCounter = new float[csvRowCount];
        itemRegen = new float[csvRowCount];
        itemEvade = new float[csvRowCount];
        itemVamp = new float[csvRowCount];
        itemSubDefense = new float[csvRowCount];
    }
    // } 아이템 능력치 배열 초기화

    private void SortData() 
    {
        for (int i = 0; i < csvRowCount - 1; i++)
        {
            itemID[i] = int.Parse(itemDataList[csvColumnCount * (i + 1)]);
            itemType[i] = itemDataList[(csvColumnCount * (i + 1)) + 1];
            itemName[i] = itemDataList[(csvColumnCount * (i + 1)) + 2];
            itemSprite[i] = itemDataList[(csvColumnCount * (i + 1)) + 3];
            itemAbilityRatio[i] = float.Parse(itemDataList[(csvColumnCount * (i + 1)) + 4]);
            itemAbilityCount[i] = int.Parse(itemDataList[(csvColumnCount * (i + 1)) + 5]);
            itemLevel[i] = int.Parse(itemDataList[(csvColumnCount * (i + 1)) + 6]);
            itemMinDamage[i] = float.Parse(itemDataList[(csvColumnCount * (i + 1)) + 7]);
            itemMaxDamage[i] = float.Parse(itemDataList[(csvColumnCount * (i + 1)) + 8]);
            itemHP[i] = float.Parse(itemDataList[(csvColumnCount * (i + 1)) + 9]);
            itemDefense[i] = float.Parse(itemDataList[(csvColumnCount * (i + 1)) + 10]);
            itemMagicDamage[i] = float.Parse(itemDataList[(csvColumnCount * (i + 1)) + 11]);
            itemAttackSpeed[i] = float.Parse(itemDataList[(csvColumnCount * (i + 1)) + 12]);
            itemDamageAll[i] = float.Parse(itemDataList[(csvColumnCount * (i + 1)) + 13]);
            itemCounter[i] = float.Parse(itemDataList[(csvColumnCount * (i + 1)) + 14]);
            itemRegen[i] = float.Parse(itemDataList[(csvColumnCount * (i + 1)) + 15]);
            itemEvade[i] = float.Parse(itemDataList[(csvColumnCount * (i + 1)) + 16]);
            itemVamp[i] = float.Parse(itemDataList[(csvColumnCount * (i + 1)) + 17]);
            itemSubDefense[i] = float.Parse(itemDataList[(csvColumnCount * (i + 1)) + 18]);
        }
    }
}
