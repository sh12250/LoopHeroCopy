using System.Collections;
using System.Linq;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UI_DragZone_Inven : MonoBehaviour
{
    private ItemBuilder itemBuilder;
    private GameObject dragZone_Inven;
    static public GameObject[] invenSlots { get; private set; }
    static public GameObject[] slotImages { get; private set; }

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
        itemBuilder = transform.parent.GetComponentInChildren<ItemBuilder>();

        MakeInvenSlotArray();
        MakeSlotImageArray();
        TurnAllInvenSlotDefault();
    }

    void Update()
    {
        MakeItemAndRemove();
    }


    private void MakeInvenSlotArray() 
    {
        dragZone_Inven = this.gameObject;
        invenSlots = new GameObject[dragZone_Inven.transform.childCount];

        for (int i = 0; i < dragZone_Inven.transform.childCount; i++)
        {
            invenSlots[i] = gameObject.transform.GetChild(i).gameObject;
        }

        //Debug.LogFormat("[MakeInvenSlotArray] 여기에 비어있나?? {0}", invenSlots.Length);
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
            invenSlots[i].tag = "ItemSlot";
            slotImages[i].GetComponent<Image>().sprite = null;
        }
    }

    private void MakeItemAndRemove()
    {
        int randomIdx_ = Random.Range(0, itemBuilder.csvConverter.csvRowCount - 1);

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // 인벤 비어있을 때
            if (invenSlots[0].tag == "ItemSlot") 
            {
                invenSlots[0].tag = itemBuilder.items[randomIdx_].tag;
                invenSlots[0].name = itemBuilder.items[randomIdx_].itemName;
                slotImages[0].GetComponent<Image>().color = Color.white;
                slotImages[0].GetComponent<Image>().sprite = itemBuilder.items[randomIdx_].itemSprite;
            }
            // 인벤 꽉 찼을 때
            else if (invenSlots[0].tag != "ItemSlot" 
                && invenSlots[invenSlots.Length - 1].tag != "ItemSlot") 
            {
                
                
            }
            // 인벤 적당히 차 있을 때
            else if (invenSlots[0].tag != "ItemSlot"
                && invenSlots[invenSlots.Length - 1].tag == "ItemSlot")
            {
                

            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // for 문을 돌려서 현재 아이템이 있는 제일 마지막 슬롯을 찾는다.
            for (int i = invenSlots.Length - 1; i >= 0; i--)
            {
                if (invenSlots[i].tag != "ItemSlot")
                {
                    GameObject lastItem = invenSlots[i];
                    break;
                }
                else
                {
                    /* Do Nothing*/
                }
            }




            // 인벤 비어있을 때
            if (invenSlots[0].tag == "ItemSlot") 
            {
                /*Do Nothing*/
            }

            else if (invenSlots[0].tag != "ItemSlot" && invenSlots[0].tag != "ItemSlot") 
            {
            
            }

            else if (invenSlots[0].tag != "ItemSlot" && invenSlots[0].tag != "ItemSlot")
            {

            }


        }
    }

    private void SwapItem(GameObject obj1_, GameObject obj2_) 
    {
        GameObject tempObj_;
        tempObj_ = obj1_;
        obj1_ = obj2_;
        obj2_ = tempObj_;
    }
}
