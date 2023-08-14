using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadTile : MonoBehaviour
{
    [SerializeField]
    private Sprite slime;

    public int spawnRate;
    public int spawnCycle;
    public int currDay;

    public int monsterCnt;

    private void Start()
    {
        spawnRate = 5;
        spawnCycle = 1;
        currDay = GameManager.instance.dayCnt;

        monsterCnt = 0;
    }

    private void Update()
    {
        if (GameManager.instance.dayCnt == currDay + spawnCycle)
        {
            currDay = GameManager.instance.dayCnt;

            if (Random.Range(0, 100) <= spawnRate && monsterCnt <= 4)
            {
                GameObject slime_ = MonsterManager.instance.SpawnMonster(gameObject.transform);

                monsterCnt += 1;
            }
        }
    }
}
