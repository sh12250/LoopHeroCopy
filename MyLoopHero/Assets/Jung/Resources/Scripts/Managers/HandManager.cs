using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
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
        RaycastHit2D hit2_ = GameManager.instance.GetHit("Cards");

        if (Input.GetMouseButtonDown(0))
        {
            if (hit2_.collider != null)
            {
                switch (hit2_.collider.name)
                {
                    case "ROCK":
                        hit2_.collider.GetComponent<FollowMouse>().enabled = true;

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
        else if (Input.GetMouseButtonUp(0))
        {
            if (hit2_.collider != null)
            {
                switch (hit2_.collider.name)
                {
                    case "ROCK":
                        hit2_.collider.GetComponent<FollowMouse>().enabled = false;


                        int idx = myHands.IndexOf(hit2_.collider.gameObject);
                        myHands[idx].transform.localPosition = new Vector3(-451 + (idx * 2 * 41), 0, 0);
                        myHands[idx].GetComponent<FollowMouse>().OnHand();

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

        if (Input.GetMouseButtonDown(1))
        {
            if (hit_.collider != null)
            {
                Debug.Log("hit �����");
                GameObject obj = CardManager.instance.MakeCard();
                myHands.Add(obj);

                if (myHands.Count >= 13)
                {
                    Destroy(myHands[0]);
                    myHands.Remove(myHands[0]);

                    for (int i = 0; i < myHands.Count; i++)
                    {
                        myHands[i].transform.localPosition = new Vector3(-451 + (i * 2 * 41), 0, 0);
                    }
                }

                obj.transform.localPosition = new Vector3(-451 + (myHands.IndexOf(obj) * 2 * 41), 0, 0);
            }
        }
    }

    public Transform GetHandTransform()
    {
        return hand.transform;
    }
}
