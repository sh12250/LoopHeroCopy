using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTile : MonoBehaviour
{
    [SerializeField]
    protected GameObject monsterPrefab;
    // ������, ���� ������Ʈ�� ��������Ʈ �ٲ㼭 ���
    protected float spawnRate;
    // ���� Ȯ��
    protected float spawnTime;
    // ���� ����
    protected float currDay;
    // ���� ��¥

    protected virtual void Awake()
    {

    }

    public virtual void SpawnMonster(Transform parent_)
    {
        Debug.LogFormat("���� �������� ��� �ִ���? {0}", monsterPrefab.name);
        Instantiate(monsterPrefab, parent_);
    }
}
