using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIButton_Camp_Travel : UIButton
{
    private GameObject travelWindow;
    private Vector2 windowMovePosition;
    private Vector2 windowReturnPosition;

    protected override void Awake()
    {
        base.Awake();
        // button 이라는 GameObject는 이 스크립트를 상속할 스크립트를 가진 오브젝트이다.
        button = this.gameObject;

        // buttonText 에 button 하위의 TMP_Text 컴포넌트를 가진 오브젝트를 담는다.
        buttonText = button.GetComponentInChildren<TMP_Text>();

        // travelWindow
        travelWindow = button.transform.parent.GetChild(1).gameObject;
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
        if (isPressBuild == false) 
        {
            if (isPressTravel == true)
            {
                /*Do Nothing*/
            }
            else if (isPressTravel == false)
            {
                MakeHighlightState();
            }
        }
        else if (isPressBuild == true)
        {
            MakeBaseState();
        }
    }

    protected override void DoPointerExit(PointerEventData eventData)
    {
        if (isPressBuild == false)
        {
            if (isPressTravel == true)
            {
                /*Do Nothing*/
            }
            else if (isPressTravel == false)
            {
                MakeBaseState();
            }
        }
        else if (isPressBuild == true)
        {
            MakeBaseState();
        }
    }

    protected override void DoPointerDown(PointerEventData eventData)
    {
        if (isPressBuild == false)
        {
            if (isPressTravel == true)
            {
                MakeBaseState();
                travelWindow.GetComponent<RectTransform>().anchoredPosition = windowReturnPosition;
            }
            else if (isPressTravel == false)
            {
                MakePressState();
                travelWindow.GetComponent<RectTransform>().anchoredPosition = windowMovePosition;
            }
        }
        else if (isPressBuild == true)
        {
            MakeBaseState();
        }
    }

    protected override void DoPointerUp(PointerEventData eventData)
    {
        if (isPressBuild == false)
        {
            if (isPressTravel == true)
            {
                isPressTravel = false;
                MakeHighlightState();
            }
            else if (isPressTravel == false)
            {
                isPressTravel = true;
            }
        }
        else if (isPressBuild == true) 
        {
            MakeBaseState();
        }
    }
}
