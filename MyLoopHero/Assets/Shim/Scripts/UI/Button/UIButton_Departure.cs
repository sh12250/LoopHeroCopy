using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class UIButton_Departure : UIButton
{
    private GameObject title;
    private GameObject background;
    private GameObject map;
    private GameObject travelUI;
    private Vector2 titleSceneMovePosition;
    private Vector2 backgroundMovePosition;
    private Vector2 mapMovePosition;
    private Vector2 travelUIMovePosition;

    protected override void Awake()
    {
        button = this.gameObject;
        // buttonText 에 button 하위의 TMP_Text 컴포넌트를 가진 오브젝트를 담는다.
        buttonText = button.GetComponentInChildren<TMP_Text>();

        // title
        title = GameObject.Find("Title").gameObject;
        // background
        background = GameObject.Find("Background").gameObject;
        // map
        map = GameObject.Find("MainObject").gameObject;
        // travelUI
        travelUI = GameObject.Find("TravelUI").gameObject;


        // 버튼을 눌렀을 때, title 장면이 움직일 위치
        titleSceneMovePosition = new Vector2(0f, 2000f);
        // 버튼을 눌렀을 때, background 이 움직일 위치
        backgroundMovePosition = new Vector2(0f,0f);
        // 버튼을 눌렀을 때, map 이 움직일 위치
        mapMovePosition = new Vector2(0f, 0f);
        // 버튼을 눌렀을 때, travelUI 장면이 움직일 위치
        travelUIMovePosition = new Vector2(0f, 0f);
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
        background.GetComponent<RectTransform>().anchoredPosition =
            backgroundMovePosition;
        map.GetComponent<RectTransform>().anchoredPosition =
            mapMovePosition;
        travelUI.GetComponent<RectTransform>().anchoredPosition = travelUIMovePosition;

        AudioManager.instance.PlayMusic_Basic();
        MapTime.MapTimeScale(1);
    }
}
