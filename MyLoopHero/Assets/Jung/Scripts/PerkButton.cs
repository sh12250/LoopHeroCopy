using UnityEngine;
using UnityEngine.UI;

public class PerkButton : MonoBehaviour
{
    public Sprite perkOffSprite;
    public Sprite perkOnSprite;

    private GameObject perkWindowObject;
    public PerkWindow perkWindow;

    void Start()
    {
        perkWindowObject = GameObject.Find("PerkWindow").gameObject;
    }

    void Update()
    {
        ChangeSprite();
    }

    public void OpenPerkWindow()
    {
        perkWindow.OpenWindow();
    }

    private void ChangeSprite() 
    {
        if (perkWindowObject.GetComponent<PerkWindow>().perkCnt > 0) 
        {
            gameObject.transform.GetComponent<Image>().sprite = perkOnSprite;
        }
        else if (perkWindowObject.GetComponent<PerkWindow>().perkCnt <= 0) 
        {
            gameObject.transform.GetComponent<Image>().sprite = perkOffSprite;
        }
    }
}
