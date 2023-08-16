using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public static TileManager instance;

    public Sprite[] cemetary;
    public Sprite[] village;
    public Sprite[] bush;
    public Sprite[] cornfield;
    public Sprite[] swamp;
    public Sprite cocoon;
    public Sprite mansion;
    public Sprite battlefield;
    public Sprite lighthouse;
    public Sprite rock;
    public Sprite mount;
    public Sprite bloodybush;
    public Sprite lamp;
    public Sprite safe;
    public Sprite grass;

    private void Awake()
    {
        if (instance == null || instance == default)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("TileManager가 너무 많습니다");
        }
    }

    // 인접한 로드 타일 체크해서 리스트로 반환하는 함수들
    // 십자 체크
    public List<GameObject> FindRoadTiles(GameObject currTile_)
    {
        List<GameObject> allTiles_ = MapManager.instance.GetVoidTiles();
        int idx_ = allTiles_.IndexOf(currTile_);
        int y_ = idx_ / 21;
        int x_ = idx_ % 21;

        List<GameObject> roadTiles_ = new List<GameObject>();

        if (allTiles_[(y_ - 1) * 21 + x_].CompareTag("RoadTile"))
        {
            roadTiles_.Add(allTiles_[(y_ - 1) * 21 + x_]);
        }
        if (allTiles_[(y_ + 1) * 21 + x_].CompareTag("RoadTile"))
        {
            roadTiles_.Add(allTiles_[(y_ + 1) * 21 + x_]);
        }
        if (allTiles_[y_ * 21 + x_ - 1].CompareTag("RoadTile"))
        {
            roadTiles_.Add(allTiles_[y_ * 21 + x_ - 1]);
        }
        if (allTiles_[y_ * 21 + x_ + 1].CompareTag("RoadTile"))
        {
            roadTiles_.Add(allTiles_[y_ * 21 + x_ + 1]);
        }

        if (currTile_.CompareTag("RoadTile"))
        {
            roadTiles_.Add(currTile_);
        }

        return roadTiles_;
    }
    // 인접한 로드 타일 체크해서 리스트로 반환하는 함수들

    public void ChangeTile(GameObject card_, GameObject tile_)
    {
        if (tile_ == null || card_ == null) { return; }

        switch (card_.name)
        {
            case "OBLIVION":
                // 모든것을 지운다

                break;
            case "CEMETARY":
                if (SelectSprite(tile_) != -1)
                {
                    tile_.GetComponentInChildren<SpriteRenderer>().sprite = cemetary[SelectSprite(tile_)];
                    RememberTile(tile_, card_.name);
                }

                break;
            case "VILLAGE":
                if (SelectSprite(tile_) != -1)
                {
                    tile_.GetComponentInChildren<SpriteRenderer>().sprite = village[SelectSprite(tile_)];
                    RememberTile(tile_, card_.name);
                }

                break;
            case "BUSH":
                if (SelectSprite(tile_) != -1)
                {
                    tile_.GetComponentInChildren<SpriteRenderer>().sprite = bush[SelectSprite(tile_)];
                    RememberTile(tile_, card_.name);
                }

                break;
            case "CORNFIELD":
                if (SelectSprite(tile_) != -1)
                {
                    tile_.GetComponentInChildren<SpriteRenderer>().sprite = cornfield[SelectSprite(tile_)];
                    RememberTile(tile_, card_.name);
                }

                break;
            case "SWAMP":
                if (SelectSprite(tile_) != -1)
                {
                    tile_.GetComponentInChildren<SpriteRenderer>().sprite = swamp[SelectSprite(tile_)];
                    RememberTile(tile_, card_.name);
                }

                break;
            case "COCOON":
                if (tile_.tag.Equals("SideTile"))
                {
                    tile_.GetComponentInChildren<SpriteRenderer>().sprite = cocoon;
                    RememberTile(tile_, card_.name);
                }

                break;
            case "MANSION":
                if (tile_.tag.Equals("SideTile"))
                {
                    tile_.GetComponentInChildren<SpriteRenderer>().sprite = mansion;
                    RememberTile(tile_, card_.name);
                }

                break;
            case "BATTLEFIELD":
                if (tile_.tag.Equals("SideTile"))
                {
                    tile_.GetComponentInChildren<SpriteRenderer>().sprite = battlefield;
                    RememberTile(tile_, card_.name);
                }

                break;
            case "LAMP":
                if (tile_.tag.Equals("SideTile"))
                {
                    tile_.GetComponentInChildren<SpriteRenderer>().sprite = lamp;
                    RememberTile(tile_, card_.name);
                }

                break;
            case "BLOODYBUSH":
                if (tile_.tag.Equals("SideTile"))
                {
                    tile_.GetComponentInChildren<SpriteRenderer>().sprite = bloodybush;
                    RememberTile(tile_, card_.name);
                }

                break;
            case "ROCK":
                if (tile_.tag.Equals("EtcTile"))
                {
                    tile_.GetComponentInChildren<SpriteRenderer>().sprite = rock;
                    RememberTile(tile_, card_.name);
                }

                break;
            case "MOUNT":
                if (tile_.tag.Equals("EtcTile"))
                {
                    tile_.GetComponentInChildren<SpriteRenderer>().sprite = mount;
                    RememberTile(tile_, card_.name);
                }

                break;
            case "SAFE":
                if (tile_.tag.Equals("EtcTile"))
                {
                    tile_.GetComponentInChildren<SpriteRenderer>().sprite = safe;
                    RememberTile(tile_, card_.name);
                }

                break;
            case "GRASS":
                if (tile_.tag.Equals("EtcTile"))
                {
                    tile_.GetComponentInChildren<SpriteRenderer>().sprite = grass;
                    RememberTile(tile_, card_.name);
                }

                break;
            case "LIGHTHOUSE":
                if (tile_.tag.Equals("SideTile"))
                {
                    tile_.GetComponentInChildren<SpriteRenderer>().sprite = lighthouse;
                    RememberTile(tile_, card_.name);
                }

                break;
        }
    }

    private void RememberTile(GameObject tile_, string name_)
    {
        tile_.name = name_;

        RememberAnim anim = RememberAnimPool.GetObject();
        anim.transform.SetParent(tile_.transform, false);
    }

    private int SelectSprite(GameObject tile_)
    {
        if (tile_ == null || tile_ == default) { return -1; }

        switch (tile_.name)
        {
            case "ROAD_H":
                return 0;
            case "ROAD_V":
                return 1;
            case "ROAD_UR":
                return 2;
            case "ROAD_UL":
                return 3;
            case "ROAD_DR":
                return 4;
            case "ROAD_DL":
                return 5;
            default: return -1;
        }
    }
}
