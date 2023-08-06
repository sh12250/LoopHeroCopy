using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public static HandManager instance;

    [SerializeField]
    private GameObject hand;
    // �� ����, ī����� ������ ���´�
    private List<GameObject> myHands;

    private void Awake()
    {
        if (instance == null || instance == default)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("HandManager�� �ʹ� �����ϴ�");
        }
    }

    void Start()
    {
        myHands = new List<GameObject>();
    }
    void Update()
    {
        RaycastHit2D hit_ = GameManager.instance.GetHit("Hands");

        if(Input.GetMouseButtonDown(0))
        {
            if (hit_.collider != null)
            {
                Debug.Log("hit �����");
                GameObject obj = CardManager.instance.MakeCard();
                myHands.Add(obj);

                obj.transform.localPosition = new Vector3(-451 + (myHands.IndexOf(obj) * 2 * 41), -14, 0);

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
