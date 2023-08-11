using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTile : MonoBehaviour
{
    [SerializeField]
    protected GameObject monsterPrefab;
    // 프리팹, 하위 오브젝트의 스프라이트 바꿔서 사용
    protected float spawnRate;
    // 생성 확률
    protected float spawnTime;
    // 생성 간격
    protected float currDay;
    // 현재 날짜

    protected virtual void Awake()
    {

    }

    public virtual void SpawnMonster(Transform parent_)
    {
        Debug.LogFormat("몬스터 프리팹을 들고 있는지? {0}", monsterPrefab.name);
        Instantiate(monsterPrefab, parent_);
    }
}
