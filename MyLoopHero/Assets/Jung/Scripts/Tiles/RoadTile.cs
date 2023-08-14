using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTile : Monster
{
    public int spawnRate;

    private void Start()
    {
        spawnRate = 5;
        Init(1, GameManager.instance.dayCnt, 0);
    }

    private void Update()
    {
        if (GameManager.instance.dayCnt == currDay + spawnCycle)
        {
            currDay = GameManager.instance.dayCnt;

            if (Random.Range(0, 100) <= spawnRate && monsterCnt < 4)
            {
                monsterCnt += 1;

                GameObject slime_ = MonsterManager.instance.SpawnMonster(gameObject.transform);
                SetMonsterPosition(slime_, monsterCnt);
            }
        }
    }
}
