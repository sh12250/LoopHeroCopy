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
    // �̱������� �����
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

    // �о�� TextAsset ������ ������ ���� ����
    private TextAsset itemDataFile = default;

    // ���������� ������ ������ �ɰ��� ���� �迭
    public string[] itemDataList { get; private set; }

    // �ܺο��� ������ csv ���� �� ũ�� (test csv: 17)
    public int csvRowCount { get; private set; }
    // �ܺο��� ������ csv ���� �� ũ�� (test csv: 19)
    public int csvColumnCount { get; private set; }



    // { ������ ������ ���� ���� (UI�� ǥ������ ����)
    public int[] itemID { get; private set; }
    public string[] itemType { get; private set; }
    public string[] itemSprite { get; private set; }
    public float[] itemAbilityRatio { get; private set; }
    public int[] itemAbilityCount { get; private set; }
    // } ������ ������ ���� ���� (UI�� ǥ������ ����)



    // { �������� �ɷ�ġ �ʵ�
    //������ �̸�
    public string[] itemName { get; private set; }
    //������ ����
    public int[] itemLevel { get; private set; }
    //������ �ɷ�ġ : �ּ����� (����)
    public float[] itemMinDamage { get; private set; }
    //������ �ɷ�ġ : �ִ����� (����)
    public float[] itemMaxDamage { get; private set; }
    //������ �ɷ�ġ : HP (��)
    public float[] itemHP { get; private set; }
    //������ �ɷ�ġ : ���� (����)
    public float[] itemDefense { get; private set; }
    //������ �ɷ�ġ : ��������
    public float[] itemMagicDamage { get; private set; }
    //������ �ɷ�ġ : ���ݼӵ�
    public float[] itemAttackSpeed { get; private set; }
    //������ �ɷ�ġ : ��ü���� ����
    public float[] itemDamageAll { get; private set; }
    //������ �ɷ�ġ : �ݰ�
    public float[] itemCounter { get; private set; }
    //������ �ɷ�ġ : �ʴ� ȸ����
    public float[] itemRegen { get; private set; }
    //������ �ɷ�ġ : ȸ��
    public float[] itemEvade { get; private set; }
    //������ �ɷ�ġ : ����
    public float[] itemVamp { get; private set; }
    //������ �ɷ�ġ : ����
    public float[] itemSubDefense { get; private set; }
    // } �������� �ɷ�ġ �ʵ�



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
    // } ������ �ɷ�ġ �迭 �ʱ�ȭ

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
