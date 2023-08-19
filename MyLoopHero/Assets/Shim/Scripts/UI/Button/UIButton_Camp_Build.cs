using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIButton_Camp_Build : UIButton
{
    private GameObject buildWindow;
    private Vector2 windowMovePosition;
    private Vector2 windowReturnPosition;

    protected override void Awake()
    {
        base.Awake();
        // button �̶�� GameObject�� �� ��ũ��Ʈ�� ����� ��ũ��Ʈ�� ���� ������Ʈ�̴�.
        button = this.gameObject;

        // buttonText �� button ������ TMP_Text ������Ʈ�� ���� ������Ʈ�� ��´�.
        buttonText = button.GetComponentInChildren<TMP_Text>();

        isPress = false;

        // travelWindow
        buildWindow = button.transform.parent.GetChild(3).gameObject;
        // ��ư�� ������ ��, travelWindow �� �̵��� ��ġ
        windowMovePosition = new Vector2(-636f, 0f);
        // ��ư�� ������ ��, travelWindow �� ���ư� ��ġ
        windowReturnPosition = new Vector2(-636f, -1000f);
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
        buttonText.color = goldColor;
    }

    protected override void DoPointerEnter(PointerEventData eventData)
    {
        if (isPressTravel == false)
        {
            if (isPressBuild == true)
            {
                /*Do Nothing*/
            }
            else if (isPressBuild == false)
            {
                MakeHighlightState();
            }
        }
        else if (isPressTravel == true)
        {
            MakeBaseState();
        }
    }

    protected override void DoPointerExit(PointerEventData eventData)
    {
        if (isPressTravel == false)
        {
            if (isPressBuild == true)
            {
                /*Do Nothing*/
            }
            else if (isPressBuild == false)
            {
                MakeBaseState();
            }
        }
        else if (isPressTravel == true)
        {
            MakeBaseState();
        }
    }

    protected override void DoPointerDown(PointerEventData eventData)
    {
        if (isPressTravel == false)
        {
            if (isPressBuild == true)
            {
                MakeBaseState();
                buildWindow.GetComponent<RectTransform>().anchoredPosition = windowReturnPosition;
            }
            else if (isPressBuild == false)
            {
                MakePressState();
                buildWindow.GetComponent<RectTransform>().anchoredPosition = windowMovePosition;
            }
        }
        else if (isPressTravel == true)
        {
            MakeBaseState();
        }
    }

    protected override void DoPointerUp(PointerEventData eventData)
    {
        if (isPressTravel == false)
        {
            if (isPressBuild == true)
            {
                isPressBuild = false;
                MakeHighlightState();
            }
            else if (isPressBuild == false)
            {
                isPressBuild = true;
            }
        }
        else if (isPressTravel == true) 
        {
            MakeBaseState();
        }
    }
}
