using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushTile : Tile
{


    void Start()
    {
        CreateTile();
    }

    public override void CreateTile()
    {
        base.CreateTile();
        anim.transform.SetParent(transform);
        anim.transform.localPosition = Vector3.zero;
    }
}
