using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelWindow : MonoBehaviour
{
    private GameObject departureButton;
    private GameObject hide;
    public bool isBossPress;
    public bool isClassPress;

    private void Awake()
    {
        departureButton = GameObject.Find("TravelWindow_DepartureButton").gameObject;
        departureButton.SetActive(false);
        hide = GameObject.Find("HideButton").gameObject;
        isBossPress = false;
        isClassPress = false;
    }

    void Update() 
    {
        CheckButtons();
    }

    private void CheckButtons() 
    {
        if (isBossPress == true && isClassPress == true) 
        {
            departureButton.SetActive(true);
            hide.SetActive(false);
        }
        else 
        {
            departureButton.SetActive(false);
            hide.SetActive(true);
        }
    }
}
