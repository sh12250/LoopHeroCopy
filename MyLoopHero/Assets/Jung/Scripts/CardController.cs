using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        switch (name)
        {
            case "OBLIVION":
                BuildOnMap();
                break;
            case "CEMETARY":
            case "VILLAGE":
            case "BUSH":
            case "CORNFIELD":
            case "SWAMP":
                BuildOnMap("RoadTile");
                break;
            case "COCOON":
            case "MANSION":
            case "BATTLEFIELD":
            case "LIGHTHOUSE":
            case "LAMP":
            case "BLOODYBUSH":
                BuildOnMap("SideTile");
                break;
            case "ROCK":
            case "MOUNT":
            case "SAFE":
            case "GRASS":
                BuildOnMap("EtcTile");
                break;
        }

        if (transform.localPosition.y <= 40)
        {
            OnHand();
        }
        else if (transform.localPosition.y > 40)
        {
            OnBuild();
        }
    }

    private void BuildOnMap()
    {
        RaycastHit2D hit_Tiles = GameManager.instance.GetHit("Tiles");

        if (hit_Tiles.collider != null)
        {
            transform.position = hit_Tiles.transform.position;

            return;
        }

        FollowMouse();
    }

    private void BuildOnMap(string tagName_)
    {
        RaycastHit2D hit_Tiles = GameManager.instance.GetHit("Tiles");

        if (hit_Tiles.collider != null)
        {
            if (hit_Tiles.collider.tag.Equals(tagName_))
            {
                transform.position = hit_Tiles.transform.position;

                if (Input.GetMouseButtonUp(0))
                {
                    
                }

                return;
            }
        }

        FollowMouse();
    }

    public void OnHand()
    {
        gameObject.GetComponentsInChildren<Image>()[0].enabled = true;
        gameObject.GetComponentsInChildren<Image>()[1].enabled = true;
        gameObject.GetComponentsInChildren<SpriteRenderer>()[0].enabled = false;
    }

    public void OnBuild()
    {
        gameObject.GetComponentsInChildren<Image>()[0].enabled = false;
        gameObject.GetComponentsInChildren<Image>()[1].enabled = false;
        gameObject.GetComponentsInChildren<SpriteRenderer>()[0].enabled = true;
    }

    public void FollowMouse()
    {
        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y);
        transform.position = mainCamera.ScreenToWorldPoint(position);

        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}