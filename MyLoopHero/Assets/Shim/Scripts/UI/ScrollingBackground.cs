using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingBackground : MonoBehaviour
{
    private GameObject backGround;

    private WaitForSecondsRealtime moveTime;


    private void Awake()
    {
        backGround = this.gameObject;

        moveTime = new WaitForSecondsRealtime(1f);
    }

    private void Start()
    {
        StartCoroutine(Scroll(backGround.GetComponent<RectTransform>().anchoredPosition.x, 
            backGround.GetComponent<RectTransform>().anchoredPosition.y));
    }

    IEnumerator Scroll(float X_, float Y_)
    {
        // { 루프
        while (true)
        {
            if (X_ <= 1)
            {
                yield return moveTime;
                if (Time.timeScale == 0)
                {
                    /*Do Nothing*/
                }
                else
                {
                    backGround.GetComponent<RectTransform>().anchoredPosition =
                        new Vector2(X_, Y_);

                    X_ -= 1.6f;
                    Y_ -= 0.9f;                
                }
            }
            else
            {
                yield break;
            }
        }
        // } 루프
    }
}
