using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButton_Start : UIButton
{
    private GameObject titleWindow;
    private Vector2 titleWindowMovePosition;


    protected override void Awake()
    {
        // button 이라는 GameObject는 이 스크립트를 상속할 스크립트를 가진 오브젝트이다.
        button = this.gameObject;
        // buttonText 에 button 하위의 TMP_Text 컴포넌트를 가진 오브젝트를 담는다.
        buttonText = button.GetComponentInChildren<TMP_Text>();


        // titleWindow
        titleWindow = GameObject.Find("TravelWindow").gameObject;

        // start 버튼을 눌렀을 때, titleWindow 가 움직일 위치
        titleWindowMovePosition = new Vector2(0f, 0f);
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

        titleWindow.GetComponent<RectTransform>().anchoredPosition = titleWindowMovePosition;
    }
}
