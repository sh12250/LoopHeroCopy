using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTile : MonoBehaviour
{
    // 수풀, 늪, 마을, 밀밭, 묘지
    private string nameSave;

    private int spawnRate;
    private int spawnCycle;
    private int currDay;

    private string monsterName;
    private int monsterCnt;

    private void Start()
    {
        nameSave = name;

        spawnRate = 5;
        Init(1, GameManager.instance.dayCnt, "Slime");
        monsterCnt = 0;
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
                    break;
                case "CEMETARY":
                    Init(3, GameManager.instance.dayCnt, "Skeleton");
                    break;
                case "SWAMP":
                    Init(3, GameManager.instance.dayCnt, "Moskito");
                    break;
                default:
                    Init(1, GameManager.instance.dayCnt, "Slime");
                    break;
            }
        }

        MakeMonster(monsterName);
    }

    public void MakeMonster(string monsterName_)
    {
        if (GameManager.instance.dayCnt == currDay + spawnCycle)
        {
            currDay = GameManager.instance.dayCnt;

            switch (monsterName)
            {
                case "Slime":
                    if (Random.Range(0, 100) <= spawnRate && monsterCnt < 4)
                    {
                        monsterCnt += 1;

                        GameObject slime_ = MonsterManager.instance.SpawnMonster(gameObject.transform);
                        SetMonsterPosition(slime_);
                    }
                    break;
                default:
                    if (monsterCnt < 4)
                    {
                        monsterCnt += 1;

                        GameObject monster_ = MonsterManager.instance.SpawnMonster(gameObject.transform);
                        monster_.GetComponentInChildren<Animator>().SetTrigger(monsterName_);
                        SetMonsterPosition(monster_);
                    }
                    break;
            }
        }
    }

    private void SetMonsterPosition(GameObject monster_)
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
