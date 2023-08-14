using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwampTile : Monster
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

                GameObject moskito_ = MonsterManager.instance.SpawnMonster(gameObject.transform);
                moskito_.GetComponentInChildren<Animator>().SetTrigger("Moskito");
                SetMonsterPosition(moskito_, monsterCnt);
            }
        }
    }
}
