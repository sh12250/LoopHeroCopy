using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BushTile : MonoBehaviour
{
    [SerializeField]
    private Sprite redWolf;

    public int spawnCycle;
    public int currDay;

    public int monsterCnt;

    private void Start()
    {
        spawnCycle = 2;
        currDay = GameManager.instance.dayCnt;

        monsterCnt = 0;
    }

    private void Update()
    {
        if (GameManager.instance.dayCnt == currDay + spawnCycle)
        {
            currDay = GameManager.instance.dayCnt;

            if (monsterCnt <= 4)
            {
                GameObject redWolf_ = MonsterManager.instance.SpawnMonster(gameObject.transform);
                redWolf_.GetComponentInChildren<Animator>().SetTrigger("RedWolf");

                monsterCnt += 1;
            }
        }
    }
}
