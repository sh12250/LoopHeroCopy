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
    // Ÿ�ϸ�, ������ Ÿ���� ������Ű ���� �޾ƿ´�
    [SerializeField]
    private List<GameObject> voidTiles;
    // Ÿ�ϸ��� �⺻ Ÿ�ϵ�
    public Sprite campsiteSprite;
    // �߿��� Ÿ��, ���� Ÿ�� ��������Ʈ
    /// <summary>
    /// �� ���
    /// </summary>
    public Sprite roadSprite_H;
    /// <summary>
    /// �� ���
    /// </summary>
    public Sprite roadSprite_V;
    /// <summary>
    /// �� ���
    /// </summary>
    public Sprite roadSprite_1;
    /// <summary>
    /// �� ���
    /// </summary>
    public Sprite roadSprite_2;
    /// <summary>
    /// �� ���
    /// </summary>
    public Sprite roadSprite_3;
    /// <summary>
    /// �� ���
    /// </summary>
    public Sprite roadSprite_4;
    // �� Ÿ�� ��������Ʈ

    public GameObject playerInMap;

    public List<GameObject> passPoints;
    public GameObject richPrefab;

    private static int MAP_LENGTH = 12;
    private static int MAP_WIDTH = 21;
    // ũ��� 12 X 21

    private void Awake()
    {
        if (instance == null || instance == default)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("MapManager�� �ʹ� �����ϴ�");
        }
    }

    void Start()
    {
        CreateMap();
    }

    private void CreateMap()
    {
        voidTiles = new List<GameObject>();

        for (int i = 0; i < tileMap.gameObject.transform.childCount; i++)
        {
            if (tileMap.gameObject.transform.GetChild(i).name == "VoidTile")
            {
                GameObject tile = tileMap.gameObject.transform.GetChild(i).gameObject;
                // tileMap�� ���� ������Ʈ Hierarchy���� ������� ã��
                voidTiles.Add(tile);
                // ã�ƿ� ���� ������Ʈ add
            }
        }

        voidTiles = SortTiles(voidTiles);
        // ������ Ÿ�� ����

        passPoints = new List<GameObject>();
        // ���� ������ Ÿ�ϵ�

        int randIdxY_ = Random.Range(3, 4);
        int randIdxX_ = Random.Range(5, 8);

        voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_].GetComponentInChildren<SpriteRenderer>().sprite = campsiteSprite;
        // ������ Ÿ���� ���� ������Ʈ�� ���� SpriteRenderer�� sprite�� campsiteSprite�� �ٲ��ش�
        voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_].transform.tag = "RoadTile";
        // ������ Ÿ���� �±׸� RoadTile �� �ٲ��ش�
        voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_].name = "CampsiteTile";
        GameObject obj = Instantiate(richPrefab, voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_].transform.position, Quaternion.identity, voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_].transform);
        obj.name = "BOSS";
        obj.GetComponent<RectTransform>().localPosition = new Vector3(0, -0.5f, 0);
        obj.SetActive(false);

        passPoints.Add(voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_]);
        // ������ Ÿ�Ͽ� �߰� 1

        randIdxY_ = Random.Range(1, 2);
        randIdxX_ = Random.Range(9, 12);

        passPoints.Add(voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_]);
        // ������ Ÿ�Ͽ� �߰� 2

        randIdxY_ = Random.Range(3, 4);
        randIdxX_ = Random.Range(13, 16);

        passPoints.Add(voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_]);
        // ������ Ÿ�Ͽ� �߰� 3

        randIdxY_ = Random.Range(5, 6);
        randIdxX_ = Random.Range(14, 17);

        passPoints.Add(voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_]);
        // ������ Ÿ�Ͽ� �߰� 4

        randIdxY_ = Random.Range(7, 8);
        randIdxX_ = Random.Range(13, 16);

        passPoints.Add(voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_]);
        // ������ Ÿ�Ͽ� �߰� 5

        randIdxY_ = Random.Range(9, 10);
        randIdxX_ = Random.Range(9, 12);

        passPoints.Add(voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_]);
        // ������ Ÿ�Ͽ� �߰� 6

        randIdxY_ = Random.Range(7, 8);
        randIdxX_ = Random.Range(5, 8);

        passPoints.Add(voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_]);
        // ������ Ÿ�Ͽ� �߰� 7

        randIdxY_ = Random.Range(5, 6);
        randIdxX_ = Random.Range(4, 7);

        passPoints.Add(voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_]);
        // ������ Ÿ�Ͽ� �߰� 8

        LinkPassPoints(passPoints, passPoints[0]);

        playerInMap.transform.localPosition = passPoints[0].transform.localPosition;
        playerInMap.GetComponent<PlayerInMap>().enabled = true;

        SetSideTiles();
    }

    // RoadTile Tag�� �ƴ� Ÿ���� 8������ ������ Ÿ���� �ϳ��� RoadTile Tag��� SideTile�� ����
    private void SetSideTiles()
    {
        for (int i = 0; i < voidTiles.Count; i++)
        {
            int y_ = i / MAP_WIDTH;
            int x_ = i % MAP_WIDTH;

            if (!voidTiles[i].CompareTag("RoadTile") && !voidTiles[i].CompareTag("SideTile"))
            {
                if (y_ - 1 >= 0)
                {
                    if (voidTiles[(y_ - 1) * MAP_WIDTH + x_].CompareTag("RoadTile"))
                    {
                        voidTiles[i].tag = "SideTile";
                        voidTiles[i].AddComponent<SideTile>();
                        continue;
                    }
                }

                if (x_ - 1 >= 0)
                {
                    if (voidTiles[y_ * MAP_WIDTH + x_ - 1].tag.Equals("RoadTile"))
                    {
                        voidTiles[i].tag = "SideTile";
                        voidTiles[i].AddComponent<SideTile>();
                        continue;
                    }
                }

                if (x_ + 1 < MAP_WIDTH)
                {
                    if (voidTiles[y_ * MAP_WIDTH + x_ + 1].tag.Equals("RoadTile"))
                    {
                        voidTiles[i].tag = "SideTile";
                        voidTiles[i].AddComponent<SideTile>();
                        continue;
                    }
                }

                if (y_ + 1 < MAP_LENGTH)
                {
                    if (voidTiles[(y_ + 1) * MAP_WIDTH + x_].tag.Equals("RoadTile"))
                    {
                        voidTiles[i].tag = "SideTile";
                        voidTiles[i].AddComponent<SideTile>();
                        continue;
                    }
                }
            }
        }
    }

    // �����
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

    // ������
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

    // ���α�
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
    //���α�

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

            MakePassPointsSprite(points_);
            return;
        }
    }

    private void MakePassPointsSprite(List<GameObject> points_)
    {
        // �߿����� �����ϰ� üũ
        GameObject target_ = default;

        for (int i = 1; i < points_.Count; i++)
        {
            target_ = points_[i];

            int targetY_ = voidTiles.IndexOf(target_) / MAP_WIDTH;
            int targetX_ = voidTiles.IndexOf(target_) % MAP_WIDTH;

            bool isUp = false;
            bool isDown = false;
            bool isLeft = false;
            bool isRight = false;

            // �����¿� ��� Ÿ�� üũ
            if (voidTiles[(targetY_ - 1) * MAP_WIDTH + targetX_].tag.Equals("RoadTile"))
            {
                isUp = true;
            }   // ��

            if (voidTiles[(targetY_ + 1) * MAP_WIDTH + targetX_].tag.Equals("RoadTile"))
            {
                isDown = true;
            }   // ��

            if (voidTiles[targetY_ * MAP_WIDTH + targetX_ - 1].tag.Equals("RoadTile"))
            {
                isLeft = true;
            }   // ��

            if (voidTiles[targetY_ * MAP_WIDTH + targetX_ + 1].tag.Equals("RoadTile"))
            {
                isRight = true;
            }   // ��
            // �����¿� ��� Ÿ�� üũ

            // �˸��� ��������Ʈ�� ����
            if (isLeft && isRight)
            {
                CreateRoad(targetY_, targetX_, 0);
            }

            if (isUp && isDown)
            {
                CreateRoad(targetY_, targetX_, 1);
            }

            if (isDown && isRight)
            {
                CreateRoad(targetY_, targetX_, 2);
            }

            if (isDown && isLeft)
            {
                CreateRoad(targetY_, targetX_, 3);
            }

            if (isUp && isRight)
            {
                CreateRoad(targetY_, targetX_, 4);
            }

            if (isUp && isLeft)
            {
                CreateRoad(targetY_, targetX_, 5);
            }
            // �˸��� ��������Ʈ�� ����
        }
    }

    /// <summary>
    /// voidTiles���� [y, x] ��ġ�� Ÿ�� ��������Ʈ�� spriteIdx�� ���� �ٲ��ش�
    /// </summary>
    /// <param name="y_">Ÿ���� �� ��ġ</param>
    /// <param name="x_">Ÿ���� �� ��ġ</param>
    /// <param name="spriteIdx">Ÿ�� ��������Ʈ �ε��� (0: ��, 1: ��, 2: ��, 3: ��, 4: ��, 5: ��)</param>
    private void CreateRoad(int y_, int x_, int spriteIdx)
    {
        Sprite sprite = default;
        switch (spriteIdx)
        {
            case 0:
                sprite = roadSprite_H;
                voidTiles[y_ * MAP_WIDTH + x_].name = "ROAD_H";
                break;
            case 1:
                sprite = roadSprite_V;
                voidTiles[y_ * MAP_WIDTH + x_].name = "ROAD_V";
                break;
            case 2:
                sprite = roadSprite_1;
                voidTiles[y_ * MAP_WIDTH + x_].name = "ROAD_UR";
                break;
            case 3:
                sprite = roadSprite_2;
                voidTiles[y_ * MAP_WIDTH + x_].name = "ROAD_UL";
                break;
            case 4:
                sprite = roadSprite_3;
                voidTiles[y_ * MAP_WIDTH + x_].name = "ROAD_DR";
                break;
            case 5:
                sprite = roadSprite_4;
                voidTiles[y_ * MAP_WIDTH + x_].name = "ROAD_DL";
                break;
        }

        if (voidTiles[y_ * MAP_WIDTH + x_].transform.tag != "RoadTile")
        {
            voidTiles[y_ * MAP_WIDTH + x_].GetComponentInChildren<SpriteRenderer>().sprite = sprite;
            // ������ Ÿ���� ���� ������Ʈ�� ���� SpriteRenderer�� sprite�� campsiteSprite�� �ٲ��ش�
            voidTiles[y_ * MAP_WIDTH + x_].transform.tag = "RoadTile";
            // ������ Ÿ���� �±׸� RoadTile �� �ٲ��ش�
            voidTiles[y_ * MAP_WIDTH + x_].AddComponent<RoadTile>();
        }
    }

    private List<GameObject> SortTiles(List<GameObject> tiles_)
    {
        GameObject[] sortedTiles_ = new GameObject[tiles_.Count];
        // ������� ���� �ʱ� ������ �迭�� ����

        for (int i = 0; i < tiles_.Count; i++)
        {
            float y = Mathf.Abs(tiles_[i].transform.localPosition.y - 5.5f);
            // 5.5f �� ���� ���� ��ġ�� Ÿ���� y��

            float x = Mathf.Abs(tiles_[i].transform.localPosition.x + 12.5f);
            // -(-12.5f) �� ���� ���ʿ� ��ġ�� Ÿ���� x��

            GameObject obj = tiles_[i];
            sortedTiles_[Mathf.RoundToInt(y * 21f + x)] = obj;
            // y�� x�� �̿��� transform.localPosition�� �»�ܺ��� ���������� 2���� �迭ó�� ����
        }

        List<GameObject> temp_ = new List<GameObject>();
        // ��ȯ���� �ӽ� List ����

        for (int i = 0; i < sortedTiles_.Length; i++)
        {
            GameObject obj = sortedTiles_[i];
            obj.GetComponentInChildren<SpriteRenderer>().sortingOrder = i / MAP_WIDTH;
            temp_.Add(obj);
            // sortedTiles_�� ������� add
        }

        return temp_;
        // �ӽ� List ��ȯ
    }       // SortTiles(List<GameObject> tiles_)

    public List<GameObject> GetVoidTiles()
    {
        if (voidTiles == null || voidTiles == default)
        {
            return default;
        }

        return voidTiles;
    }
}
