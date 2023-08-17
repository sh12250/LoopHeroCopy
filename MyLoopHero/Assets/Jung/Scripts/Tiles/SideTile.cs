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

    private bool isCross;
    private bool isAround;

    // 피투성이수풀용
    private int devourCnt;

    private void Start()
    {
        nameSave = name;

        spawnCycle = 1;
        currDay = 0;
        currLoop = 0;

        devourCnt = 0;
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
                    currDay = GameManager.instance.dayCnt;

                    monsterName = "Spider";
                    break;
                case "MANSION":
                    SetTargetTiles_Around();
                    targetTiles_spawn = null;
                    break;
                case "BATTLEFIELD":
                    SetTargetTiles_Around();
                    SetTargetTiles_Cross();

                    monsterName = "Chest";

                    BattleField_Effect();
                    break;
                case "BLOODYBUSH":
                    SetTargetTiles_Around();
                    SetTargetTiles_Cross();

                    monsterName = "FleshGolem";

                    BloodyBush_Effect();
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
            case "MANSION":
                // 3x3 범위 내에서 전투 발생시 전투에 흡혈귀 참여
                Mansion();
                break;
            case "BATTLEFIELD":
                // 루프마다 상자 혹은 미믹을 인접한 길 타일에 소환
                BattleField_Spawn();
                break;
            case "BLOODYBUSH":
                // 3x3 범위 내에서 발생한 전투에서 체력이 15%이하인 적 처치
                // 적 처치 수 누적시 피투성이 골렘 생성
                BloodyBush_Spawn();
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
            targetTiles_effect[i].GetComponent<RoadTile>().lampCnt += 1;

            if(targetTiles_effect == null)
            {
                Debug.Log("이건가");
            }

            if (targetTiles_effect[i].GetComponent<RoadTile>() == null)
            {
                Debug.Log("이거네");
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
            }
        }
    }

    private void Mansion()
    {
        // 전투 매니져한테 정보 전달
        // 전투 버프, 가한 데미지의 10%만큼 체력 회복
        // 흡혈귀 전투 참여
    }

    private void BattleField_Effect()
    {
        // 전투 매니져한테 정보 전달
        // 전투 버프, 적이 죽으면 20% 확률로 유령 발생
    }

    private void BattleField_Spawn()
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
            }
        }
    }

    private void BloodyBush_Effect()
    {
        // 전투 매니저한테 정보 전달
        // 전투 버프, 15% 이하 적 즉사
    }

    private void BloodyBush_Spawn()
    {
        GameObject target_ = targetTiles_spawn[Random.Range(0, targetTiles_spawn.Count)];

        RoadTile road_ = target_.GetComponent<RoadTile>();

        if (devourCnt >= 6)
        {
            devourCnt = 0;

            if (road_.monsterCnt + road_.lampCnt < road_.monsterCnt_Max)
            {
                road_.monsterCnt += 1;

                GameObject monster_ = MonsterManager.instance.SpawnMonster(target_.transform);
                monster_.GetComponentInChildren<Animator>().SetTrigger(monsterName);
                road_.SetMonsterPosition(monster_);
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
