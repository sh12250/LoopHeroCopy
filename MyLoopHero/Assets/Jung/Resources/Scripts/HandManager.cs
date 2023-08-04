using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public static HandManager instance;

    [SerializeField]
    private GameObject hand;
    // 내 손패, 카드들이 하위로 들어온다

    private void Awake()
    {
        if (instance == null || instance == default)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("HandManager가 너무 많습니다");
        }
    }

    void Start()
    {
    }
    void Update()
    {
        RaycastHit2D hit_ = GameManager.instance.GetHit("Hands");

        if(Input.GetMouseButtonDown(0))
        {
            if (hit_.collider != null)
            {
                Debug.Log("hit 검출됨");
                GameObject obj = CardManager.instance.MakeCard();

                //obj.transform.position = 

                switch (hit_.collider.tag)
                {
                    case "RoadTile":
                        break;
                    case "SideTile":
                        break;
                    case "EtcTile":
                        break;
                    case "Oblivion":
                        break;
                }
            }
        }
    }

    public Transform GetHandTransform()
    {
        return hand.transform;
    }
}
