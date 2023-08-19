using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButton_Start : UIButton
{
    private GameObject title;
    private GameObject campsite;
    private Vector2 titleSceneMovePosition;
    private Vector2 campsiteSceneMovePosition;


    protected override void Awake()
    {
        // button �̶�� GameObject�� �� ��ũ��Ʈ�� ����� ��ũ��Ʈ�� ���� ������Ʈ�̴�.
        button = this.gameObject;

        // buttonText �� button ������ TMP_Text ������Ʈ�� ���� ������Ʈ�� ��´�.
        buttonText = button.GetComponentInChildren<TMP_Text>();

        // title
        title = button.transform.root.GetChild(0).gameObject;
        // campsite
        campsite= button.transform.root.GetChild(1).gameObject;
        // ��ư�� ������ ��, title ����� ������ ��ġ
        titleSceneMovePosition = new Vector2(0f, 2000f);
        // ��ư�� ������ ��, campsite ����� ������ ��ġ
        campsiteSceneMovePosition = new Vector2(0f, 0f);
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
        campsite.GetComponent<RectTransform>().anchoredPosition = campsiteSceneMovePosition;
    }
}
