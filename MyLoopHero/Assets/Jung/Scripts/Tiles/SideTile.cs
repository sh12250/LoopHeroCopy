using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideTile : MonoBehaviour
{
    // �Ź̰�ġ ���������� ���� ���ε� �������̼�Ǯ
    private string nameSave;

    private int spawnCycle;
    private int currDay;
    private int currLoop;

    private string monsterName;

    private List<GameObject> targetTiles_spawn;
    private List<GameObject> targetTiles_effect;

    private const int STAT_MANSION = 1;

    private bool isCross;
    private bool isAround;

    private void Start()
    {
        nameSave = name;

        spawnCycle = 1;
        currDay = 0;
        currLoop = 0;
    }

    private void Update()
    {
        // �̸��� �´� �Լ� �ѹ��� ����
        if (nameSave != name)
        {
            nameSave = name;

            switch (nameSave)
            {
                case "LAMP":
                    SetTargetTiles_Around();
                    targetTiles_spawn = null;

                    // 3x3 ���� ���� ���� �� Ÿ���� monsterCnt�� ���� ���
                    Lamp();
                    break;
                case "COCOON":
                    SetTargetTiles_Cross();
                    targetTiles_effect = null;

                    spawnCycle = 1;
                    currDay = GameManager.instance.dayCnt;

                    monsterName = "Spider";
                    break;
                case "MANSION":
                    Mansion();

                    break;
                case "BATTLEFIELD":
                    SetTargetTiles_Cross();
                    targetTiles_effect = null;

                    spawnCycle = 1;
                    currLoop = GameManager.instance.loopCnt;

                    monsterName = "Chest";

                    break;
                case "BLOODYBUSH":
                    SetTargetTiles_Cross();
                    targetTiles_effect = null;

                    spawnCycle = 5;
                    currDay = GameManager.instance.dayCnt;

                    monsterName = "FleshGolem";

                    break;
                default:
                    targetTiles_spawn = null;
                    targetTiles_effect = null;
                    // VoidTile �� ��, �ƹ��͵� ����
                    break;
            }
        }

        // �̸��� �´� �Լ� ��� ���� 
        switch (nameSave)
        {
            case "COCOON":
                // �Ϸ縶�� �Ź̸� ������ �� Ÿ�Ͽ� ��ȯ
                Cocoon();
                break;
            case "BATTLEFIELD":
                // �������� ���� Ȥ�� �̹��� ������ �� Ÿ�Ͽ� ��ȯ
                BattleField();
                break;
            case "BLOODYBUSH":
                // 3x3 ���� ������ �߻��� �������� ü���� 15%������ �� óġ
                // �� óġ �� ������ �������� �� ����
                BloodyBush();
                break;
            default:
                // VoidTile �� ��, �ƹ��͵� ����
                break;
        }
    }

    private void Lamp()
    {
        for (int i = 0; i < targetTiles_effect.Count; i++)
        {
            if (targetTiles_effect[i].GetComponent<RoadTile>() != null)
            {
                targetTiles_effect[i].GetComponent<RoadTile>().lampCnt += 1;
            }
        }
    }

    private void Cocoon()
    {
        GameObject target_ = targetTiles_spawn[Random.Range(0, targetTiles_spawn.Count)];

        RoadTile road_ = target_.GetComponent<RoadTile>();

        if (GameManager.instance.dayCnt == currDay + spawnCycle)
        {
            currDay = GameManager.instance.dayCnt;

            if (road_.monsterCnt + road_.lampCnt < road_.monsterCnt_Max)
            {
                road_.monsterCnt += 1;

                GameObject monster_ = MonsterManager.instance.SpawnMonster(target_.transform);
                monster_.GetComponentInChildren<Animator>().SetTrigger(monsterName);
                road_.SetMonsterPosition(monster_);

                monster_.name = monsterName;
            }
        }
    }

    private void Mansion()
    {
        FindObjectOfType<Knight>().GetComponent<Knight>().heroVamp += STAT_MANSION;
    }

    private void BattleField()
    {
        GameObject target_ = targetTiles_spawn[Random.Range(0, targetTiles_spawn.Count)];

        RoadTile road_ = target_.GetComponent<RoadTile>();

        if (GameManager.instance.loopCnt == currLoop + spawnCycle)
        {
            currLoop = GameManager.instance.loopCnt;

            if (road_.monsterCnt + road_.lampCnt < road_.monsterCnt_Max)
            {
                road_.monsterCnt += 1;

                GameObject monster_ = MonsterManager.instance.SpawnMonster(target_.transform);
                monster_.GetComponentInChildren<Animator>().SetTrigger(monsterName);
                road_.SetMonsterPosition(monster_);

                monster_.name = monsterName;
            }
        }
    }

    private void BloodyBush()
    {
        GameObject target_ = targetTiles_spawn[Random.Range(0, targetTiles_spawn.Count)];

        RoadTile road_ = target_.GetComponent<RoadTile>();

        if (GameManager.instance.loopCnt == currLoop + spawnCycle)
        {
            currLoop = GameManager.instance.loopCnt;

            if (road_.monsterCnt + road_.lampCnt < road_.monsterCnt_Max)
            {
                road_.monsterCnt += 1;

                GameObject monster_ = MonsterManager.instance.SpawnMonster(target_.transform);
                monster_.GetComponentInChildren<Animator>().SetTrigger(monsterName);
                road_.SetMonsterPosition(monster_);

                monster_.name = monsterName;
            }
        }
    }

    private void SetTargetTiles_Around()
    {
        targetTiles_effect = new List<GameObject>();
        TileManager.instance.FindRoadTiles_Around(targetTiles_effect, gameObject);
    }

    private void SetTargetTiles_Cross()
    {
        targetTiles_spawn = new List<GameObject>();
        TileManager.instance.FindRoadTiles_Cross(targetTiles_spawn, gameObject);
    }
}
