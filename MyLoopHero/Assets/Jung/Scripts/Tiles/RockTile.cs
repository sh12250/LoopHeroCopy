using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTile : Tile
{
    // ü��

    private void Awake()
    {
        // ���� �⺻ ����
    }

    void Start()
    {
        CreateTile();

        // ApplyStat() ����
    }

    public override void CreateTile()
    {
        base.CreateTile();
        anim.transform.SetParent(transform);
        anim.transform.localPosition = Vector3.zero;

        // CheckCondition() ����
    }

    private void ApplyStat()
    {
        // �÷��̾� ���ȿ� ����
    }

    private void CheckCondition()
    {
        // ������ Ÿ�� üũ
        // ������ ���̸� ���� ���
        // ApplyStat() ����
    }
}
