using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBuilder : MonoBehaviour
{
    private static ItemBuilder itemBuilder_Instance;
    // �̱������� �����
    public static ItemBuilder instance
    {
        get
        {
            if (itemBuilder_Instance == null)
            {
                itemBuilder_Instance = FindObjectOfType<ItemBuilder>();
            }
            return itemBuilder_Instance;
        }
    }


    public CSVConverter csvConverter { get; private set; }
    public GameObject itemPrefab;
    public Item[] items { get; private set; }
    //public Dictionary<int, Item[]> itemDictionary { get; private set; }
    public Object[] itemSprites { get; private set; }


    private void Awake()
    {
        csvConverter = transform.parent.GetComponentInChildren<CSVConverter>();
        items = new Item[csvConverter.csvRowCount];
        //itemDictionary = new Dictionary<int, Item[]>();
        itemSprites = new Object[csvConverter.csvRowCount];
        //Debug.Log(csvConverter);


        InstantiateItem();
        GiveItemHiddenValue();
        GiveItemValue();
        GiveItemTag();
        GiveItemSprite();


        //gameObject.SetActive(true);
        //gameObject.SetActive(false);

    }

    private void InstantiateItem()
    {
        for (int i = 0; i < csvConverter.csvRowCount - 1; i++)
        {
            items[i] = Instantiate(itemPrefab, new Vector3(20f, 0f, 0f), Quaternion.identity, this.transform).GetComponent<Item>();
        }
    }

    private void GiveItemHiddenValue()
    {
        for (int i = 0; i < csvConverter.csvRowCount - 1; i++)
        {
            items[i].itemID = csvConverter.itemID[i];
            items[i].itemType = csvConverter.itemType[i];
            //items[i].itemSprite = csvConverter.itemSprite[i];
            items[i].itemAbilityRatio = csvConverter.itemAbilityRatio[i];
            items[i].itemAbilityCount = csvConverter.itemAbilityCount[i];
        }
    }

    private void GiveItemValue()
    {
        for (int i = 0; i < csvConverter.csvRowCount - 1; i++)
        {
            items[i].itemName = csvConverter.itemName[i];
            items[i].itemLevel = csvConverter.itemLevel[i];
            items[i].itemMinDamage = csvConverter.itemMinDamage[i];
            items[i].itemMaxDamage = csvConverter.itemMaxDamage[i];
            items[i].itemHP = csvConverter.itemHP[i];
            items[i].itemDefense = csvConverter.itemDefense[i];
            items[i].itemMagicDamage = csvConverter.itemMagicDamage[i];
            items[i].itemAttackSpeed = csvConverter.itemAttackSpeed[i];
            items[i].itemDamageAll = csvConverter.itemDamageAll[i];
            items[i].itemCounter = csvConverter.itemCounter[i];
            items[i].itemRegen = csvConverter.itemRegen[i];
            items[i].itemEvade = csvConverter.itemEvade[i];
            items[i].itemVamp = csvConverter.itemVamp[i];
            items[i].itemSubDefense = csvConverter.itemSubDefense[i];
        }
    }

    private void GiveItemTag()
    {
        for (int i = 0; i < csvConverter.csvRowCount - 1; i++)
        {
            // itemType�� ������� �Ȱ��� ����� ���ϴ�.
            if (items[i].itemType == "Weapon")
            {
                items[i].tag = "Weapon";
            }
            else if (items[i].itemType == "Ring")
            {
                items[i].tag = "Ring";
            }
            else if (items[i].itemType == "Shield")
            {
                items[i].tag = "Shield";
            }
            else if (items[i].itemType == "Armor")
            {
                items[i].tag = "Armor";
            }
            else
            {
                Debug.Log("�±� �ο� ����");
            }
        }
    }


    private void GiveItemSprite()
    {
        // ! ��������Ʈ �迭�� ���� ���߱� ���ؼ� Equiptest ���� ���� ����
        // ! LoadAll�� ��� ������ �ҷ����Ƿ�, sprite ������ ���δ� texture�� ���� �ҷ���
        // ! �� ���� ������ �迭�� 2��� Ŀ�� -> �޾ƿ� �������� �ڷ����� ����ؾ���
        itemSprites = Resources.LoadAll<Sprite>("Sprites/Equiptest");

        // csv ������ �غ��� �� Resources.LoadAll�� �ҷ����� ������ ����ؾ���
        for (int i = 0; i < itemSprites.Length; i++)
        {
            //Debug.LogFormat("����� : {0}", itemSprites[i].name);
            //Debug.LogFormat("CSV : {0}", csvConverter.itemSprite[i]);

            if (itemSprites[i].name == csvConverter.itemSprite[i])
            {
                items[i].itemSprite = (Sprite)itemSprites[i];
            }
        }
    }
}
