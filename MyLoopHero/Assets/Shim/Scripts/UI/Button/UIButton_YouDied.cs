using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIButton_YouDied : UIButton
{
    private string sceneName;

    protected override void Awake()
    {
        // button 이라는 GameObject는 이 스크립트를 상속할 스크립트를 가진 오브젝트이다.
        button = this.gameObject;

        // buttonText 에 button 하위의 TMP_Text 컴포넌트를 가진 오브젝트를 담는다.
        buttonText = button.GetComponentInChildren<TMP_Text>();

        sceneName = SceneManager.GetActiveScene().name;
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

        //if (UnityEditor.EditorApplication.isPlaying == true)
        //{
        //    UnityEditor.EditorApplication.isPlaying = false;
        //}
        //else
        //{
            Application.Quit();
        //}
    }
}
