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
        FollowMouse();

        if (transform.localPosition.y <= 40)
        {
            OnHand();
        }
        else if (transform.localPosition.y > 40)
        {
            OnBuild();
        }
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