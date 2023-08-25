using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UI_DragZone_Inven : MonoBehaviour
{
    public static UI_DragZone_Inven instance;

    private ItemBuilder itemBuilder;
    private GameObject dragZone_Inven;
    static public GameObject[] invenSlots { get; private set; }

    public List<GameObject> invenSlots2;

    static public GameObject[] slotImages { get; private set; }

    public int itemInInvenCnt;


    //enum ChildrenOfDragZone_Inven
    //{
    //    Inven_Slot1 = 0,
    //    Inven_Slot2 = 1,
    //    Inven_Slot3 = 2,
    //    Inven_Slot4 = 3,
    //    Inven_Slot5 = 4,
    //    Inven_Slot6 = 5,
    //    Inven_Slot7 = 6,
    //    Inven_Slot8 = 7,
    //    Inven_Slot9 = 8,
    //    Inven_Slot10 = 9,
    //    Inven_Slot11 = 10,
    //    Inven_Slot12 = 11
    //}

    private void Awake()
    {
        if (instance == null || instance == default)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("UI_DragZone_Inven가 너무 많습니다");
        }

        itemBuilder = transform.parent.GetComponentInChildren<ItemBuilder>();

        itemInInvenCnt = 0;

        MakeInvenSlotArray();
        MakeSlotImageArray();
        TurnAllInvenSlotDefault();
    }

    void Update()
    {

    }

    private void MakeInvenSlotArray()
    {
        dragZone_Inven = this.gameObject;
        invenSlots = new GameObject[dragZone_Inven.transform.childCount];

        for (int i = 0; i < dragZone_Inven.transform.childCount; i++)
        {
            invenSlots[i] = gameObject.transform.GetChild(i).gameObject;
        }
    }

    private void MakeSlotImageArray()
    {
        slotImages = new GameObject[(invenSlots.Length) * (invenSlots[0].transform.childCount)];

        for (int j = 0; j < invenSlots.Length; j++)
        {
            for (int i = 0; i < invenSlots[j].transform.childCount; i++)
            {
                slotImages[(invenSlots[0].transform.childCount * j) + i] = invenSlots[j].transform.GetChild(i).gameObject;
            }
        }
    }

    private void TurnAllInvenSlotDefault()
    {
        for (int i = 0; i < invenSlots.Length; i++)
        {
            invenSlots[i].tag = "Inven";
            slotImages[i].GetComponent<Image>().sprite = null;
        }
    }

    public void MakeItem()
    {
        int randomIdx_ = Random.Range(0, itemBuilder.csvConverter.csvRowCount - 1);

        if (itemInInvenCnt < 12)
        {
            for (int i = 0; i < invenSlots.Length; i++)
            {
                if (slotImages[i].GetComponent<Image>().sprite == null)
                {
                    invenSlots[i].tag = itemBuilder.items[randomIdx_].tag;
                    invenSlots[i].name = itemBuilder.items[randomIdx_].itemName;
                    invenSlots[i].GetComponent<Item>().SetItem(itemBuilder.items[randomIdx_]);
                    invenSlots[i].SetActive(true);
                    slotImages[i].GetComponent<Image>().color = Color.white;
                    slotImages[i].GetComponent<Image>().sprite = itemBuilder.items[randomIdx_].itemSprite;

                    break;
                }
            }

            itemInInvenCnt += 1;
        }
    }

    private void MakeItemAndRemove()
    {
        int randomIdx_ = Random.Range(0, itemBuilder.csvConverter.csvRowCount - 1);

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // 인벤 비어있을 때
            if (invenSlots[0].tag == "Inven")
            {
                invenSlots[0].tag = itemBuilder.items[randomIdx_].tag;
                invenSlots[0].name = itemBuilder.items[randomIdx_].itemName;
                invenSlots[0].GetComponent<Item>().SetItem(itemBuilder.items[randomIdx_]);

                slotImages[0].GetComponent<Image>().color = Color.white;
                slotImages[0].GetComponent<Image>().sprite = itemBuilder.items[randomIdx_].itemSprite;
            }
        }
    }
}
