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

    private string scriptNames;

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

    void Start()
    {

    }

    void Update()
    {

    }

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
            case "MANSION":
            case "BATTLEFIELD":
            case "LIGHTHOUSE":
            case "LAMP":
            case "BLOODYBUSH":
                // "SideTile"
                break;
            case "ROCK":
                if (tile_.name == "VoidTile")
                {
                    tile_.GetComponentInChildren<SpriteRenderer>().sprite = rock;
                    RememberTile(tile_, card_.name);
                }

                break;
            case "MOUNT":
                if (tile_.name == "VoidTile")
                {
                    tile_.GetComponentInChildren<SpriteRenderer>().sprite = mount;
                    RememberTile(tile_, card_.name);
                }

                break;
            case "SAFE":
                if (tile_.name == "VoidTile")
                {
                    tile_.GetComponentInChildren<SpriteRenderer>().sprite = safe;
                    RememberTile(tile_, card_.name);
                }

                break;
            case "GRASS":
                if (tile_.name == "VoidTile")
                {
                    tile_.GetComponentInChildren<SpriteRenderer>().sprite = grass;
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
