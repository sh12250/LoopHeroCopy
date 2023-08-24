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
        // buttonText �� button ������ TMP_Text ������Ʈ�� ���� ������Ʈ�� ��´�.
        buttonText = button.GetComponentInChildren<TMP_Text>();

        // title
        title = GameObject.Find("Title").gameObject;
        // background
        background = GameObject.Find("Background").gameObject;
        // map
        map = GameObject.Find("MainObject").gameObject;
        // travelUI
        travelUI = GameObject.Find("TravelUI").gameObject;


        // ��ư�� ������ ��, title ����� ������ ��ġ
        titleSceneMovePosition = new Vector2(0f, 2000f);
        // ��ư�� ������ ��, background �� ������ ��ġ
        backgroundMovePosition = new Vector2(0f,0f);
        // ��ư�� ������ ��, map �� ������ ��ġ
        mapMovePosition = new Vector2(0f, 0f);
        // ��ư�� ������ ��, travelUI ����� ������ ��ġ
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
