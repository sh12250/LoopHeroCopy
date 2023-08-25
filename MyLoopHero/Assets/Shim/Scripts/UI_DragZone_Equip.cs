using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_DragZone_Equip : MonoBehaviour
{
    private GameObject dragZone_Equip;
    static public GameObject[] equipSlots { get; private set; }
    private GameObject[] effects;

    enum ChildrenOfDragZone_Equip
    {
        Equip_Slot_Weapon = 0,
        Equip_Slot_Ring = 1,
        Equip_Slot_Shield = 2,
        Equip_Slot_Armor = 3
    }

    enum ChildrenOfEquipSlots
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

    #region OnTriggerStay
    private void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log(other.tag);
        //Debug.Log(equipSlots[0].tag);
        if (other.tag == equipSlots[(int)ChildrenOfDragZone_Equip.Equip_Slot_Weapon].tag)
        {
            TurnSwordEffectsOn();
        }
        else if (other.tag == equipSlots[(int)ChildrenOfDragZone_Equip.Equip_Slot_Ring].tag)
        {
            TurnRingEffectsOn();
        }
        else if (other.tag == equipSlots[(int)ChildrenOfDragZone_Equip.Equip_Slot_Shield].tag)
        {
            TurnShieldEffectsOn();
        }
        else if (other.tag == equipSlots[(int)ChildrenOfDragZone_Equip.Equip_Slot_Armor].tag)
        {
            TurnArmorEffectsOn();
        }
    }
    #endregion

    //=========================================================================================

    #region OnTriggerExit
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == equipSlots[(int)ChildrenOfDragZone_Equip.Equip_Slot_Weapon].tag)
        {
            TurnAllEffectsOff();
        }
        else if (other.tag == equipSlots[(int)ChildrenOfDragZone_Equip.Equip_Slot_Ring].tag)
        {
            TurnAllEffectsOff();
        }
        else if (other.tag == equipSlots[(int)ChildrenOfDragZone_Equip.Equip_Slot_Shield].tag)
        {
            TurnAllEffectsOff();
        }
        else if (other.tag == equipSlots[(int)ChildrenOfDragZone_Equip.Equip_Slot_Armor].tag)
        {
            TurnAllEffectsOff();
        }
    }
    #endregion

    //=========================================================================================

    #region FindingEquipSlot
    private void MakeEquipSlotArray() 
    {
        dragZone_Equip = this.gameObject;
        equipSlots = new GameObject[dragZone_Equip.transform.childCount];

        for (int i = 0; i < dragZone_Equip.transform.childCount; i++)
        {
            equipSlots[i] = gameObject.transform.GetChild(i).gameObject;
        }
    }
    #endregion

    //=========================================================================================

    #region FindingEffect
    private void MakeEffectArray() 
    {
        effects = new GameObject[(equipSlots.Length) * (equipSlots[0].transform.childCount)];

        for (int j = 0; j < equipSlots.Length; j++)
        {
            for (int i = 0; i < equipSlots[j].transform.childCount; i++)
            {
                effects[(equipSlots[0].transform.childCount * j) + i] = equipSlots[j].transform.GetChild(i).gameObject;
            }
        }
    }
    #endregion

    //=========================================================================================

    #region EffectsOFf
    private void TurnAllEffectsOff() 
    {
        effects[(int)ChildrenOfEquipSlots.SwordEffect1].SetActive(false);
        effects[(int)ChildrenOfEquipSlots.SwordEffect2].SetActive(false);
        effects[(int)ChildrenOfEquipSlots.RingEffect1].SetActive(false);
        effects[(int)ChildrenOfEquipSlots.RingEffect2].SetActive(false);
        effects[(int)ChildrenOfEquipSlots.ShieldEffect1].SetActive(false);
        effects[(int)ChildrenOfEquipSlots.ShieldEffect2].SetActive(false);
        effects[(int)ChildrenOfEquipSlots.ArmorEffect1].SetActive(false);
        effects[(int)ChildrenOfEquipSlots.ArmorEffect2].SetActive(false);
    }
    #endregion

    //=========================================================================================

    #region EffectsOn
    private void TurnSwordEffectsOn() 
    {
        effects[(int)ChildrenOfEquipSlots.SwordEffect1].SetActive(true);
        effects[(int)ChildrenOfEquipSlots.SwordEffect2].SetActive(true);
    }

    //=========================================================================================

    private void TurnRingEffectsOn()
    {
        effects[(int)ChildrenOfEquipSlots.RingEffect1].SetActive(true);
        effects[(int)ChildrenOfEquipSlots.RingEffect2].SetActive(true);
    }

    //=========================================================================================

    private void TurnShieldEffectsOn()
    {
        effects[(int)ChildrenOfEquipSlots.ShieldEffect1].SetActive(true);
        effects[(int)ChildrenOfEquipSlots.ShieldEffect2].SetActive(true);
    }

    //=========================================================================================

    private void TurnArmorEffectsOn()
    {
        effects[(int)ChildrenOfEquipSlots.ArmorEffect1].SetActive(true);
        effects[(int)ChildrenOfEquipSlots.ArmorEffect2].SetActive(true);
    }
    #endregion

    //=========================================================================================

}
