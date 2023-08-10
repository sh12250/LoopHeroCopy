using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public RaycastHit2D hit;
    // 여러스크립트에 뿌려줄 예정

    private void Awake()
    {
        if (instance == null || instance == default)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("GameManager가 너무 많습니다");
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }

    public RaycastHit2D GetHit(string layerMaskName_)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // 마우스 위치를 화면 좌표에서 월드 좌표로 변환
        Vector2 origin = new Vector2(mousePos.x, mousePos.y);
        // 레이캐스트 시작점
        Vector2 direction = Vector2.zero;
        // 레이캐스트 방향
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, Mathf.Infinity, LayerMask.GetMask(layerMaskName_));
        // 레이캐스트 실행

        return hit;
    }
}
