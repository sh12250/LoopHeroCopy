using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButton_CloseWindow : UIButton
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

        // 만약 유니티 에디터로 실행 중일 경우에는,
        if (UnityEditor.EditorApplication.isPlaying == true)
        {
            // 유니티 에디터의 재생을 꺼준다.
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            // 빌드된 게임을 종료한다.
            Application.Quit();
        }
    }
}
