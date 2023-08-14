using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CemetaryTile : Monster
{
    private void Start()
    {
        Init(3, GameManager.instance.dayCnt, 0);
    }

    private void Update()
    {
        if (GameManager.instance.dayCnt == currDay + spawnCycle)
        {
            currDay = GameManager.instance.dayCnt;

            if (monsterCnt < 4)
            {
                monsterCnt += 1;

                GameObject skeleton_ = MonsterManager.instance.SpawnMonster(gameObject.transform);
                skeleton_.GetComponentInChildren<Animator>().SetTrigger("Skeleton");
                SetMonsterPosition(skeleton_, monsterCnt);
            }
        }
    }
}
