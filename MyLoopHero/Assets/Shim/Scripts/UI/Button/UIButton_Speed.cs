using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButton_Speed : UIButton
{
    protected override void Awake()
    {
        // button 이라는 GameObject는 이 스크립트를 상속할 스크립트를 가진 오브젝트이다.
        button = this.gameObject;

        // buttonText 에 button 하위의 TMP_Text 컴포넌트를 가진 오브젝트를 담는다.
        buttonText = button.GetComponentInChildren<TMP_Text>();
    }

    protected override void DoPointerEnter(PointerEventData eventData)
    {
        base.DoPointerEnter(eventData);
    }

    protected override void DoPointerExit(PointerEventData eventData)
    {
        base.DoPointerExit(eventData);
    }

    protected override void DoPointerDown(PointerEventData eventData)
    {
        base.DoPointerDown(eventData);
    }

    protected override void DoPointerUp(PointerEventData eventData)
    {
        base.DoPointerUp(eventData);

        if (Time.timeScale == 1)
        {
            Time.timeScale = 1.5f;
            buttonText.text = "x 1.5";
        }
        else if (Time.timeScale == 1.5)
        {
            Time.timeScale = 2;
            buttonText.text = "x 2";
        }
        else if (Time.timeScale == 2)
        {
            Time.timeScale = 1;
            buttonText.text = "x 1";
        }
    }
}
