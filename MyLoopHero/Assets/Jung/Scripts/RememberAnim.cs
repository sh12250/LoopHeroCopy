using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RememberAnim : MonoBehaviour
{
    [SerializeField]
    private Sprite toCompare;

    void Update()
    {
        if (gameObject.GetComponentsInChildren<SpriteRenderer>()[0].sprite == toCompare)
        {
            DestroyAnim();
        }
    }

    public void DestroyAnim()
    {
        RememberAnimPool.ReturnObject(this);
    }
}