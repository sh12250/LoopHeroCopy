using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    // { 버튼 필드
    
    // 이 스크립트를 상속할 스크립트가 들어있는 GameObject
    protected GameObject button;
    // 기본 스프라이트
    public Sprite baseSprite;
    // 마우스 Enter 시 강조 스프라이트
    public Sprite hoverSprite;
    // 마우스 Down 시 변화 스프라이트
    public Sprite pressSprite;
    // 이 스크립트를 상속할 스크립트를 들고있는 버튼의 GameObject의 자식 오브젝트의 TMP_Text
    protected TMP_Text buttonText;
    // 금색 Color 담을 변수
    protected Color goldColor;
    public bool isPress;

    // 눌렸는지 여부를 체크할 bool
    protected static bool isPressMenu;
    protected static bool isPressTravel;
    protected static bool isPressBuild;




    // } 버튼 필드


    protected virtual void Awake()
    {
        // goldColor
        ColorUtility.TryParseHtmlString("#CD853F", out goldColor);
    }


    // { 버튼 기능 상속을 위한 세팅
    // OnPointer 함수를 내가 정의한 DoPointer 함수로 변경해서 실행한다.
    public void OnPointerEnter(PointerEventData eventData)
    {
        this.DoPointerEnter(eventData);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.DoPointerExit(eventData);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        this.DoPointerDown(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        this.DoPointerUp(eventData);
    }
    // } 버튼 기능 상속을 위한 세팅

    protected virtual void DoPointerEnter(PointerEventData eventData)
    {
        /* Override 받아서 사용한다. */

        // 지역변수 image_에 이 스크립트를 상속할 스크립트를 들고 있는 오브젝트의 Image 컴포넌트를 담는다.
        Image image_ = GetComponent<Image>();
        // 버튼의 이미지를 hoverSprite 로 변경한다.
        image_.sprite = hoverSprite;
        // 버튼 하위 TMP_Text 의 색상을 흰색으로 변경한다.
        buttonText.color = Color.white;

        #region Legacy
        //if (isPressed == false) 
        //{
        //    image_.sprite = hoverSprite;
        //    buttonText.color = Color.white;
        //}
        //else if (isPressed == true)
        //{
        //    // 버튼의 이미지를 hoverPressSprite 로 변경한다.
        //    image_.sprite = hoverPressSprite;
        //    // 버튼 하위 TMP_Text 의 색상을 회색으로 변경한다.
        //    buttonText.color = Color.grey;
        //}
        #endregion
    }

    protected virtual void DoPointerExit(PointerEventData eventData)
    {
        /* Override 받아서 사용한다. */

        Image image = GetComponent<Image>();
        image.sprite = baseSprite;
        buttonText.color = Color.white;
    }

    protected virtual void DoPointerDown(PointerEventData eventData)
    {
        /* Override 받아서 사용한다. */

        Image image = GetComponent<Image>();
        image.sprite = pressSprite;
        buttonText.color = Color.grey;
    }

    protected virtual void DoPointerUp(PointerEventData eventData)
    {
        /* Override 받아서 사용한다. */

        Image image = GetComponent<Image>();
        image.sprite = hoverSprite;
        buttonText.color = Color.white;
    }
}
