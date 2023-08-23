using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIButton_Exit : UIButton
{
    private GameObject window;
    private Vector2 windowMovePosition;
    private Vector2 windowReturnPosition;

    protected override void Awake()
    {
        // button 이라는 GameObject는 이 스크립트를 상속할 스크립트를 가진 오브젝트이다.
        button = this.gameObject;

        // buttonText 에 button 하위의 TMP_Text 컴포넌트를 가진 오브젝트를 담는다.
        buttonText = button.GetComponentInChildren<TMP_Text>();

        window = button.transform.parent.gameObject;
        // 버튼을 눌렀을 때, travelWindow 가 이동할 위치
        windowMovePosition = new Vector2(0f, 0f);
        // 버튼을 눌렀을 때, travelWindow 가 돌아갈 위치
        windowReturnPosition = new Vector2(0f, -1000f);
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

        if (UnityEditor.EditorApplication.isPlaying == true) 
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else 
        {
            Application.Quit();
        }
    }
}
