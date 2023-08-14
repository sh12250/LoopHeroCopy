using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornfieldTile : Monster
{
    private void Start()
    {
        Init(4, GameManager.instance.dayCnt, 0);
    }

    private void Update()
    {
        if (GameManager.instance.dayCnt == currDay + spawnCycle)
        {
            currDay = GameManager.instance.dayCnt;

            if (monsterCnt < 4)
            {
                monsterCnt += 1;

                GameObject scarecrow_ = MonsterManager.instance.SpawnMonster(gameObject.transform);
                scarecrow_.GetComponentInChildren<Animator>().SetTrigger("Scarecrow");
                SetMonsterPosition(scarecrow_, monsterCnt);
            }
        }
    }
}
