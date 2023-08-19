using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIButton_Boss : UIButton
{
    public Sprite bossSprite_0;
    public Sprite bossSprite_1;

    protected override void Awake()
    {
        // button �̶�� GameObject�� �� ��ũ��Ʈ�� ����� ��ũ��Ʈ�� ���� ������Ʈ�̴�.
        button = this.gameObject;

        // buttonText �� button ������ TMP_Text ������Ʈ�� ���� ������Ʈ�� ��´�.
        buttonText = button.GetComponentInChildren<TMP_Text>();

        isPress = false;

        bossSprite_0 = button.GetComponentInChildren<Image>().sprite;
        bossSprite_1 = button.GetComponentInChildren<Image>().sprite;
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
        if (isPress == true)
        {
            /*Do Nothing*/
        }
        else if (isPress == false)
        {
            MakeHighlightState();
        }
    }

    protected override void DoPointerExit(PointerEventData eventData)
    {
        if (isPress == true)
        {
            /*Do Nothing*/
        }
        else if (isPress == false)
        {
            MakeBaseState();
        }
    }

    protected override void DoPointerDown(PointerEventData eventData)
    {
        if (isPress == true)
        {
            /*Do Nothing*/
        }
        else if (isPress == false)
        {
            MakePressState();
        }
    }

    protected override void DoPointerUp(PointerEventData eventData)
    {
        if (isPress == true)
        {
            /*Do Nothing*/
        }
        else if (isPress == false)
        {
            MakePressState();
            isPress = true;
        }
    }
}
