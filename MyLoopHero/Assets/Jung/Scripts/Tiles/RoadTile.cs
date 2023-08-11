using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTile : SpawnTile
{
    [SerializeField]
    private Sprite redWolf;

    private void Start()
    {
        spawnRate = 5;
        spawnTime = 1;
        currDay = GameManager.instance.dayCnt;
    }

    private void Update()
    {
        if (GameManager.instance.dayCnt == currDay + spawnTime)
        {
            currDay = GameManager.instance.dayCnt;
            if (Random.Range(0, 100) <= spawnRate)
            {
                 SpawnMonster(transform);
            }
        }
    }

    public override void SpawnMonster(Transform parent_)
    {
        base.SpawnMonster(parent_);

        // 몬스터 능력치 조정(할 예정)
        // 몬스터 능력치 조정(할 예정)
    }
}
