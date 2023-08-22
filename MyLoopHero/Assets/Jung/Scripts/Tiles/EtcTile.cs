using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EtcTile : MonoBehaviour
{
    // ���� �� ������ �ݰ� ���
    private string nameSave;

    private int spawnRate;
    private int spawnCycle;
    private int currDay;

    private string monsterName;

    List<GameObject> targetTiles;
    private int targetCnt_Curr;
    private int targetCnt;

    private const int STAT_ROCK = 2;
    private const int STAT_MOUNT = 6;
    private const int STAT_GRASS = 2;
    private const int STAT_BLOOMGRASS = 3;

    private void Start()
    {
        nameSave = "VoidTile";

        spawnRate = default;
        spawnCycle = default;
        currDay = default;

        targetTiles = new List<GameObject>();
        targetCnt_Curr = default;
        targetCnt = default;
    }

    private void Update()
    {
        if (nameSave != name)
        {
            nameSave = name;

            switch (nameSave)
            {
                case "ROCK": // HP 2, ������ ����/�긶�� HP 2++
                    targetCnt_Curr = 0;
                    FindObjectOfType<Knight>().GetComponent<Knight>().heroHealthMax += STAT_ROCK;
                    FindObjectOfType<Knight>().GetComponent<Knight>().heroHealth += STAT_ROCK;

                    break;
                case "MOUNT": // ������ ����/�긶�� HP 6++, 2�ϸ��� ���� ��ȯ
                    targetCnt_Curr = 0;

                    break;
                case "GRASS": // �Ϸ� ȸ�� 2, ������ Ÿ�� ����� �Ϸ� ȸ�� 3
                    targetCnt_Curr = 0;
                    FindObjectOfType<Knight>().GetComponent<Knight>().heroRecovery += STAT_ROCK;

                    break;
                case "SAFE": // 1�ϸ��� 10% Ȯ���� ������ ��ȯ
                    spawnRate = 10;
                    spawnCycle = 1;
                    currDay = GameManager.instance.dayCnt;

                    monsterName = "Gargoyle";

                    break;
                case "LIGHTHOUSE": // 1�ϸ��� 15% Ȯ���� ���� ��ȯ
                    spawnRate = 15;
                    spawnCycle = 1;
                    currDay = GameManager.instance.dayCnt;

                    monsterName = "Harpy";

                    break;
            }
        }

        switch (nameSave)
        {
            case "ROCK":
                Rock();
                break;
            case "MOUNT":
                Mount();
                break;
            case "GRASS":
                Grass();
                break;
            case "SAFE":
                Safe();
                break;
            case "LIGHTHOUSE":
                LightHouse();
                break;
            default:
                // VoidTile�� ��, �ƹ��͵� ����
                break;
        }
    }

    private void Rock()
    {
        CheckRockAndMount();

        if (targetCnt_Curr != targetCnt)
        {
            FindObjectOfType<Knight>().GetComponent<Knight>().heroHealthMax -= targetCnt_Curr * STAT_ROCK;
            FindObjectOfType<Knight>().GetComponent<Knight>().heroHealth -= targetCnt_Curr * STAT_ROCK;
            targetCnt_Curr = targetCnt;
            FindObjectOfType<Knight>().GetComponent<Knight>().heroHealthMax += targetCnt_Curr * STAT_ROCK;
            FindObjectOfType<Knight>().GetComponent<Knight>().heroHealth += targetCnt_Curr * STAT_ROCK;
        }

        targetCnt = 0;
    }

    private void Mount()
    {
        CheckRockAndMount();

        if (targetCnt_Curr != targetCnt)
        {
            FindObjectOfType<Knight>().GetComponent<Knight>().heroHealthMax -= targetCnt_Curr * STAT_MOUNT;
            FindObjectOfType<Knight>().GetComponent<Knight>().heroHealth -= targetCnt_Curr * STAT_MOUNT;
            targetCnt_Curr = targetCnt;
            FindObjectOfType<Knight>().GetComponent<Knight>().heroHealthMax += targetCnt_Curr * STAT_MOUNT;
            FindObjectOfType<Knight>().GetComponent<Knight>().heroHealth += targetCnt_Curr * STAT_MOUNT;
        }

        targetCnt = 0;
    }

    private void Grass()
    {
        CheckTile();

        if (targetCnt != 0)
        {
            if (targetCnt_Curr == 0)
            {
                FindObjectOfType<Knight>().GetComponent<Knight>().heroRecovery -= STAT_GRASS;
                targetCnt_Curr = targetCnt;
                FindObjectOfType<Knight>().GetComponent<Knight>().heroRecovery += STAT_BLOOMGRASS;
            }
            else if (targetCnt_Curr != 0)
            {
                /* DoNothing */
            }
        }
        else if (targetCnt == 0)
        {
            if (targetCnt_Curr == 0)
            {
                /* DoNothing */
            }
            else if (targetCnt_Curr != 0)
            {
                FindObjectOfType<Knight>().GetComponent<Knight>().heroRecovery -= STAT_BLOOMGRASS;
                targetCnt_Curr = targetCnt;
                FindObjectOfType<Knight>().GetComponent<Knight>().heroRecovery += STAT_GRASS;
            }
        }

        targetCnt = 0;
    }

    private void Safe()
    {
        if (GameManager.instance.dayCnt == currDay + spawnCycle)
        {
            currDay = GameManager.instance.dayCnt;

            GetTargetTile();

            int randIdx = Random.Range(0, targetTiles.Count);

            RoadTile road_ = targetTiles[randIdx].GetComponent<RoadTile>();

            if (Random.Range(0, 100) <= spawnRate && road_.monsterCnt + road_.lampCnt < road_.monsterCnt_Max)
            {
                road_.monsterCnt += 1;

                GameObject gargoyle_ = MonsterManager.instance.SpawnMonster(targetTiles[randIdx].transform);
                gargoyle_.GetComponentInChildren<Animator>().SetTrigger(monsterName);
                road_.SetMonsterPosition(gargoyle_);

                gargoyle_.name = monsterName;
            }
        }
    }

    private void LightHouse()
    {
        if (GameManager.instance.dayCnt == currDay + spawnCycle)
        {
            currDay = GameManager.instance.dayCnt;

            GetTargetTile();

            int randIdx = Random.Range(0, targetTiles.Count);

            RoadTile road_ = targetTiles[randIdx].GetComponent<RoadTile>();

            if (Random.Range(0, 100) <= spawnRate && road_.monsterCnt + road_.lampCnt < road_.monsterCnt_Max)
            {
                road_.monsterCnt += 1;

                GameObject harpy_ = MonsterManager.instance.SpawnMonster(targetTiles[randIdx].transform);
                harpy_.GetComponentInChildren<Animator>().SetTrigger(monsterName);
                road_.SetMonsterPosition(harpy_);

                harpy_.name = monsterName;
            }
        }
    }

    private void GetTargetTile()
    {
        List<GameObject> allTiles_ = MapManager.instance.GetVoidTiles();

        for (int i = 0; i < allTiles_.Count; i++)
        {
            if (allTiles_[i].CompareTag("RoadTile") == true && allTiles_[i].name != "CampsiteTile")
            {
                targetTiles.Add(allTiles_[i]);
            }
        }
    }

    private void CheckRockAndMount()
    {
        List<GameObject> allTiles_ = MapManager.instance.GetVoidTiles();
        int idx_ = allTiles_.IndexOf(gameObject);
        int y_ = idx_ / 21;
        int x_ = idx_ % 21;

        if (allTiles_[(y_ - 1) * 21 + x_].name == "ROCK"
            || allTiles_[(y_ - 1) * 21 + x_].name == "MOUNT")
        {
            targetCnt += 1;
        }
        if (allTiles_[(y_ + 1) * 21 + x_].name == "ROCK"
            || allTiles_[(y_ + 1) * 21 + x_].name == "MOUNT")
        {
            targetCnt += 1;
        }
        if (allTiles_[y_ * 21 + x_ - 1].name == "ROCK"
            || allTiles_[y_ * 21 + x_ - 1].name == "MOUNT")
        {
            targetCnt += 1;
        }
        if (allTiles_[y_ * 21 + x_ + 1].name == "ROCK"
            || allTiles_[y_ * 21 + x_ + 1].name == "MOUNT")
        {
            targetCnt += 1;
        }
    }

    private void CheckTile()
    {
        List<GameObject> allTiles_ = MapManager.instance.GetVoidTiles();
        int idx_ = allTiles_.IndexOf(gameObject);
        int y_ = idx_ / 21;
        int x_ = idx_ % 21;

        if (allTiles_[(y_ - 1) * 21 + x_].name != "VoidTile")
        {
            targetCnt += 1;
        }
        if (allTiles_[(y_ + 1) * 21 + x_].name != "VoidTile")
        {
            targetCnt += 1;
        }
        if (allTiles_[y_ * 21 + x_ - 1].name != "VoidTile")
        {
            targetCnt += 1;
        }
        if (allTiles_[y_ * 21 + x_ + 1].name != "VoidTile")
        {
            targetCnt += 1;
        }
    }
}
