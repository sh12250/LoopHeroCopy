using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

public class ScriptReader : MonoBehaviour
{
    // �о�� TextAsset ������ ������ ���� ����
    private TextAsset itemDataFile = default;

    // ���������� ������ ������ �ɰ��� ���� �迭
    public string[] itemDataList { get; private set; }

    // �ܺο��� ������ splitDataOnce_ �� ����
    public int splitDataOnce_Length = default;



    private void Awake()
    {
        ReadCSV();
        SplitAndSaveData();
    }



    private void ReadCSV() 
    {
        itemDataFile = AssetDatabase.LoadAssetAtPath<TextAsset>("Assets/Shim/Resources/DataFiles/ItemDatabase_Test.csv");
        //Debug.Log(itemDataFile);
    }



    private void SplitAndSaveData() 
    {
        string dataTrimNull_ = default;
        string[] splitDataOnce_ = default;
        string[] splitDataTwice_ = default;

        dataTrimNull_ = itemDataFile.text.TrimEnd();
        splitDataOnce_ = dataTrimNull_.Split("\n");

        splitDataOnce_Length = splitDataOnce_.Length;

        for (int j = 0; j < splitDataOnce_.Length; j++) 
        {
            //Debug.Log(splitDataOnce_[j]);
            splitDataTwice_ = splitDataOnce_[j].Split(",");

            for(int i = 0; i < splitDataTwice_.Length; i++) 
            {
                //Debug.Log(splitDataTwice_[i]);
                itemDataList = splitDataTwice_;
                Debug.Log(itemDataList[i]);
            }
        }
    }
}
