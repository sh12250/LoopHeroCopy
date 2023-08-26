using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideTile : MonoBehaviour
{
    // 거미고치 흡혈귀저택 전장 가로등 피투성이수풀
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
        // 이름에 맞는 함수 한번만 실행
        if (nameSave != name)
        {
            nameSave = name;

            switch (nameSave)
            {
                case "LAMP":
                    SetTargetTiles_Around();
                    targetTiles_spawn = null;

                    // 3x3 범위 내에 속한 길 타일의 monsterCnt의 제한 상승
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
                    // VoidTile 일 때, 아무것도 안함
                    break;
            }
        }

        // 이름에 맞는 함수 계속 실행 
        switch (nameSave)
        {
            case "COCOON":
                // 하루마다 거미를 인접한 길 타일에 소환
                Cocoon();
                break;
            case "BATTLEFIELD":
                // 루프마다 상자 혹은 미믹을 인접한 길 타일에 소환
                BattleField();
                break;
            case "BLOODYBUSH":
                // 3x3 범위 내에서 발생한 전투에서 체력이 15%이하인 적 처치
                // 적 처치 수 누적시 피투성이 골렘 생성
                BloodyBush();
                break;
            default:
                // VoidTile 일 때, 아무것도 안함
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
