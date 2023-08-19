using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIButton_Menu : UIButton
{
    private GameObject menu;
    private GameObject logo;


    protected override void Awake()
    {
        base.Awake();
        // button 이라는 GameObject는 이 스크립트를 상속할 스크립트를 가진 오브젝트이다.
        button = this.gameObject;

        // buttonText 에 button 하위의 TMP_Text 컴포넌트를 가진 오브젝트를 담는다.
        buttonText = button.GetComponentInChildren<TMP_Text>();

        // campMenu
        menu = button.transform.parent.GetChild(5).gameObject;
        // campLogo
        logo = button.transform.parent.GetChild(6).gameObject;
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
        buttonText.color = Color.grey;
    }

    protected override void DoPointerEnter(PointerEventData eventData)
    {
        if (isPressMenu == true)
        {
            /*Do Nothing*/
        }
        else if (isPressMenu == false)
        {
            MakeHighlightState();
        }
    }

    protected override void DoPointerExit(PointerEventData eventData)
    {
        if (isPressMenu == true)
        {
            /*Do Nothing*/
        }
        else if (isPressMenu == false)
        {
            MakeBaseState();
        }
    }

    protected override void DoPointerDown(PointerEventData eventData)
    {
        if (isPressMenu == true)
        {
            /*Do Nothing*/
        }
        else if (isPressMenu == false)
        {
            MakePressState();
        }
    }

    protected override void DoPointerUp(PointerEventData eventData)
    {
        if (isPressMenu == true)
        {
            MakeBaseState();
        }
        else if (isPressMenu == false)
        {
            StartCoroutine(PlayAnimation());
            MakeBaseState();
            isPressMenu = true;
        }
    }

    #region AnimationCoroutine
    IEnumerator PlayAnimation()
    {
        StartCoroutine(MoveMenu(menu.GetComponent<RectTransform>().anchoredPosition.y));
        StartCoroutine(MoveLogo(logo.GetComponent<RectTransform>().anchoredPosition.y));
        yield break;
    }

    IEnumerator MoveMenu(float campMenuCurrentY_)
    {
        while (true)
        {
            if (campMenuCurrentY_ >= 0f)
            {
                yield return new WaitForSecondsRealtime(0.03f);
                menu.GetComponent<RectTransform>().anchoredPosition =
                    new Vector2(menu.GetComponent<RectTransform>().anchoredPosition.x, campMenuCurrentY_);
                campMenuCurrentY_ -= 30f;
            }
            else
            {
                yield break;
            }
        }
    }

    IEnumerator MoveLogo(float campLogoCurrentY_)
    {
        while (true)
        {
            if (campLogoCurrentY_ >= 180f)
            {
                yield return new WaitForSecondsRealtime(0.04f);
                logo.GetComponent<RectTransform>().anchoredPosition =
                    new Vector2(logo.GetComponent<RectTransform>().anchoredPosition.x, campLogoCurrentY_);
                campLogoCurrentY_ -= 20f;
            }
            else
            {
                yield break;
            }
        }
    }
    #endregion
}
