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
    /// <summary>
    /// ─ 모양
    /// </summary>
    public Sprite roadSprite_H;
    /// <summary>
    /// │ 모양
    /// </summary>
    public Sprite roadSprite_V;
    /// <summary>
    /// ┌ 모양
    /// </summary>
    public Sprite roadSprite_1;
    /// <summary>
    /// ┐ 모양
    /// </summary>
    public Sprite roadSprite_2;
    /// <summary>
    /// └ 모양
    /// </summary>
    public Sprite roadSprite_3;
    /// <summary>
    /// ┘ 모양
    /// </summary>
    public Sprite roadSprite_4;
    // 길 타일 스프라이트

    private static int MAP_LENGTH = 12;
    private static int MAP_WIDTH = 21;
    // 크기는 12 X 21

    void Start()
    {
        CreateMap();
    }

    void Update()
    {

    }

    private void CreateMap()
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
        // 정렬한 타일 대입

        int randIdxY_ = Random.Range(MAP_LENGTH / 3, MAP_LENGTH * 2 / 3);
        int randIdxX_ = Random.Range(MAP_WIDTH / 3, MAP_WIDTH * 2 / 3);
        // 랜덤한 타일 의 인덱스를 구하기 위한 변수 2개

        voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_].GetComponentInChildren<SpriteRenderer>().sprite = campsiteSprite;
        // 지정된 타일의 하위 오브젝트가 가진 SpriteRenderer의 sprite를 campsiteSprite로 바꿔준다
        voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_].transform.tag = "RoadTile";
        // 지정된 타일의 태그를 RoadTile 로 바꿔준다

        List<GameObject> passPoints_ = new List<GameObject>();
        // 길이 지나갈 타일들
        passPoints_.Add(voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_]);
        // 야영지도 포함된다

        while (passPoints_.Count < 3)
        {
            randIdxY_ = Random.Range(3, MAP_LENGTH - 3);
            randIdxX_ = Random.Range(5, MAP_WIDTH - 5);
            // 너무 맵 가장자리에 생기지 않도록 범위 설정

            int loopCnt = 0;
            while (passPoints_.IndexOf(voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_]) >= 0)
            {   // 이미 passPoints 에 속한 타일인지 확인
                if (loopCnt == 100)
                {   // 무한 루프 방지
                    break;
                }

                randIdxY_ = Random.Range(3, MAP_LENGTH - 3);
                randIdxX_ = Random.Range(5, MAP_WIDTH - 5);
                // 다시 랜덤 인덱스 설정

                if (passPoints_.IndexOf(voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_]) == -1)
                {   // 속하지 않을 경우 루프 탈출
                    break;
                }

                loopCnt += 1;
            }

            passPoints_.Add(voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_]);
        }

        LinkPassPoints(passPoints_, passPoints_[0]);
    }

    private void LinkPassPoints(List<GameObject> points_, GameObject startPoint_)
    {
        if (points_.Count == 0) { return; }

        GameObject target_ = new GameObject();

        // 야영지만 남았을 경우를 확인
        if (points_.Count > 1)
        {   // 야영지를 제외한 타일이 남았을 경우
            target_ = points_[1];

            int startY_ = voidTiles.IndexOf(startPoint_) / 21;
            int startX_ = voidTiles.IndexOf(startPoint_) % 21;
            int targetY_ = voidTiles.IndexOf(target_) / 21;
            int targetX_ = voidTiles.IndexOf(target_) % 21;

            // Vector2 distance = startPoint_.transform.localPosition - points_[1].transform.localPosition;
            Vector2 distance = new Vector2(targetX_ - startX_, targetY_ - startY_);
            float minDist = distance.magnitude;

            for (int i = 1; i < points_.Count; i++)
            {   // 타일중 야영지와 가장 가까운 타일 서치
                // distance = startPoint_.transform.localPosition - points_[i].transform.localPosition;
                distance = new Vector2(points_[i].transform.localPosition.x - startX_, points_[i].transform.localPosition.y - startY_);

                if (minDist > distance.magnitude)
                {
                    minDist = distance.magnitude;
                    target_ = points_[i];
                }
            }

            int currY_ = startY_;
            int currX_ = startX_;

            int distY_ = 0;
            int distX_ = 0;

            if (Mathf.Abs(targetX_ - startX_) >= Mathf.Abs(targetY_ - startY_))
            {
                if (startX_ > targetX_)
                {
                    distX_ = startX_ - targetX_;

                    // 일단 반만 이동
                    for (int i = 0; i < distX_ / 2; i++)
                    {
                        currX_ -= 1;
                        if (i != (distX_ / 2) - 1)
                        {
                            CreateRoad(currY_, currX_, 0);
                        }
                    }
                    // 일단 반만 이동

                    // Y좌표 이동
                    if (startY_ > targetY_)
                    {
                        distY_ = startY_ - targetY_;

                        for (int i = 0; i < distY_; i++)
                        {
                            if (i == 0)
                            {
                                CreateRoad(currY_, currX_, 4);
                            }
                            currY_ -= 1;
                            CreateRoad(currY_, currX_, 1);
                        }
                    }
                    if (startY_ < targetY_)
                    {
                        distY_ = targetY_ - startY_;

                        for (int i = 0; i < distY_; i++)
                        {
                            if (i == 0)
                            {
                                CreateRoad(currY_, currX_, 2);
                            }
                            currY_ += 1;
                            CreateRoad(currY_, currX_, 1);
                        }
                    }
                    if (startY_ == targetY_) { /* PASS */ }
                    // Y좌표 이동

                    // 나머지 반 이동
                    for (int i = 0; i < distX_ - (distX_ / 2); i++)
                    {
                        currX_ -= 1;
                        CreateRoad(currY_, currX_, 0);
                    }
                    // 나머지 반 이동
                }

                if (startX_ < targetX_)
                {
                    distX_ = targetX_ - startX_;

                    // 일단 반만 이동
                    for (int i = 0; i < distX_ / 2; i++)
                    {
                        currX_ += 1;
                        if (i != (distX_ / 2) - 1)
                        {
                            CreateRoad(currY_, currX_, 0);
                        }
                    }
                    // 일단 반만 이동

                    // Y좌표 이동
                    if (startY_ > targetY_)
                    {
                        distY_ = startY_ - targetY_;

                        for (int i = 0; i < distY_; i++)
                        {
                            if (i == 0)
                            {
                                CreateRoad(currY_, currX_, 5);
                            }
                            currY_ -= 1;
                            CreateRoad(currY_, currX_, 1);
                        }
                    }
                    if (startY_ < targetY_)
                    {
                        distY_ = targetY_ - startY_;

                        for (int i = 0; i < distY_; i++)
                        {
                            if (i == 0)
                            {
                                CreateRoad(currY_, currX_, 3);
                            }
                            currY_ += 1;
                            CreateRoad(currY_, currX_, 1);
                        }
                    }
                    if (startY_ == targetY_) { /* PASS */ }
                    // Y좌표 이동

                    // 나머지 반 이동
                    for (int i = 0; i < distX_ - (distX_ / 2); i++)
                    {
                        currX_ += 1;
                        CreateRoad(currY_, currX_, 0);
                    }
                    // 나머지 반 이동
                }
            }
            else if (Mathf.Abs(targetX_ - startX_) < Mathf.Abs(targetY_ - startY_))
            {
                if (startY_ > targetY_)
                {
                    distY_ = startY_ - targetY_;

                    // 일단 반만 이동
                    for (int i = 0; i < distY_ / 2; i++)
                    {
                        currY_ -= 1;
                        if (i != (distY_ / 2) - 1)
                        {
                            CreateRoad(currY_, currX_, 1);
                        }
                    }
                    // 일단 반만 이동

                    // X좌표 이동
                    if (startX_ > targetX_)
                    {
                        distX_ = startX_ - targetX_;

                        for (int i = 0; i < distX_; i++)
                        {
                            if (i == 0)
                            {
                                CreateRoad(currY_, currX_, 3);
                            }
                            currX_ -= 1;
                            CreateRoad(currY_, currX_, 0);
                        }
                    }
                    if (startX_ < targetX_)
                    {
                        distX_ = targetX_ - startX_;

                        for (int i = 0; i < distX_; i++)
                        {
                            if (i == 0)
                            {
                                CreateRoad(currY_, currX_, 2);
                            }
                            currX_ += 1;
                            CreateRoad(currY_, currX_, 0);
                        }
                    }
                    if (startX_ == targetX_) { /* PASS */ }
                    // X좌표 이동

                    // 나머지 반 이동
                    for (int i = 0; i < distY_ - (distY_ / 2); i++)
                    {
                        currY_ -= 1;
                        CreateRoad(currY_, currX_, 1);
                    }
                    // 나머지 반 이동
                }

                if (startY_ < targetY_)
                {
                    distY_ = targetY_ - startY_;

                    // 일단 반만 이동
                    for (int i = 0; i < distY_ / 2; i++)
                    {
                        currY_ += 1;
                        if (i != (distY_ / 2) - 1)
                        {
                            CreateRoad(currY_, currX_, 1);
                        }
                    }
                    // 일단 반만 이동

                    // X좌표 이동
                    if (startX_ > targetX_)
                    {
                        distX_ = startX_ - targetX_;

                        for (int i = 0; i < distX_; i++)
                        {
                            if (i == 0)
                            {
                                CreateRoad(currY_, currX_, 5);
                            }
                            currX_ -= 1;
                            CreateRoad(currY_, currX_, 0);
                        }
                    }
                    if (startX_ < targetX_)
                    {
                        distX_ = targetX_ - startX_;

                        for (int i = 0; i < distX_; i++)
                        {
                            if (i == 0)
                            {
                                CreateRoad(currY_, currX_, 4);
                            }
                            currX_ += 1;
                            CreateRoad(currY_, currX_, 0);
                        }
                    }
                    if (startX_ == targetX_) { /* PASS */ }
                    // X좌표 이동

                    // 나머지 반 이동
                    for (int i = 0; i < distY_ - (distY_ / 2); i++)
                    {
                        currY_ += 1;
                        CreateRoad(currY_, currX_, 1);
                    }
                    // 나머지 반 이동
                }
            }

            points_.Remove(target_);
            LinkPassPoints(points_, target_);
        }
        else if (points_.Count == 1)
        {   // 야영지를 제외한 타일이 남지 않았을 경우
            target_ = points_[0];

            int startY_ = voidTiles.IndexOf(startPoint_) / 21;
            int startX_ = voidTiles.IndexOf(startPoint_) % 21;
            int targetY_ = voidTiles.IndexOf(target_) / 21;
            int targetX_ = voidTiles.IndexOf(target_) % 21;

            int currY_ = startY_;
            int currX_ = startX_;

            int distY_ = 0;
            int distX_ = 0;

            if (Mathf.Abs(targetX_ - startX_) >= Mathf.Abs(targetY_ - startY_))
            {
                if (startX_ > targetX_)
                {
                    distX_ = startX_ - targetX_;

                    // 일단 반만 이동
                    for (int i = 0; i < distX_ / 2; i++)
                    {
                        currX_ -= 1;
                        if (i != (distX_ / 2) - 1)
                        {
                            CreateRoad(currY_, currX_, 0);
                        }
                    }
                    // 일단 반만 이동

                    // Y좌표 이동
                    if (startY_ > targetY_)
                    {
                        distY_ = startY_ - targetY_;

                        for (int i = 0; i < distY_; i++)
                        {
                            if (i == 0)
                            {
                                CreateRoad(currY_, currX_, 4);
                            }
                            currY_ -= 1;
                            CreateRoad(currY_, currX_, 1);
                        }
                    }
                    if (startY_ < targetY_)
                    {
                        distY_ = targetY_ - startY_;

                        for (int i = 0; i < distY_; i++)
                        {
                            if (i == 0)
                            {
                                CreateRoad(currY_, currX_, 2);
                            }
                            currY_ += 1;
                            CreateRoad(currY_, currX_, 1);
                        }
                    }
                    if (startY_ == targetY_) { /* PASS */ }
                    // Y좌표 이동

                    // 나머지 반 이동
                    for (int i = 0; i < distX_ - (distX_ / 2); i++)
                    {
                        currX_ -= 1;
                        CreateRoad(currY_, currX_, 0);
                    }
                    // 나머지 반 이동
                }

                if (startX_ < targetX_)
                {
                    distX_ = targetX_ - startX_;

                    // 일단 반만 이동
                    for (int i = 0; i < distX_ / 2; i++)
                    {
                        currX_ += 1;
                        if (i != (distX_ / 2) - 1)
                        {
                            CreateRoad(currY_, currX_, 0);
                        }
                    }
                    // 일단 반만 이동

                    // Y좌표 이동
                    if (startY_ > targetY_)
                    {
                        distY_ = startY_ - targetY_;

                        for (int i = 0; i < distY_; i++)
                        {
                            if (i == 0)
                            {
                                CreateRoad(currY_, currX_, 4);
                            }
                            currY_ -= 1;
                            CreateRoad(currY_, currX_, 1);
                        }
                    }
                    if (startY_ < targetY_)
                    {
                        distY_ = targetY_ - startY_;

                        for (int i = 0; i < distY_; i++)
                        {
                            if (i == 0)
                            {
                                CreateRoad(currY_, currX_, 2);
                            }
                            currY_ += 1;
                            CreateRoad(currY_, currX_, 1);
                        }
                    }
                    if (startY_ == targetY_) { /* PASS */ }
                    // Y좌표 이동

                    // 나머지 반 이동
                    for (int i = 0; i < distX_ - (distX_ / 2); i++)
                    {
                        currX_ += 1;
                        CreateRoad(currY_, currX_, 0);
                    }
                    // 나머지 반 이동
                }
            }
            else if (Mathf.Abs(targetX_ - startX_) < Mathf.Abs(targetY_ - startY_))
            {
                if (startY_ > targetY_)
                {
                    distY_ = startY_ - targetY_;

                    // 일단 반만 이동
                    for (int i = 0; i < distY_ / 2; i++)
                    {
                        currY_ -= 1;
                        if (i != (distY_ / 2) - 1)
                        {
                            CreateRoad(currY_, currX_, 1);
                        }
                    }
                    // 일단 반만 이동

                    // X좌표 이동
                    if (startX_ > targetX_)
                    {
                        distX_ = startX_ - targetX_;

                        for (int i = 0; i < distX_; i++)
                        {
                            if (i == 0)
                            {
                                CreateRoad(currY_, currX_, 3);
                            }
                            currX_ -= 1;
                            CreateRoad(currY_, currX_, 0);
                        }
                    }
                    if (startX_ < targetX_)
                    {
                        distX_ = targetX_ - startX_;

                        for (int i = 0; i < distX_; i++)
                        {
                            if (i == 0)
                            {
                                CreateRoad(currY_, currX_, 2);
                            }
                            currX_ += 1;
                            CreateRoad(currY_, currX_, 0);
                        }
                    }
                    if (startX_ == targetX_) { /* PASS */ }
                    // X좌표 이동

                    // 나머지 반 이동
                    for (int i = 0; i < distY_ - (distY_ / 2); i++)
                    {
                        currY_ -= 1;
                        CreateRoad(currY_, currX_, 1);
                    }
                    // 나머지 반 이동
                }

                if (startY_ < targetY_)
                {
                    distY_ = targetY_ - startY_;

                    // 일단 반만 이동
                    for (int i = 0; i < distY_ / 2; i++)
                    {
                        currY_ += 1;
                        if (i != (distY_ / 2) - 1)
                        {
                            CreateRoad(currY_, currX_, 1);
                        }
                    }
                    // 일단 반만 이동

                    // X좌표 이동
                    if (startX_ > targetX_)
                    {
                        distX_ = startX_ - targetX_;

                        for (int i = 0; i < distX_; i++)
                        {
                            if (i == 0)
                            {
                                CreateRoad(currY_, currX_, 5);
                            }
                            currX_ -= 1;
                            CreateRoad(currY_, currX_, 0);
                        }
                    }
                    if (startX_ < targetX_)
                    {
                        distX_ = targetX_ - startX_;

                        for (int i = 0; i < distX_; i++)
                        {
                            if (i == 0)
                            {
                                CreateRoad(currY_, currX_, 4);
                            }
                            currX_ += 1;
                            CreateRoad(currY_, currX_, 0);
                        }
                    }
                    if (startX_ == targetX_) { /* PASS */ }
                    // X좌표 이동

                    // 나머지 반 이동
                    for (int i = 0; i < distY_ - (distY_ / 2); i++)
                    {
                        currY_ += 1;
                        CreateRoad(currY_, currX_, 1);
                    }
                    // 나머지 반 이동
                }
            }
        }
    }

    private void CreateRoad(int y_, int x_, int spriteIdx)
    {
        Sprite sprite = default;
        switch (spriteIdx)
        {
            case 0:
                sprite = roadSprite_H;
                break;
            case 1:
                sprite = roadSprite_V;
                break;
            case 2:
                sprite = roadSprite_1;
                break;
            case 3:
                sprite = roadSprite_2;
                break;
            case 4:
                sprite = roadSprite_3;
                break;
            case 5:
                sprite = roadSprite_4;
                break;
        }

        if (voidTiles[y_ * MAP_WIDTH + x_].transform.tag != "RoadTile")
        {
            voidTiles[y_ * MAP_WIDTH + x_].GetComponentInChildren<SpriteRenderer>().sprite = sprite;
            // 지정된 타일의 하위 오브젝트가 가진 SpriteRenderer의 sprite를 campsiteSprite로 바꿔준다
            voidTiles[y_ * MAP_WIDTH + x_].transform.tag = "RoadTile";
            // 지정된 타일의 태그를 RoadTile 로 바꿔준다
        }
    }

    private List<GameObject> SortTiles(List<GameObject> tiles_)
    {
        GameObject[] sortedTiles_ = new GameObject[tiles_.Count];
        // 순서대로 넣지 않기 때문에 배열로 선언

        for (int i = 0; i < tiles_.Count; i++)
        {
            float y = Mathf.Abs(tiles_[i].transform.localPosition.y - 5.5f);
            // 5.5f 는 제일 위에 위치한 타일의 y값

            float x = Mathf.Abs(tiles_[i].transform.localPosition.x + 12.5f);
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
