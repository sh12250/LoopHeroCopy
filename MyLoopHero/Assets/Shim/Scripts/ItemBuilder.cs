using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class ItemBuilder : MonoBehaviour
{
    private static ItemBuilder itemBuilder_Instance;
    // 싱글턴으로 만들기
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
    public Sprite[] itemSprites { get; private set; }


    private void Awake()
    {
        csvConverter = transform.parent.GetComponentInChildren<CSVConverter>();
        items = new Item[csvConverter.csvRowCount];
        itemSprites = new Sprite[csvConverter.csvRowCount];
        Debug.Log(csvConverter);


        InstantiateItem();
        GiveItemHiddenValue();
        GiveItemValue();
        GiveItemTag();
        //GiveItemSprite();


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
            items[i].itemSprite = csvConverter.itemSprite[i];
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
            // itemType은 폴더명과 똑같이 만들면 편하다.
            if (items[i].itemType == "Weapon")
            {
                items[i].tag = "Sword";
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
                Debug.Log("태그 부여 오류");
            }
        }
    }


    //private void GiveItemSprite() 
    //{
    //    itemSprites = (Sprite[])AssetDatabase.LoadAllAssetRepresentationsAtPath
    //            ("Assets/Shim/Resources/Sprites/Equipment" + );

    //    for (int i = 0; i < itemSprites.Length; i++)
    //    {
    //        Debug.Log(itemSprites[i]);
    //    }
    //}
}
