using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    protected int spawnCycle;
    protected int currDay;
    protected int monsterCnt;

    protected void Init(int spawnCycle_, int currDay_, int monsterCnt_)
    {
        spawnCycle = spawnCycle_;
        currDay = currDay_;
        monsterCnt = monsterCnt_;
    }

    protected void SetMonsterPosition(GameObject monster_, int monsterCnt_)
    {
        switch (monsterCnt_)
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
}
