using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsCreator : MonoBehaviour
{
    // ScriptReader���� �о�� �����۵����͸� ���� scriptReader�� �����.
    private ScriptReader scriptReader;


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
    public float[] itemVampiric { get; private set; }
    //������ �ɷ�ġ : ����
    public float[] itemSubDefense { get; private set; }
    // } �������� �ɷ�ġ �ʵ�



    private void Awake()
    {
        //scriptReader = GetComponent<ScriptReader>();
        //PutItemData();

        //Debug.Log(itemID[0]);
        //Debug.Log(itemSubDefense[16]);
    }



    // { ������ ����
    private void MakeItem() 
    {
        
    }
    // } ������ ����



    // { �ҷ��� itemDataList�� �����͸� �ϳ��� �����ִ� �Լ�
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
    // } �ҷ��� itemDataList�� �����͸� �ϳ��� �����ִ� �Լ�
}
