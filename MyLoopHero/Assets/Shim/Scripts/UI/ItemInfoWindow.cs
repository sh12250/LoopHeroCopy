using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemInfoWindow : MonoBehaviour
{
    private GameObject itemInfoWindow;
    private GameObject ui_Inventory;
    private TMP_Text itemName;
    private TMP_Text itemOption1;
    private TMP_Text itemOption2;
    private TMP_Text itemOption3;
    private TMP_Text itemOption4;


    private void Awake()
    {
        itemInfoWindow = this.gameObject;
        itemName = gameObject.transform.GetChild(1).GetComponent<TMP_Text>();
        itemOption1 = gameObject.transform.GetChild(2).GetComponent<TMP_Text>();
        itemOption2 = gameObject.transform.GetChild(3).GetComponent<TMP_Text>();
        itemOption3 = gameObject.transform.GetChild(4).GetComponent<TMP_Text>();
        itemOption4 = gameObject.transform.GetChild(5).GetComponent<TMP_Text>();

        ui_Inventory = GameObject.Find("Canvas_HUD_Inventory").gameObject;
    }

    public void ShowItemInfo() 
    {

    }

    public void FollowRectLocation() 
    {
        itemInfoWindow.GetComponent<RectTransform>().anchoredPosition =
            ui_Inventory.GetComponent<UI_Inventory>().rectHolding.anchoredPosition;
    }

    public void OpenItemWindow() 
    {
        itemInfoWindow.transform.localScale = Vector3.one;
    }

    public void CloseItemWindow() 
    {
        itemInfoWindow.transform.localScale = Vector3.zero;
    }
}
