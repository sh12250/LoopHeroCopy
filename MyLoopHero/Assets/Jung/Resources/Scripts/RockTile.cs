using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RockTile : MonoBehaviour
{
    void Start()
    {
        RememberAnim anim = RememberAnimPool.GetObject();
        anim.transform.parent = transform;
        anim.transform.localPosition = Vector3.zero;
        anim.transform.localScale = Vector3.one;
    }
}
