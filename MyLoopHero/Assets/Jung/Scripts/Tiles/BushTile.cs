using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BushTile : Monster
{
    private void Start()
    {
        Init(2, GameManager.instance.dayCnt, 0);
    }

    private void Update()
    {
        if (GameManager.instance.dayCnt == currDay + spawnCycle)
        {
            currDay = GameManager.instance.dayCnt;

            if (monsterCnt < 4)
            {
                monsterCnt += 1;

                GameObject redWolf_ = MonsterManager.instance.SpawnMonster(gameObject.transform);
                redWolf_.GetComponentInChildren<Animator>().SetTrigger("RedWolf");
                SetMonsterPosition(redWolf_, monsterCnt);
            }
        }
    }
}
