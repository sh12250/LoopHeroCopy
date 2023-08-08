using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockTile : Tile
{
    // 체력

    private void Awake()
    {
        // 바위 기본 스탯
    }

    void Start()
    {
        CreateTile();

        // ApplyStat() 실행
    }

    public override void CreateTile()
    {
        base.CreateTile();
        anim.transform.SetParent(transform);
        anim.transform.localPosition = Vector3.zero;

        // CheckCondition() 실행
    }

    private void ApplyStat()
    {
        // 플레이어 스탯에 적용
    }

    private void CheckCondition()
    {
        // 인접한 타일 체크
        // 바위나 산이면 스탯 상승
        // ApplyStat() 실행
    }
}
