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
        // button 이라는 GameObject는 이 스크립트를 상속할 스크립트를 가진 오브젝트이다.
        button = this.gameObject;

        // buttonText 에 button 하위의 TMP_Text 컴포넌트를 가진 오브젝트를 담는다.
        buttonText = button.GetComponentInChildren<TMP_Text>();

        isPress = false;

        // travelWindow
        buildWindow = button.transform.parent.GetChild(3).gameObject;
        // 버튼을 눌렀을 때, travelWindow 가 이동할 위치
        windowMovePosition = new Vector2(-636f, 0f);
        // 버튼을 눌렀을 때, travelWindow 가 돌아갈 위치
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
