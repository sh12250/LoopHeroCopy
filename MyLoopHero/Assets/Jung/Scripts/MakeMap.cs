using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMap : MonoBehaviour
{
    [SerializeField]
    private GameObject tileMap;
    // 타일맵, 하위로 타일을 생성시키 위해 받아온다
    [SerializeField]
    private GameObject[] voidTiles;
    // 타일맵의 기본 타일들
    public Sprite campfireSprite;
    // 야영지 타일, 시작 타일 스프라이트
    public Sprite roadSprite;
    // 길 타일 스프라이트, 야영지에서 시작해서 야영지로 이어진다

    private static int MAP_LENGTH = 12;
    private static int MAP_WIDTH = 21;
    // 크기는 12 X 21

    void Start()
    {
        _SortTiles(voidTiles);
        // 타일 정렬

        int campsiteY_ = Random.Range(MAP_LENGTH / 3, MAP_LENGTH * 2 / 3);
        int campsiteX_ = Random.Range(MAP_WIDTH / 3, MAP_WIDTH * 2 / 3);
        // 타일맵 중앙 쯤의 랜덤 좌표


        // 랜덤 좌표의 기본 타일 위치에 야영지 생성

        // 야영지와 겹치는 기본 타일 꺼주기
    }

    void Update()
    {

    }

    // TODO 무한루프 해결
    private void _SortTiles(GameObject[] tiles_)
    {
        float y = 0;
        float x = 0;

        for (int i = 0; i < tiles_.Length;)
        {
            y = Mathf.Abs(tiles_[i].transform.position.y - 5.5f);
            // 5.5f 는 제일 위에 위치한 타일의 y값

            x = Mathf.Abs(tiles_[i].transform.position.x + 12.5f);
            // -(-12.5f) 는 제일 왼쪽에 위치한 타일의 x값

            GameObject tileTemp_ = tiles_[i];
            tiles_[i] = tiles_[Mathf.RoundToInt(y * 21f + x)];
            tiles_[Mathf.RoundToInt(y * 21f + x)] = tileTemp_;
            // 스왑

            y = Mathf.Abs(tiles_[i].transform.position.y - 5.5f);
            // 5.5f 는 제일 위에 위치한 타일의 y값

            x = Mathf.Abs(tiles_[i].transform.position.x + 12.5f);
            // -(-12.5f) 는 제일 왼쪽에 위치한 타일의 x값

            //if (Mathf.RoundToInt(y * 21f + x) != i)
            //{
            //    Debug.Log("걸러지나?");
            //    // 스왑한 타일의 좌표가 새로운 좌표에 맞지 않을 경우
            //    continue;
            //    // 다시 루프
            //}

            // 스왑한 타일의 좌표가 새로운 좌표에 맞을 경우
            i += 1;
            // 다음 타일의 좌표를 본다
        }
    }
}
