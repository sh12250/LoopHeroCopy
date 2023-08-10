using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    protected RememberAnim anim;

    public virtual void CreateTile()
    {
        anim = RememberAnimPool.GetObject();
        anim.transform.localScale = Vector3.one;
    }
}
