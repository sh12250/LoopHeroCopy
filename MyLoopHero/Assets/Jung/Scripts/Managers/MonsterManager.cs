using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    public static MonsterManager instance;

    [SerializeField]
    private GameObject monsterPrefab;

    private void Awake()
    {
        if (instance == null || instance == default)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("MonsterManager가 너무 많습니다");
        }
    }

    public GameObject SpawnMonster(Transform parent_)
    {
        GameObject monster_ = Instantiate(monsterPrefab, parent_);
        monster_.transform.localPosition = Vector3.zero;
        return monster_;
    }
}
