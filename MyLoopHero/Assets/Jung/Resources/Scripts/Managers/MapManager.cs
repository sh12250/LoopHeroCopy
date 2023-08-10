using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Tilemaps;
using static UnityEngine.GraphicsBuffer;

public class MapManager : MonoBehaviour
{
    public static MapManager instance;

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

    public GameObject playerInMap;

    public List<GameObject> passPoints;
    public GameObject richPrefab;

    private static int MAP_LENGTH = 12;
    private static int MAP_WIDTH = 21;
    // 크기는 12 X 21

    private void Awake()
    {
        if (instance == null || instance == default)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("MapManager가 너무 많습니다");
        }
    }

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

        passPoints = new List<GameObject>();
        // 길이 지나갈 타일들

        while (passPoints.Count < 8)
        {
            int randIdxY_ = Random.Range(2, 4);
            int randIdxX_ = Random.Range(4, 8);

            voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_].GetComponentInChildren<SpriteRenderer>().sprite = campsiteSprite;
            // 지정된 타일의 하위 오브젝트가 가진 SpriteRenderer의 sprite를 campsiteSprite로 바꿔준다
            voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_].transform.tag = "RoadTile";
            // 지정된 타일의 태그를 RoadTile 로 바꿔준다
            GameObject obj = Instantiate(richPrefab, voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_].transform.position, Quaternion.identity, voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_].transform);
            obj.GetComponent<RectTransform>().localPosition = new Vector3(0, -0.5f, 0);

            passPoints.Add(voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_]);
            // 지나갈 타일에 추가

            randIdxY_ = Random.Range(2, 4);
            randIdxX_ = Random.Range(9, 12);

            passPoints.Add(voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_]);
            // 지나갈 타일에 추가

            randIdxY_ = Random.Range(2, 4);
            randIdxX_ = Random.Range(13, 17);

            passPoints.Add(voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_]);
            // 지나갈 타일에 추가

            randIdxY_ = Random.Range(5, 6);
            randIdxX_ = Random.Range(13, 17);

            passPoints.Add(voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_]);
            // 지나갈 타일에 추가

            randIdxY_ = Random.Range(7, 9);
            randIdxX_ = Random.Range(13, 17);

            passPoints.Add(voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_]);
            // 지나갈 타일에 추가

            randIdxY_ = Random.Range(7, 9);
            randIdxX_ = Random.Range(9, 12);

            passPoints.Add(voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_]);
            // 지나갈 타일에 추가

            randIdxY_ = Random.Range(7, 9);
            randIdxX_ = Random.Range(4, 8);

            passPoints.Add(voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_]);
            // 지나갈 타일에 추가

            randIdxY_ = Random.Range(5, 6);
            randIdxX_ = Random.Range(4, 8);

            passPoints.Add(voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_]);
            // 지나갈 타일에 추가
        }

        LinkPassPoints(passPoints, passPoints[0]);

        playerInMap.transform.localPosition = passPoints[0].transform.localPosition;
        playerInMap.GetComponent<PlayerInMap>().enabled = true;
    }

    private void MakePassPoints(List<GameObject> points_)
    {
        List<GameObject> temp_ = new List<GameObject>();

        for (int i = 0; i < points_.Count; i++)
        {
            temp_.Add(points_[i]);
        }
    }

    // 수평길
    private void MakeHorizontalRoad(int fromX_, int toX_, int posY_)
    {
        if (fromX_ > toX_)
        {
            for (int i = fromX_ - 1; i > toX_; i--)
            {
                CreateRoad(posY_, i, 0);
            }
        }
        else if (fromX_ < toX_)
        {
            for (int i = fromX_ + 1; i < toX_; i++)
            {
                CreateRoad(posY_, i, 0);
            }
        }
    }

    // 수직길
    private void MakeVerticalRoad(int fromY_, int toY_, int posX_)
    {
        if (fromY_ > toY_)
        {
            for (int i = fromY_ - 1; i > toY_; i--)
            {
                CreateRoad(i, posX_, 1);
            }
        }
        else if (fromY_ < toY_)
        {
            for (int i = fromY_ + 1; i < toY_; i++)
            {
                CreateRoad(i, posX_, 1);
            }
        }

    }

    // 꺽인길
    private void MakeCurvedRoadUpRight(int fromY_, int toY_, int fromX_, int toX_)
    {
        for (int i = fromY_ - 1; i > toY_; i--)
        {
            CreateRoad(i, fromX_, 1);
        }

        CreateRoad(toY_, fromX_, 2);

        fromX_ += 1;

        for (int i = fromX_; i < toX_; i++)
        {
            CreateRoad(toY_, i, 0);
        }
    }

    private void MakeCurvedRoadUpLeft(int fromY_, int toY_, int fromX_, int toX_)
    {
        for (int i = fromY_ - 1; i > toY_; i--)
        {
            CreateRoad(i, fromX_, 1);
        }

        CreateRoad(toY_, fromX_, 3);

        fromX_ -= 1;

        for (int i = fromX_; i > toX_; i--)
        {
            CreateRoad(toY_, i, 0);
        }
    }

    private void MakeCurvedRoadDownRight(int fromY_, int toY_, int fromX_, int toX_)
    {
        for (int i = fromY_ + 1; i < toY_; i++)
        {
            CreateRoad(i, fromX_, 1);
        }

        CreateRoad(toY_, fromX_, 4);

        fromX_ += 1;

        for (int i = fromX_; i < toX_; i++)
        {
            CreateRoad(toY_, i, 0);
        }
    }

    private void MakeCurvedRoadDownLeft(int fromY_, int toY_, int fromX_, int toX_)
    {
        for (int i = fromY_ + 1; i < toY_; i++)
        {
            CreateRoad(i, fromX_, 1);
        }

        CreateRoad(toY_, fromX_, 5);

        fromX_ -= 1;

        for (int i = fromX_; i > toX_; i--)
        {
            CreateRoad(toY_, i, 0);
        }
    }
    //꺽인길

    private void LinkPassPoints(List<GameObject> points_, GameObject startPoint_)
    {
        GameObject target_ = default;

        int startY_ = voidTiles.IndexOf(startPoint_) / MAP_WIDTH;
        int startX_ = voidTiles.IndexOf(startPoint_) % MAP_WIDTH;

        if (points_.IndexOf(startPoint_) != points_.Count - 1)
        {
            target_ = points_[points_.IndexOf(startPoint_) + 1];

            int targetY_ = voidTiles.IndexOf(target_) / MAP_WIDTH;
            int targetX_ = voidTiles.IndexOf(target_) % MAP_WIDTH;

            if (startY_ == targetY_)
            {
                MakeHorizontalRoad(startX_, targetX_, startY_);
            }

            if (startX_ == targetX_)
            {
                MakeVerticalRoad(startY_, targetY_, startX_);
            }

            if (startY_ > targetY_ && startX_ < targetX_)
            {
                MakeCurvedRoadUpRight(startY_, targetY_, startX_, targetX_);
            }

            if (startY_ > targetY_ && startX_ > targetX_)
            {
                MakeCurvedRoadUpLeft(startY_, targetY_, startX_, targetX_);
            }

            if (startY_ < targetY_ && startX_ < targetX_)
            {
                MakeCurvedRoadDownRight(startY_, targetY_, startX_, targetX_);
            }

            if (startY_ < targetY_ && startX_ > targetX_)
            {
                MakeCurvedRoadDownLeft(startY_, targetY_, startX_, targetX_);
            }

            LinkPassPoints(points_, target_);
        }
        else if (points_.IndexOf(startPoint_) == points_.Count - 1)
        {
            target_ = points_[0];

            int targetY_ = voidTiles.IndexOf(target_) / MAP_WIDTH;
            int targetX_ = voidTiles.IndexOf(target_) % MAP_WIDTH;

            if (startY_ == targetY_)
            {
                MakeHorizontalRoad(startX_, targetX_, startY_);
            }
            if (startX_ == targetX_)
            {
                MakeVerticalRoad(startY_, targetY_, startX_);
            }
            if (startY_ > targetY_ && startX_ < targetX_)
            {
                MakeCurvedRoadUpRight(startY_, targetY_, startX_, targetX_);
            }
            if (startY_ > targetY_ && startX_ > targetX_)
            {
                MakeCurvedRoadUpLeft(startY_, targetY_, startX_, targetX_);
            }
            if (startY_ < targetY_ && startX_ < targetX_)
            {
                MakeCurvedRoadDownRight(startY_, targetY_, startX_, targetX_);
            }
            if (startY_ < targetY_ && startX_ > targetX_)
            {
                MakeCurvedRoadDownLeft(startY_, targetY_, startX_, targetX_);
            }

            return;
        }
    }

    /// <summary>
    /// voidTiles에서 [y, x] 위치의 타일 스프라이트를 spriteIdx에 맞춰 바꿔준다
    /// </summary>
    /// <param name="y_">타일의 행 위치</param>
    /// <param name="x_">타일의 열 위치</param>
    /// <param name="spriteIdx">타일 스프라이트 인덱스 (0: ─, 1: │, 2: ┌, 3: ┐, 4: └, 5: ┘)</param>
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
