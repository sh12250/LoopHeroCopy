using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class UIButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    // { ��ư �ʵ�
    
    // �� ��ũ��Ʈ�� ����� ��ũ��Ʈ�� ����ִ� GameObject
    protected GameObject button;
    // �⺻ ��������Ʈ
    public Sprite baseSprite;
    // ���콺 Enter �� ���� ��������Ʈ
    public Sprite hoverSprite;
    // ���콺 Down �� ��ȭ ��������Ʈ
    public Sprite pressSprite;
    // �� ��ũ��Ʈ�� ����� ��ũ��Ʈ�� ����ִ� ��ư�� GameObject�� �ڽ� ������Ʈ�� TMP_Text
    protected TMP_Text buttonText;
    // �ݻ� Color ���� ����
    protected Color goldColor;
    public bool isPress;

    // ���ȴ��� ���θ� üũ�� bool
    protected static bool isPressMenu;
    protected static bool isPressTravel;
    protected static bool isPressBuild;

    // } ��ư �ʵ�


    protected virtual void Awake()
    {
        // goldColor
        ColorUtility.TryParseHtmlString("#CD853F", out goldColor);
    }


    // { ��ư ��� ����� ���� ����
    // OnPointer �Լ��� ���� ������ DoPointer �Լ��� �����ؼ� �����Ѵ�.
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
    // } ��ư ��� ����� ���� ����

    protected virtual void DoPointerEnter(PointerEventData eventData)
    {
        /* Override �޾Ƽ� ����Ѵ�. */

        // �������� image_�� �� ��ũ��Ʈ�� ����� ��ũ��Ʈ�� ��� �ִ� ������Ʈ�� Image ������Ʈ�� ��´�.
        Image image_ = GetComponent<Image>();
        // ��ư�� �̹����� hoverSprite �� �����Ѵ�.
        image_.sprite = hoverSprite;
        // ��ư ���� TMP_Text �� ������ ������� �����Ѵ�.
        buttonText.color = Color.white;

        #region Legacy
        //if (isPressed == false) 
        //{
        //    image_.sprite = hoverSprite;
        //    buttonText.color = Color.white;
        //}
        //else if (isPressed == true)
        //{
        //    // ��ư�� �̹����� hoverPressSprite �� �����Ѵ�.
        //    image_.sprite = hoverPressSprite;
        //    // ��ư ���� TMP_Text �� ������ ȸ������ �����Ѵ�.
        //    buttonText.color = Color.grey;
        //}
        #endregion
    }

    protected virtual void DoPointerExit(PointerEventData eventData)
    {
        /* Override �޾Ƽ� ����Ѵ�. */

        Image image = GetComponent<Image>();
        image.sprite = baseSprite;
        buttonText.color = Color.white;
    }

    protected virtual void DoPointerDown(PointerEventData eventData)
    {
        /* Override �޾Ƽ� ����Ѵ�. */

        Image image = GetComponent<Image>();
        image.sprite = pressSprite;
        buttonText.color = Color.grey;
    }

    protected virtual void DoPointerUp(PointerEventData eventData)
    {
        /* Override �޾Ƽ� ����Ѵ�. */

        Image image = GetComponent<Image>();
        image.sprite = hoverSprite;
        buttonText.color = Color.white;
    }
}
