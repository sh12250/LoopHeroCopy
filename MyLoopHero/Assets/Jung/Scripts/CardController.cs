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
        RaycastHit2D hit_Tiles = GameManager.instance.GetHit("Tiles");
        RaycastHit2D hit_Hands = GameManager.instance.GetHit("Hands");

        switch (name)
        {
            case "OBLIVION":
                break;
            case "CEMETARY":
                break;
            case "VILLAGE":
                break;
            case "BUSH":
                break;
            case "CORNFIELD":
                break;
            case "COCOON":
                break;
            case "MANSION":
                break;
            case "BATTLEFIELD":
                break;
            case "LIGHTHOUSE":
                break;
            case "ROCK":
                break;
            case "MOUNT":
                break;
            case "BLOODYBUSH":
                break;
            case "LAMP":
                break;
            case "SWAMP":
                break;
            case "SAFE":
                break;
            case "GRASS":
                break;
        }

        if (hit_Tiles.collider != null)
        {

        }

        if (transform.localPosition.y <= 40)
        {
            OnHand();
        }
        else if (transform.localPosition.y > 40)
        {
            OnBuild();
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