using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipment : MonoBehaviour
{
    public Item equipedItemStat;
    public Knight player;
    [SerializeField]
    private Knight setStat;

    private Sprite spriteSave;

    private void Start()
    {
        spriteSave = gameObject.GetComponent<Image>().sprite;
        setStat = new Knight();
        equipedItemStat = default;
        SetItemStat();
    }

    public void SetItemStat()
    {
        Knight temp_ = new Knight();

        if (equipedItemStat == null)
        {
            return;
        }

        // 规绢备 林可
        temp_.heroHealthMax = equipedItemStat.itemHP;
        temp_.heroHealth = equipedItemStat.itemHP;
        // 公扁 林可
        temp_.heroDamageMin = equipedItemStat.itemMinDamage;
        temp_.heroDamageMax = equipedItemStat.itemMaxDamage;
        // 规菩 林可
        temp_.heroDefense = equipedItemStat.itemDefense;
        // 馆瘤, 何可
        temp_.heroDamageMagic = equipedItemStat.itemMagicDamage;
        temp_.heroDamageAll = equipedItemStat.itemDamageAll;
        temp_.heroAttackSpeed = equipedItemStat.itemAttackSpeed;
        temp_.heroEvade = equipedItemStat.itemEvade;
        temp_.heroCounter = equipedItemStat.itemCounter;
        temp_.heroVamp = equipedItemStat.itemCounter;
        temp_.heroRegen = equipedItemStat.itemCounter;

        setStat = temp_;
    }

    //public void ApplyToPlayer()
    //{
    //    player.AddStat(setStat);
    //}

    //public void UnapplyToPlayer()
    //{
    //    player.RemoveStat(setStat);
    //}
}
