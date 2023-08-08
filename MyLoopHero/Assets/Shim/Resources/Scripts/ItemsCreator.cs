using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsCreator : MonoBehaviour
{
    // ScriptReader에서 읽어올 아이템데이터를 위해 scriptReader를 만든다.
    private ScriptReader scriptReader;


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
    public float[] itemVampiric { get; private set; }
    //아이템 능력치 : 방어력
    public float[] itemSubDefense { get; private set; }
    // } 아이템의 능력치 필드



    private void Awake()
    {
        //scriptReader = GetComponent<ScriptReader>();
        //PutItemData();

        //Debug.Log(itemID[0]);
        //Debug.Log(itemSubDefense[16]);
    }



    // { 아이템 생성
    private void MakeItem() 
    {
        
    }
    // } 아이템 생성



    // { 불러온 itemDataList의 데이터를 하나씩 맞춰주는 함수
    //private void PutItemData() 
    //{
    //    for(int i = 0; i < scriptReader.splitDataOnce_Length; i++) 
    //    {
    //        itemID[i] = int.Parse(scriptReader.itemDataList[19 * i]);
    //        itemType[i] = scriptReader.itemDataList[(19 * i) + 1];
    //        itemName[i] = scriptReader.itemDataList[(19 * i) + 2];
    //        itemSprite[i] = scriptReader.itemDataList[(19 * i) + 3];
    //        itemAbilityRatio[i] = float.Parse(scriptReader.itemDataList[(19 * i) + 4]);
    //        itemAbilityCount[i] = int.Parse(scriptReader.itemDataList[(19 * i) + 5]);
    //        itemLevel[i] = int.Parse(scriptReader.itemDataList[(19 * i) + 6]);
    //        itemMinDamage[i] = float.Parse(scriptReader.itemDataList[(19 * i) + 7]);
    //        itemMaxDamage[i] = float.Parse(scriptReader.itemDataList[(19 * i) + 8]);
    //        itemHP[i] = float.Parse(scriptReader.itemDataList[(19 * i) + 9]);
    //        itemDefense[i] = float.Parse(scriptReader.itemDataList[(19 * i) + 10]);
    //        itemMagicDamage[i] = float.Parse(scriptReader.itemDataList[(19 * i) + 11]);
    //        itemAttackSpeed[i] = float.Parse(scriptReader.itemDataList[(19 * i) + 12]);
    //        itemDamageAll[i] = float.Parse(scriptReader.itemDataList[(19 * i) + 13]);
    //        itemCounter[i] = float.Parse(scriptReader.itemDataList[(19 * i) + 14]);
    //        itemRegen[i] = float.Parse(scriptReader.itemDataList[(19 * i) + 15]);
    //        itemEvade[i] = float.Parse(scriptReader.itemDataList[(19 * i) + 16]);
    //        itemVampiric[i] = float.Parse(scriptReader.itemDataList[(19 * i) + 17]);
    //        itemSubDefense[i] = float.Parse(scriptReader.itemDataList[(19 * i) + 18]);
    //    }
    //}
    // } 불러온 itemDataList의 데이터를 하나씩 맞춰주는 함수
}
