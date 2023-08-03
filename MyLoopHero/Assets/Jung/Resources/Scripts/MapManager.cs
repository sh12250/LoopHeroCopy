using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap tileMap;
    // 타일맵, 하위로 타일을 생성시키 위해 받아온다
    [SerializeField]
    private List<GameObject> voidTiles;
    // 타일맵의 기본 타일들
    public Sprite campsiteSprite;
    // 야영지 타일, 시작 타일 스프라이트
    public Sprite roadSprite;
    // 길 타일 스프라이트, 야영지에서 시작해서 야영지로 이어진다

    private static int MAP_LENGTH = 12;
    private static int MAP_WIDTH = 21;
    // 크기는 12 X 21

    void Start()
    {
        voidTiles = new List<GameObject>();

        for (int i = 0; i < tileMap.gameObject.transform.childCount; i++)
        {
            GameObject obj = tileMap.gameObject.transform.GetChild(i).gameObject;
            // tileMap의 하위 오브젝트 Hierarchy상의 순서대로 찾기
            voidTiles.Add(obj);
            // 찾아온 하위 오브젝트 add
        }

        voidTiles = SortTiles(voidTiles);
        // 타일 정렬

        int campsiteY_ = Random.Range(MAP_LENGTH / 3, MAP_LENGTH * 2 / 3);
        int campsiteX_ = Random.Range(MAP_WIDTH / 3, MAP_WIDTH * 2 / 3);
        // 타일맵 중앙 쯤의 무작위 값

        GameObject campsiteTile_ = voidTiles[campsiteY_ * 21 + campsiteX_].GetComponentInChildren<SpriteRenderer>().gameObject;
        // 타일의 하위 오브젝트를 찾는다

        campsiteTile_.GetComponent<SpriteRenderer>().sprite = campsiteSprite;
        // 하위 오브젝트의 Sprite를 CampsiteSprite로 바꿔준다


    }

    void Update()
    {

    }

    private List<GameObject> SortTiles(List<GameObject> tiles_)
    {
        float y = 0f;
        float x = 0f;

        GameObject[] sortedTiles_ = new GameObject[tiles_.Count];
        // 순서대로 넣지 않기 때문에 배열로 선언

        for (int i = 0; i < tiles_.Count; i++)
        {
            y = Mathf.Abs(tiles_[i].transform.localPosition.y - 5.5f);
            // 5.5f 는 제일 위에 위치한 타일의 y값

            x = Mathf.Abs(tiles_[i].transform.localPosition.x + 12.5f);
            // -(-12.5f) 는 제일 왼쪽에 위치한 타일의 x값

            GameObject obj = tiles_[i];
            sortedTiles_[Mathf.RoundToInt(y * 21f + x)] = obj;
            // y와 x를 이용해 transform.localPosition상 좌상단부터 오른쪽으로 2차원 배열처럼 정렬
        }

        List<GameObject> temp_ = new List<GameObject>();
        // 반환해줄 임시 List 선언

        for (int i = 0; i < sortedTiles_.Length; i++)
        {
            GameObject obj = sortedTiles_[i];
            temp_.Add(obj);
            // sortedTiles_를 순서대로 add
        }

        return temp_;
        // 임시 List 반환
    }       // SortTiles(List<GameObject> tiles_)
}
