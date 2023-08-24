using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perk : MonoBehaviour
{
    [SerializeField]
    private Knight player;

    public void UpStat()
    {
        switch (name)
        {
            case "HP":
                player.heroHealthMax += 100;
                break;
            case "DEF":
                player.heroDefense += 5;
                break;
            case "DMG":
                player.heroDamageMin += 5;
                player.heroDamageMax += 5;
                break;
            case "DMGM":
                player.heroDamageMagic += 2;
                break;
            case "DMGA":
                player.heroDamageAll += 2;
                break;
            case "SPD":
                player.heroAttackSpeed += 4;
                break;
            case "EVD":
                player.heroEvade += 5;
                break;
            case "CNT":
                player.heroCounter += 5;
                break;
            case "VMP":
                player.heroVamp += 3;
                break;
            case "RGN":
                player.heroRegen += 1;
                break;
            case "RCV":
                player.heroRecovery += 10;
                break;
            default:
                break;
        }

        GetComponentInParent<PerkWindow>().CloseWindow();
    }
}
