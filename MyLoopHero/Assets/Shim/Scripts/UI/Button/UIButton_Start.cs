using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButton_Start : UIButton
{
    private GameObject titleWindow;
    private Vector2 titleWindowMovePosition;


    protected override void Awake()
    {
        // button �̶�� GameObject�� �� ��ũ��Ʈ�� ����� ��ũ��Ʈ�� ���� ������Ʈ�̴�.
        button = this.gameObject;
        // buttonText �� button ������ TMP_Text ������Ʈ�� ���� ������Ʈ�� ��´�.
        buttonText = button.GetComponentInChildren<TMP_Text>();


        // titleWindow
        titleWindow = GameObject.Find("TravelWindow").gameObject;

        // start ��ư�� ������ ��, titleWindow �� ������ ��ġ
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
