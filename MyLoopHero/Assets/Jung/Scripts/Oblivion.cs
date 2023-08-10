using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oblivion : MonoBehaviour
{
    [SerializeField]
    private Sprite toCompare;

    void Update()
    {
        if (gameObject.GetComponentsInChildren<SpriteRenderer>()[0].sprite == toCompare)
        {
            Destroy(gameObject);
        }
    }
}
