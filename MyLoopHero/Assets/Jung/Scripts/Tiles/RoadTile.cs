using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTile : MonoBehaviour
{
    // 수풀, 늪, 마을, 밀밭, 묘지
    private string nameSave;

    private int spawnRate;
    public int spawnCycle;
    public int currDay;

    private string monsterName;
    public int monsterCnt_Max;
    public int monsterCnt;

    public int lampCnt;

    private List<GameObject> targetTiles;

    private void Start()
    {
        nameSave = name;

        spawnRate = 5;
        Init(1, GameManager.instance.dayCnt, "Slime");
        monsterCnt_Max = 1;
        monsterCnt = 0;

        lampCnt = 0;

        targetTiles = new List<GameObject>();
        targetTiles.Add(gameObject);
    }

    private void Update()
    {
        if (nameSave != name)
        {
            nameSave = name;

            // 이름에 맞는 변수값 대입
            switch (name)
            {
                case "VILLAGE":
                    Init();
                    break;
                case "CORNFIELD":
                    Init(4, GameManager.instance.dayCnt, "Scarecrow");
                    break;
                case "BUSH":
                    Init(2, GameManager.instance.dayCnt, "RedWolf");
                    TileManager.instance.FindRoadTiles_Cross(targetTiles, gameObject);
                    break;
                case "CEMETARY":
                    Init(3, GameManager.instance.dayCnt, "Skeleton");
                    break;
                case "SWAMP":
                    Init(3, GameManager.instance.dayCnt, "Moskito");
                    break;
                default:    // 이름에 Road가 들어간 타일
                    Init(1, GameManager.instance.dayCnt, "Slime");
                    break;
            }
        }

        MakeMonster(monsterName);
    }

    private void MakeMonster(string monsterName_)
    {
        if (GameManager.instance.dayCnt == currDay + spawnCycle)
        {
            currDay = GameManager.instance.dayCnt;

            switch (monsterName)
            {
                case "Slime":
                    if (Random.Range(0, 100) <= spawnRate && monsterCnt + lampCnt < monsterCnt_Max)
                    {
                        monsterCnt += 1;

                        GameObject slime_ = MonsterManager.instance.SpawnMonster(gameObject.transform);
                        SetMonsterPosition(slime_);

                        slime_.name = monsterName_;
                    }
                    break;
                case "RedWolf":
                    GameObject targetTile_ = targetTiles[Random.Range(0, targetTiles.Count)];

                    if (targetTile_.GetComponent<RoadTile>().monsterCnt + targetTile_.GetComponent<RoadTile>().lampCnt < monsterCnt_Max)
                    {
                        targetTile_.GetComponent<RoadTile>().monsterCnt += 1;

                        GameObject monster_ = MonsterManager.instance.SpawnMonster(targetTile_.transform);
                        monster_.GetComponentInChildren<Animator>().SetTrigger(monsterName_);
                        targetTile_.GetComponent<RoadTile>().SetMonsterPosition(monster_);

                        monster_.name = monsterName_;
                    }
                    break;
                default:
                    if (monsterCnt + lampCnt < monsterCnt_Max)
                    {
                        monsterCnt += 1;

                        GameObject monster_ = MonsterManager.instance.SpawnMonster(gameObject.transform);
                        monster_.GetComponentInChildren<Animator>().SetTrigger(monsterName_);
                        SetMonsterPosition(monster_);

                        monster_.name = monsterName_;
                    }
                    break;
            }
        }
    }

    public void SetMonsterPosition(GameObject monster_)
    {
        switch (monsterCnt)
        {
            case 1:
                monster_.transform.localPosition = new Vector3(0.25f, 0.25f, 0);
                break;
            case 2:
                monster_.transform.localPosition = new Vector3(-0.25f, 0.25f, 0);
                break;
            case 3:
                monster_.transform.localPosition = new Vector3(-0.25f, -0.25f, 0);
                break;
            case 4:
                monster_.transform.localPosition = new Vector3(0.25f, -0.25f, 0);
                break;
        }
    }

    private void Init()
    {
        spawnCycle = -1;
        currDay = -1;
    }

    private void Init(int spawnCycle_, int currDay_, string monsterName_)
    {
        spawnCycle = spawnCycle_;
        currDay = currDay_;
        monsterName = monsterName_;
    }

    public int GetMonsterCnt()
    {
        return monsterCnt;
    }
}
