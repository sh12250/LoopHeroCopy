using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButton_Exit : UIButton
{
    private GameObject window;
    private Vector2 windowMovePosition;
    private Vector2 windowReturnPosition;

    protected override void Awake()
    {
        // button �̶�� GameObject�� �� ��ũ��Ʈ�� ����� ��ũ��Ʈ�� ���� ������Ʈ�̴�.
        button = this.gameObject;

        // buttonText �� button ������ TMP_Text ������Ʈ�� ���� ������Ʈ�� ��´�.
        buttonText = button.GetComponentInChildren<TMP_Text>();

        window = button.transform.parent.gameObject;
        // ��ư�� ������ ��, travelWindow �� �̵��� ��ġ
        windowMovePosition = new Vector2(0f, 0f);
        // ��ư�� ������ ��, travelWindow �� ���ư� ��ġ
        windowReturnPosition = new Vector2(0f, -1000f);
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

        if (UnityEditor.EditorApplication.isPlaying == true) 
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else 
        {
            Application.Quit();
        }
    }
}
