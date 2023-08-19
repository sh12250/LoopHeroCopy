using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIButton_Boss : UIButton
{
    public Sprite bossSprite_0;
    public Sprite bossSprite_1;

    protected override void Awake()
    {
        // button 이라는 GameObject는 이 스크립트를 상속할 스크립트를 가진 오브젝트이다.
        button = this.gameObject;

        // buttonText 에 button 하위의 TMP_Text 컴포넌트를 가진 오브젝트를 담는다.
        buttonText = button.GetComponentInChildren<TMP_Text>();

        isPress = false;

        bossSprite_0 = button.GetComponentInChildren<Image>().sprite;
        bossSprite_1 = button.GetComponentInChildren<Image>().sprite;
    }

    public void MakeBaseState()
    {
        button.GetComponent<Image>().sprite = baseSprite;
        buttonText.color = Color.white;
    }

    public void MakeHighlightState()
    {
        button.GetComponent<Image>().sprite = hoverSprite;
        buttonText.color = Color.white;
    }

    public void MakePressState()
    {
        button.GetComponent<Image>().sprite = pressSprite;
        buttonText.color = Color.grey;
    }


    protected override void DoPointerEnter(PointerEventData eventData)
    {
        if (isPress == true)
        {
            /*Do Nothing*/
        }
        else if (isPress == false)
        {
            MakeHighlightState();
        }
    }

    protected override void DoPointerExit(PointerEventData eventData)
    {
        if (isPress == true)
        {
            /*Do Nothing*/
        }
        else if (isPress == false)
        {
            MakeBaseState();
        }
    }

    protected override void DoPointerDown(PointerEventData eventData)
    {
        if (isPress == true)
        {
            /*Do Nothing*/
        }
        else if (isPress == false)
        {
            MakePressState();
        }
    }

    protected override void DoPointerUp(PointerEventData eventData)
    {
        if (isPress == true)
        {
            /*Do Nothing*/
        }
        else if (isPress == false)
        {
            MakePressState();
            isPress = true;
        }
    }
}
