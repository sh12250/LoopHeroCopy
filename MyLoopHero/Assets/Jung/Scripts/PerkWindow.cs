using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PerkWindow : MonoBehaviour
{
    public GameObject[] perks;
    /// <summary>
    /// 0: 체력, 1: 방어, 2: 피해, 3: 순수피해, 4: 전체피해, 5: 공격속도, 6: 회피, 7: 반격, 8: 흡혈, 9: 체젠, 10: 휴식
    /// </summary>
    [SerializeField]
    private Sprite[] perkImgs;

    /// <summary>
    /// 0: 체력, 1: 방어, 2: 피해, 3: 순수피해, 4: 전체피해, 5: 공격속도, 6: 회피, 7: 반격, 8: 흡혈, 9: 체젠, 10: 휴식
    /// </summary>
    [SerializeField]
    private Sprite[] perkImgs_br;

    public int perkCnt;

    private void Awake()
    {
        perkCnt = 0;

        transform.localScale = Vector3.zero;
    }

    public void OpenWindow()
    {
        if (perkCnt > 0)
        {
            SetPerks();
            transform.localScale = Vector3.one;

            MapTime.MapTimeScale(0);
        }
    }

    public void CloseWindow()
    {
        transform.localScale = Vector3.zero;
        perkCnt -= 1;

        MapTime.MapTimeScale(1);
    }

    public void SetPerks()
    {
        int randIdx_0 = Random.Range(0, perkImgs.Length);
        int randIdx_1 = Random.Range(0, perkImgs.Length);
        int randIdx_2 = Random.Range(0, perkImgs.Length);

        if (randIdx_1 == randIdx_0)
        {
            randIdx_1 += 1;

            if (randIdx_1 >= perkImgs.Length)
            {
                randIdx_1 -= perkImgs.Length;
            }
        }

        if (randIdx_2 == randIdx_0)
        {
            randIdx_2 += 2;

            if (randIdx_2 >= perkImgs.Length)
            {
                randIdx_2 -= perkImgs.Length;
            }
        }
        else if (randIdx_2 == randIdx_1)
        {
            randIdx_2 += 1;

            if (randIdx_2 >= perkImgs.Length)
            {
                randIdx_2 -= perkImgs.Length;
            }
        }

        perks[0].GetComponentsInChildren<Image>()[1].sprite = perkImgs[randIdx_0];
        perks[0].name = ReturnStatName(randIdx_0);

        perks[1].GetComponentsInChildren<Image>()[1].sprite = perkImgs[randIdx_1];
        perks[1].name = ReturnStatName(randIdx_1);

        perks[2].GetComponentsInChildren<Image>()[1].sprite = perkImgs[randIdx_2];
        perks[2].name = ReturnStatName(randIdx_2);

        perks[0].GetComponentInChildren<TMP_Text>().text = string.Copy(ReturnDescription(randIdx_0));

        perks[1].GetComponentInChildren<TMP_Text>().text = string.Copy(ReturnDescription(randIdx_1));

        perks[2].GetComponentInChildren<TMP_Text>().text = string.Copy(ReturnDescription(randIdx_2));
    }

    private string ReturnDescription(int idx_)
    {
        switch (idx_)
        {
            case 0:
                return string.Format("HealthMax {0} Up", 100);
            case 1:
                return string.Format("Defense {0} Up", 5);
            case 2:
                return string.Format("Damage {0} Up", 5);
            case 3:
                return string.Format("DamageMagic {0} Up", 2);
            case 4:
                return string.Format("DamageAll {0} Up", 2);
            case 5:
                return string.Format("Speed {0} Up", 4);
            case 6:
                return string.Format("Evade {0} Up", 5);
            case 7:
                return string.Format("Counter {0} Up", 5);
            case 8:
                return string.Format("Vamp {0} Up", 3);
            case 9:
                return string.Format("Regen {0} Up", 1);
            case 10:
                return string.Format("Recovery {0} Up", 10);
            default:
                return default;
        }
    }

    private string ReturnStatName(int idx_)
    {
        switch (idx_)
        {
            case 0:
                return "HP";
            case 1:
                return "DEF";
            case 2:
                return "DMG";
            case 3:
                return "DMGM";
            case 4:
                return "DMGA";
            case 5:
                return "SPD";
            case 6:
                return "EVD";
            case 7:
                return "CNT";
            case 8:
                return "VMP";
            case 9:
                return "RGN";
            case 10:
                return "RCV";
            default:
                return default;
        }
    }
}
