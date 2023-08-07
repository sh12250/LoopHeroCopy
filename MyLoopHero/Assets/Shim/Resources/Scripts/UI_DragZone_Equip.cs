using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_DragZone_Equip : MonoBehaviour
{
    private GameObject dragZone_Equip;
    private GameObject[] equipSlots;
    private GameObject[] effects;

    enum ChildrenInDragZone_Equip
    {
        Equip_Slot_Weapon = 0,
        Equip_Slot_Ring = 1,
        Equip_Slot_Shield = 2,
        Equip_Slot_Armor = 3
    }

    enum ChildrenInEquipSlots
    {
        SwordEffect1 = 0,
        SwordEffect2 = 1,
        RingEffect1 = 2,
        RingEffect2 = 3,
        ShieldEffect1 = 4,
        ShieldEffect2 = 5,
        ArmorEffect1 = 6,
        ArmorEffect2 = 7
    }

    //=========================================================================================

    private void Awake()
    {
        MakeEquipSlotArray();

        MakeEffectArray();
        
        TurnAllEffectsOff();
    }

    //=========================================================================================

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.tag);
        //Debug.Log(equipSlots[0].tag);
        if (other.tag == equipSlots[(int)ChildrenInDragZone_Equip.Equip_Slot_Weapon].tag)
        {
            TurnSwordEffectsOn();
        }
        else if (other.tag == equipSlots[(int)ChildrenInDragZone_Equip.Equip_Slot_Ring].tag)
        {
            TurnRingEffectsOn();
        }
        else if (other.tag == equipSlots[(int)ChildrenInDragZone_Equip.Equip_Slot_Shield].tag)
        {
            TurnShieldEffectsOn();
        }
        else if (other.tag == equipSlots[(int)ChildrenInDragZone_Equip.Equip_Slot_Armor].tag)
        {
            TurnArmorEffectsOn();
        }
    }

    //=========================================================================================

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == equipSlots[(int)ChildrenInDragZone_Equip.Equip_Slot_Weapon].tag)
        {
            TurnAllEffectsOff();
        }
        else if (other.tag == equipSlots[(int)ChildrenInDragZone_Equip.Equip_Slot_Ring].tag)
        {
            TurnAllEffectsOff();
        }
        else if (other.tag == equipSlots[(int)ChildrenInDragZone_Equip.Equip_Slot_Shield].tag)
        {
            TurnAllEffectsOff();
        }
        else if (other.tag == equipSlots[(int)ChildrenInDragZone_Equip.Equip_Slot_Armor].tag)
        {
            TurnAllEffectsOff();
        }
    }

    //=========================================================================================

    private void MakeEquipSlotArray() 
    {
        dragZone_Equip = this.gameObject;
        equipSlots = new GameObject[dragZone_Equip.transform.childCount];

        for (int i = 0; i < dragZone_Equip.transform.childCount; i++)
        {
            equipSlots[i] = gameObject.transform.GetChild(i).gameObject;
        }
    }

    //=========================================================================================

    private void MakeEffectArray() 
    {
        effects = new GameObject[(equipSlots.Length) * (equipSlots[0].transform.childCount)];

        for (int j = 0; j < equipSlots.Length; j++)
        {
            for (int i = 0; i < equipSlots[j].transform.childCount; i++)
            {
                effects[(2 * j) + i] = equipSlots[j].transform.GetChild(i).gameObject;
            }
        }
    }

    //=========================================================================================

    private void TurnAllEffectsOff() 
    {
        effects[(int)ChildrenInEquipSlots.SwordEffect1].SetActive(false);
        effects[(int)ChildrenInEquipSlots.SwordEffect2].SetActive(false);
        effects[(int)ChildrenInEquipSlots.RingEffect1].SetActive(false);
        effects[(int)ChildrenInEquipSlots.RingEffect2].SetActive(false);
        effects[(int)ChildrenInEquipSlots.ShieldEffect1].SetActive(false);
        effects[(int)ChildrenInEquipSlots.ShieldEffect2].SetActive(false);
        effects[(int)ChildrenInEquipSlots.ArmorEffect1].SetActive(false);
        effects[(int)ChildrenInEquipSlots.ArmorEffect2].SetActive(false);
    }

    //=========================================================================================

    private void TurnSwordEffectsOn() 
    {
        effects[(int)ChildrenInEquipSlots.SwordEffect1].SetActive(true);
        effects[(int)ChildrenInEquipSlots.SwordEffect2].SetActive(true);
    }

    //=========================================================================================

    private void TurnRingEffectsOn()
    {
        effects[(int)ChildrenInEquipSlots.RingEffect1].SetActive(true);
        effects[(int)ChildrenInEquipSlots.RingEffect2].SetActive(true);
    }

    //=========================================================================================

    private void TurnShieldEffectsOn()
    {
        effects[(int)ChildrenInEquipSlots.ShieldEffect1].SetActive(true);
        effects[(int)ChildrenInEquipSlots.ShieldEffect2].SetActive(true);
    }

    //=========================================================================================

    private void TurnArmorEffectsOn()
    {
        effects[(int)ChildrenInEquipSlots.ArmorEffect1].SetActive(true);
        effects[(int)ChildrenInEquipSlots.ArmorEffect2].SetActive(true);
    }
}
