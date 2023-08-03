using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMap : MonoBehaviour
{
    [SerializeField]
    private GameObject tileMap;
    // Ÿ�ϸ�, ������ Ÿ���� ������Ű ���� �޾ƿ´�
    [SerializeField]
    private GameObject[] voidTiles;
    // Ÿ�ϸ��� �⺻ Ÿ�ϵ�
    public Sprite campfireSprite;
    // �߿��� Ÿ��, ���� Ÿ�� ��������Ʈ
    public Sprite roadSprite;
    // �� Ÿ�� ��������Ʈ, �߿������� �����ؼ� �߿����� �̾�����

    private static int MAP_LENGTH = 12;
    private static int MAP_WIDTH = 21;
    // ũ��� 12 X 21

    void Start()
    {
        _SortTiles(voidTiles);
        // Ÿ�� ����

        int campsiteY_ = Random.Range(MAP_LENGTH / 3, MAP_LENGTH * 2 / 3);
        int campsiteX_ = Random.Range(MAP_WIDTH / 3, MAP_WIDTH * 2 / 3);
        // Ÿ�ϸ� �߾� ���� ���� ��ǥ


        // ���� ��ǥ�� �⺻ Ÿ�� ��ġ�� �߿��� ����

        // �߿����� ��ġ�� �⺻ Ÿ�� ���ֱ�
    }

    void Update()
    {

    }

    private void _SortTiles(GameObject[] tiles_)
    {
        float y = 0;
        float x = 0;

        for (int i = 0; i < tiles_.Length;)
        {
            y = Mathf.Abs(tiles_[i].transform.position.y - 5.5f);
            // 5.5f �� ���� ���� ��ġ�� Ÿ���� y��

            x = Mathf.Abs(tiles_[i].transform.position.x + 12.5f);
            // -(-12.5f) �� ���� ���ʿ� ��ġ�� Ÿ���� x��

            GameObject tileTemp_ = tiles_[i];
            tiles_[i] = tiles_[(int)y * 21 + (int)x];
            tiles_[(int)y * 21 + (int)x] = tileTemp_;
            // ����

            if ((tiles_[(int)y * 21 + (int)x].transform.position.y * 21 + tiles_[(int)y * 21 + (int)x].transform.position.x) != i)
            {
                // ������ Ÿ���� ��ǥ�� ���ο� ��ǥ�� ���� ���� ���
                continue;
                // �ٽ� ����
            }
            else
            {
                // ������ Ÿ���� ��ǥ�� ���ο� ��ǥ�� ���� ���
                i += 1;
                // ���� Ÿ���� ��ǥ�� ����
            }
        }
    }
}
