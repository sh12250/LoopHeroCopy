using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIButton_YouDied : UIButton
{
    private string sceneName;

    protected override void Awake()
    {
        // button �̶�� GameObject�� �� ��ũ��Ʈ�� ����� ��ũ��Ʈ�� ���� ������Ʈ�̴�.
        button = this.gameObject;

        // buttonText �� button ������ TMP_Text ������Ʈ�� ���� ������Ʈ�� ��´�.
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
