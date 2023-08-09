using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

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

    void Update()
    {

    }

    private void CreateMap()
    {
        voidTiles = new List<GameObject>();

        for (int i = 0; i < tileMap.gameObject.transform.childCount; i++)
        {
            GameObject obj = tileMap.gameObject.transform.GetChild(i).gameObject;
            // tileMap�� ���� ������Ʈ Hierarchy���� ������� ã��
            voidTiles.Add(obj);
            // ã�ƿ� ���� ������Ʈ add
        }

        voidTiles = SortTiles(voidTiles);
        // ������ Ÿ�� ����

        passPoints = new List<GameObject>();
        // ���� ������ Ÿ�ϵ�

        while (passPoints.Count < 8)
        {
            int randIdxY_ = Random.Range(2, 5);
            int randIdxX_ = Random.Range(4, 9);

            voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_].GetComponentInChildren<SpriteRenderer>().sprite = campsiteSprite;
            // ������ Ÿ���� ���� ������Ʈ�� ���� SpriteRenderer�� sprite�� campsiteSprite�� �ٲ��ش�
            voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_].transform.tag = "RoadTile";
            // ������ Ÿ���� �±׸� RoadTile �� �ٲ��ش�

            passPoints.Add(voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_]);
            // ������ Ÿ�Ͽ� �߰�

            randIdxY_ = Random.Range(2, 5);
            randIdxX_ = Random.Range(8, 13);

            passPoints.Add(voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_]);
            // ������ Ÿ�Ͽ� �߰�

            randIdxY_ = Random.Range(2, 5);
            randIdxX_ = Random.Range(12, 17);

            passPoints.Add(voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_]);
            // ������ Ÿ�Ͽ� �߰�

            randIdxY_ = Random.Range(4, 7);
            randIdxX_ = Random.Range(12, 17);

            passPoints.Add(voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_]);
            // ������ Ÿ�Ͽ� �߰�

            randIdxY_ = Random.Range(6, 9);
            randIdxX_ = Random.Range(12, 17);

            passPoints.Add(voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_]);
            // ������ Ÿ�Ͽ� �߰�

            randIdxY_ = Random.Range(6, 9);
            randIdxX_ = Random.Range(8, 13);

            passPoints.Add(voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_]);
            // ������ Ÿ�Ͽ� �߰�

            randIdxY_ = Random.Range(6, 9);
            randIdxX_ = Random.Range(4, 9);

            passPoints.Add(voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_]);
            // ������ Ÿ�Ͽ� �߰�

            randIdxY_ = Random.Range(4, 7);
            randIdxX_ = Random.Range(4, 9);

            passPoints.Add(voidTiles[randIdxY_ * MAP_WIDTH + randIdxX_]);
            // ������ Ÿ�Ͽ� �߰�
        }

        LinkPassPoints(passPoints, passPoints[0]);

        playerInMap.transform.localPosition = passPoints[0].transform.localPosition;
        playerInMap.GetComponent<PlayerInMap>().enabled = true;
    }

    private void LinkPassPoints(List<GameObject> points_, GameObject startPoint_)
    {
        if (points_ == null || points_ == default || points_.Count == 0) { return; }

        GameObject target_ = default;

        // �߿����� ������ ��츦 Ȯ��
        if (points_.IndexOf(startPoint_) != points_.Count - 1)
        {   // �߿����� ������ Ÿ���� ������ ���
            target_ = points_[points_.IndexOf(startPoint_) + 1];

            int startY_ = voidTiles.IndexOf(startPoint_) / 21;
            int startX_ = voidTiles.IndexOf(startPoint_) % 21;
            int targetY_ = voidTiles.IndexOf(target_) / 21;
            int targetX_ = voidTiles.IndexOf(target_) % 21;

            Vector2 distance = new Vector2(targetX_ - startX_, targetY_ - startY_);

            int currY_ = startY_;
            int currX_ = startX_;

            int distY_ = 0;
            int distX_ = 0;

            if (Mathf.Abs(targetX_ - startX_) >= Mathf.Abs(targetY_ - startY_))
            {
                if (startX_ > targetX_)
                {
                    distX_ = startX_ - targetX_;

                    // �ϴ� �ݸ� �̵�
                    for (int i = 0; i < distX_ / 2; i++)
                    {
                        currX_ -= 1;
                        if (i != (distX_ / 2) - 1)
                        {
                            CreateRoad(currY_, currX_, 0);
                        }
                    }
                    // �ϴ� �ݸ� �̵�

                    // Y��ǥ �̵�
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
                    if (startY_ == targetY_)
                    {
                        CreateRoad(currY_, currX_, 0);
                    }
                    // Y��ǥ �̵�

                    // ������ �� �̵�
                    for (int i = 0; i < distX_ - (distX_ / 2); i++)
                    {
                        currX_ -= 1;
                        CreateRoad(currY_, currX_, 0);
                    }
                    // ������ �� �̵�
                }

                if (startX_ < targetX_)
                {
                    distX_ = targetX_ - startX_;

                    // �ϴ� �ݸ� �̵�
                    for (int i = 0; i < distX_ / 2; i++)
                    {
                        currX_ += 1;
                        if (i != (distX_ / 2) - 1)
                        {
                            CreateRoad(currY_, currX_, 0);
                        }
                    }
                    // �ϴ� �ݸ� �̵�

                    // Y��ǥ �̵�
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
                    if (startY_ == targetY_)
                    {
                        CreateRoad(currY_, currX_, 0);
                    }
                    // Y��ǥ �̵�

                    // ������ �� �̵�
                    for (int i = 0; i < distX_ - (distX_ / 2); i++)
                    {
                        currX_ += 1;
                        CreateRoad(currY_, currX_, 0);
                    }
                    // ������ �� �̵�
                }
            }
            else if (Mathf.Abs(targetX_ - startX_) < Mathf.Abs(targetY_ - startY_))
            {
                if (startY_ > targetY_)
                {
                    distY_ = startY_ - targetY_;

                    // �ϴ� �ݸ� �̵�
                    for (int i = 0; i < distY_ / 2; i++)
                    {
                        currY_ -= 1;
                        if (i != (distY_ / 2) - 1)
                        {
                            CreateRoad(currY_, currX_, 1);
                        }
                    }
                    // �ϴ� �ݸ� �̵�

                    // X��ǥ �̵�
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
                    if (startX_ == targetX_)
                    {
                        CreateRoad(currY_, currX_, 1);
                    }
                    // X��ǥ �̵�

                    // ������ �� �̵�
                    for (int i = 0; i < distY_ - (distY_ / 2); i++)
                    {
                        currY_ -= 1;
                        CreateRoad(currY_, currX_, 1);
                    }
                    // ������ �� �̵�
                }

                if (startY_ < targetY_)
                {
                    distY_ = targetY_ - startY_;

                    // �ϴ� �ݸ� �̵�
                    for (int i = 0; i < distY_ / 2; i++)
                    {
                        currY_ += 1;
                        if (i != (distY_ / 2) - 1)
                        {
                            CreateRoad(currY_, currX_, 1);
                        }
                    }
                    // �ϴ� �ݸ� �̵�

                    // X��ǥ �̵�
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
                    if (startX_ == targetX_)
                    {
                        CreateRoad(currY_, currX_, 1);
                    }
                    // X��ǥ �̵�

                    // ������ �� �̵�
                    for (int i = 0; i < distY_ - (distY_ / 2); i++)
                    {
                        currY_ += 1;
                        CreateRoad(currY_, currX_, 1);
                    }
                    // ������ �� �̵�
                }
            }

            //points_.Remove(target_);
            LinkPassPoints(points_, target_);
        }
        else if (points_.IndexOf(startPoint_) == points_.Count - 1)
        {   // �߿����� ������ Ÿ���� ���� �ʾ��� ���
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

                    // �ϴ� �ݸ� �̵�
                    for (int i = 0; i < distX_ / 2; i++)
                    {
                        currX_ -= 1;
                        if (i != (distX_ / 2) - 1)
                        {
                            CreateRoad(currY_, currX_, 0);
                        }
                    }
                    // �ϴ� �ݸ� �̵�

                    // Y��ǥ �̵�
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
                    if (startY_ == targetY_)
                    {
                        CreateRoad(currY_, currX_, 0);
                    }
                    // Y��ǥ �̵�

                    // ������ �� �̵�
                    for (int i = 0; i < distX_ - (distX_ / 2); i++)
                    {
                        currX_ -= 1;
                        CreateRoad(currY_, currX_, 0);
                    }
                    // ������ �� �̵�
                }

                if (startX_ < targetX_)
                {
                    distX_ = targetX_ - startX_;

                    // �ϴ� �ݸ� �̵�
                    for (int i = 0; i < distX_ / 2; i++)
                    {
                        currX_ += 1;
                        if (i != (distX_ / 2) - 1)
                        {
                            CreateRoad(currY_, currX_, 0);
                        }
                    }
                    // �ϴ� �ݸ� �̵�

                    // Y��ǥ �̵�
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
                    if (startY_ == targetY_)
                    {
                        CreateRoad(currY_, currX_, 0);
                    }
                    // Y��ǥ �̵�

                    // ������ �� �̵�
                    for (int i = 0; i < distX_ - (distX_ / 2); i++)
                    {
                        currX_ += 1;
                        CreateRoad(currY_, currX_, 0);
                    }
                    // ������ �� �̵�
                }
            }
            else if (Mathf.Abs(targetX_ - startX_) < Mathf.Abs(targetY_ - startY_))
            {
                if (startY_ > targetY_)
                {
                    distY_ = startY_ - targetY_;

                    // �ϴ� �ݸ� �̵�
                    for (int i = 0; i < distY_ / 2; i++)
                    {
                        currY_ -= 1;
                        if (i != (distY_ / 2) - 1)
                        {
                            CreateRoad(currY_, currX_, 1);
                        }
                    }
                    // �ϴ� �ݸ� �̵�

                    // X��ǥ �̵�
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
                    if (startX_ == targetX_)
                    {
                        CreateRoad(currY_, currX_, 1);
                    }
                    // X��ǥ �̵�

                    // ������ �� �̵�
                    for (int i = 0; i < distY_ - (distY_ / 2); i++)
                    {
                        currY_ -= 1;
                        CreateRoad(currY_, currX_, 1);
                    }
                    // ������ �� �̵�
                }

                if (startY_ < targetY_)
                {
                    distY_ = targetY_ - startY_;

                    // �ϴ� �ݸ� �̵�
                    for (int i = 0; i < distY_ / 2; i++)
                    {
                        currY_ += 1;
                        if (i != (distY_ / 2) - 1)
                        {
                            CreateRoad(currY_, currX_, 1);
                        }
                    }
                    // �ϴ� �ݸ� �̵�

                    // X��ǥ �̵�
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
                    if (startX_ == targetX_)
                    {
                        CreateRoad(currY_, currX_, 1);
                    }
                    // X��ǥ �̵�

                    // ������ �� �̵�
                    for (int i = 0; i < distY_ - (distY_ / 2); i++)
                    {
                        currY_ += 1;
                        CreateRoad(currY_, currX_, 1);
                    }
                    // ������ �� �̵�
                }
            }

        }

        return;
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
            // ������ Ÿ���� ���� ������Ʈ�� ���� SpriteRenderer�� sprite�� campsiteSprite�� �ٲ��ش�
            voidTiles[y_ * MAP_WIDTH + x_].transform.tag = "RoadTile";
            // ������ Ÿ���� �±׸� RoadTile �� �ٲ��ش�
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
            temp_.Add(obj);
            // sortedTiles_�� ������� add
        }

        return temp_;
        // �ӽ� List ��ȯ
    }       // SortTiles(List<GameObject> tiles_)
}
