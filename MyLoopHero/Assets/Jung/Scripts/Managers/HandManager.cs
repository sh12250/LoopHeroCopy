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
    // 내 손패, 카드들이 하위로 들어온다
    private List<GameObject> myHands;

    private GameObject myCard;

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
        myHands = new List<GameObject>();
    }
    void Update()
    {
        RaycastHit2D hit_Cards = GameManager.instance.GetHit("Cards");
        RaycastHit2D hit_Tiles = GameManager.instance.GetHit("Tiles");

        if (Input.GetMouseButtonDown(0))
        {
            if (hit_Cards.collider != null)
            {
                myCard = hit_Cards.collider.gameObject;
                myCard.GetComponent<CardController>().enabled = true;
            }
        }
        else if (Input.GetMouseButton(0))
        {
            if (hit_Tiles.collider != null && myCard != null)
            {
                switch (myCard.name)
                {
                    case "OBLIVION":
                        BuildOnMap(myCard);
                        break;
                    case "CEMETARY":
                    case "VILLAGE":
                    case "BUSH":
                    case "CORNFIELD":
                    case "SWAMP":
                        BuildOnMap(myCard, "RoadTile");
                        break;
                    case "COCOON":
                    case "MANSION":
                    case "BATTLEFIELD":
                    case "LAMP":
                    case "BLOODYBUSH":
                        BuildOnMap(myCard, "SideTile");
                        break;
                    case "ROCK":
                    case "MOUNT":
                    case "SAFE":
                    case "GRASS":
                    case "LIGHTHOUSE":
                        BuildOnMap(myCard, "EtcTile");
                        break;
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (hit_Tiles.collider != null)
            {
                string tileName = hit_Tiles.collider.name;
                TileManager.instance.ChangeTile(myCard, hit_Tiles.collider.gameObject);
                
                if (tileName != hit_Tiles.collider.name)
                {
                    // 플레이된 카드 제거
                    myHands.Remove(myCard);
                    Destroy(myCard);
                    myCard = null;
                }

                // 카드 제거시 실행
                for (int i = 0; i < myHands.Count; i++)
                {
                    myHands[i].transform.localPosition = new Vector3(-451 + (i * 2 * 41), 0, 0);
                    myHands[i].GetComponent<CardController>().OnHand();
                }
            }

            if (myCard != null)
            {
                myCard.GetComponent<CardController>().enabled = false;

                int idx = myHands.IndexOf(myCard.gameObject);
                myHands[idx].transform.localPosition = new Vector3(-451 + (idx * 2 * 41), 0, 0);
                myHands[idx].GetComponent<CardController>().OnHand();
            }

        }

        // 디버그용
        // 우클릭시 카드 생성
        //if (Input.GetMouseButtonDown(1))
        //{
        //    DrawCard();
        //}

        /*
        OBLIVION = 0,
        CEMETARY
        VILLAGE
        BUSH
        CORNFIELD
        COCOON
        MANSION
        BATTLEFIELD
        LIGHTHOUSE
        ROCK
        MOUNT
        BLOODYBUSH
        LAMP
        SWAMP
        SAFE
        GRASS
        */

    }

    public void DrawCard()
    {
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

    private void BuildOnMap(GameObject card_)
    {
        RaycastHit2D hit_Tiles = GameManager.instance.GetHit("Tiles");

        if (hit_Tiles.collider != null)
        {
            card_.transform.position = hit_Tiles.transform.position;

            return;
        }
    }

    private void BuildOnMap(GameObject card_, string tagName_)
    {
        RaycastHit2D hit_Tiles = GameManager.instance.GetHit("Tiles");

        if (hit_Tiles.collider != null)
        {
            if (hit_Tiles.collider.tag.Equals(tagName_) && hit_Tiles.collider.name != "CampsiteTile")
            {
                card_.transform.position = hit_Tiles.transform.position;

                return;
            }
        }
    }

    public Transform GetHandTransform()
    {
        return hand.transform;
    }
}
