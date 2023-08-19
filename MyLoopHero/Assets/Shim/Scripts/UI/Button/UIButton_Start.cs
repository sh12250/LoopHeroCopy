using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButton_Start : UIButton
{
    private GameObject title;
    private GameObject travel;
    private Vector2 titleSceneMovePosition;
    private Vector2 travelSceneMovePosition;


    protected override void Awake()
    {
        // button 이라는 GameObject는 이 스크립트를 상속할 스크립트를 가진 오브젝트이다.
        button = this.gameObject;

        // buttonText 에 button 하위의 TMP_Text 컴포넌트를 가진 오브젝트를 담는다.
        buttonText = button.GetComponentInChildren<TMP_Text>();

        // title
        title = button.transform.root.GetChild(0).gameObject;
        // campsite
        travel = button.transform.root.GetChild(2).gameObject;
        // 버튼을 눌렀을 때, title 장면이 움직일 위치
        titleSceneMovePosition = new Vector2(0f, 2000f);
        // 버튼을 눌렀을 때, campsite 장면이 움직일 위치
        travelSceneMovePosition = new Vector2(0f, 0f);
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

        title.GetComponent<RectTransform>().anchoredPosition = titleSceneMovePosition;
        title.SetActive(false);
        travel.GetComponent<RectTransform>().anchoredPosition = travelSceneMovePosition;
    }
}
