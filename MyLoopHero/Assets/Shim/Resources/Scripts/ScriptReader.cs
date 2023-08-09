using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;

public class ScriptReader : MonoBehaviour
{
    // 읽어온 TextAsset 파일의 정보를 담을 변수
    private TextAsset itemDataFile = default;

    // 최종적으로 데이터 파일을 쪼개서 담을 배열
    public string[] itemDataList { get; private set; }

    // 외부에서 접근할 splitDataOnce_ 의 길이
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
