using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButton_Class : UIButton
{
    private GameObject travelWindow;
    private GameObject heroPortraitOff;
    private GameObject heroPortraitOn;
    private GameObject hide;

    protected override void Awake()
    {
        // button 이라는 GameObject는 이 스크립트를 상속할 스크립트를 가진 오브젝트이다.
        button = this.gameObject;

        // buttonText 에 button 하위의 TMP_Text 컴포넌트를 가진 오브젝트를 담는다.
        buttonText = button.GetComponentInChildren<TMP_Text>();

        isPress = false;

        travelWindow = GameObject.Find("TravelWindow").gameObject;
        heroPortraitOff = button.transform.GetChild(1).gameObject;
        heroPortraitOn = button.transform.GetChild(2).gameObject;
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

        if (isPress == false)
        {
            isPress = true;
            travelWindow.GetComponent<TravelWindow>().isClassPress = true;

            heroPortraitOff.SetActive(false);
            heroPortraitOn.SetActive(true);
        }
        else if (isPress == true)
        {
            isPress = false;
            travelWindow.GetComponent<TravelWindow>().isClassPress = false;

            heroPortraitOff.SetActive(true);
            heroPortraitOn.SetActive(false);
        }
    }
}
