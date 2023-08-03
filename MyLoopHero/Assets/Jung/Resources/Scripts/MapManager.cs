using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap tileMap;
    // Ÿ�ϸ�, ������ Ÿ���� ������Ű ���� �޾ƿ´�
    [SerializeField]
    private List<GameObject> voidTiles;
    // Ÿ�ϸ��� �⺻ Ÿ�ϵ�
    public Sprite campsiteSprite;
    // �߿��� Ÿ��, ���� Ÿ�� ��������Ʈ
    public Sprite roadSprite;
    // �� Ÿ�� ��������Ʈ, �߿������� �����ؼ� �߿����� �̾�����

    private static int MAP_LENGTH = 12;
    private static int MAP_WIDTH = 21;
    // ũ��� 12 X 21

    void Start()
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
        // Ÿ�� ����

        int campsiteY_ = Random.Range(MAP_LENGTH / 3, MAP_LENGTH * 2 / 3);
        int campsiteX_ = Random.Range(MAP_WIDTH / 3, MAP_WIDTH * 2 / 3);
        // Ÿ�ϸ� �߾� ���� ������ ��

        GameObject campsiteTile_ = voidTiles[campsiteY_ * 21 + campsiteX_].GetComponentInChildren<SpriteRenderer>().gameObject;
        // Ÿ���� ���� ������Ʈ�� ã�´�

        campsiteTile_.GetComponent<SpriteRenderer>().sprite = campsiteSprite;
        // ���� ������Ʈ�� Sprite�� CampsiteSprite�� �ٲ��ش�


    }

    void Update()
    {

    }

    private List<GameObject> SortTiles(List<GameObject> tiles_)
    {
        float y = 0f;
        float x = 0f;

        GameObject[] sortedTiles_ = new GameObject[tiles_.Count];
        // ������� ���� �ʱ� ������ �迭�� ����

        for (int i = 0; i < tiles_.Count; i++)
        {
            y = Mathf.Abs(tiles_[i].transform.localPosition.y - 5.5f);
            // 5.5f �� ���� ���� ��ġ�� Ÿ���� y��

            x = Mathf.Abs(tiles_[i].transform.localPosition.x + 12.5f);
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
