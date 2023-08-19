using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TitleScene : MonoBehaviour
{
    private GameObject titleScene;
    private GameObject titleLogo;
    private GameObject titleMenu;


    private void Awake()
    {
        MakeTitleSceneArray();
        InitializeColorAndLocation();

        #region DEBUG
        //Debug.Log(titleLogo.localPosition.y);
        //Debug.Log(titleLogo.position.y);
        //Debug.Log(titleLogo.anchoredPosition.y);
        #endregion
    }

    void Start()
    {
        StartCoroutine(CoroutineSequence());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            StopAllCoroutines();
            SkipIntro();
        }
    }

    #region FindingTitleSceneChildren
    private void MakeTitleSceneArray()
    {
        // titleScene �� �� ��ũ��Ʈ�� ��� �ִ� ���� ������Ʈ�̴�.
        titleScene = this.gameObject;

        #region Legacy
        //// titleScene ����(1����)�� �ִ� ��� �ڽ� ������Ʈ�� titleSceneChildren �� ��´�.
        //// titleSceneChildren �迭�� ũ��� titleScene �� �ڽ� ������Ʈ�� ���̴�.
        //titleSceneChildren = new GameObject[titleScene.transform.childCount];

        //// for ���� ���� titleSceneChildren �迭 �ϳ����� ���� GetChild �Լ��� ���� ���� ������Ʈ�� �����Ѵ�.
        //for (int i = 0; i < titleScene.transform.childCount; i++)
        //{
        //    titleSceneChildren[i] = gameObject.transform.GetChild(i).gameObject;
        //}
        #endregion

        titleMenu = gameObject.transform.GetChild(0).gameObject;
        titleLogo = gameObject.transform.GetChild(1).gameObject;

    }
    #endregion


    #region InitializeColorAndLocation
    private void InitializeColorAndLocation()
    {
        // titleScene ���� Image ������Ʈ�� ������ ����(0,0,0,1)���� �ٲ۴�.
        titleScene.GetComponent<Image>().color = Color.black;
        // titleSceneChildren[1] => Title_Logo �� Image ������Ʈ ������ ����(0,0,0,0)���� �ٲ۴�.
        titleLogo.GetComponent<Image>().color = Color.clear;
        //titleSceneChildren[1].GetComponent<Image>().color = Color.clear;

        #region Legacy
        //// Title_Logo �� ��ġ�� ������ titleLogo ������ RectTransform �� ���·� ��ȯ�� �����Ѵ�.
        //titleLogo = (RectTransform)titleSceneChildren[1].transform;
        //// Title_Menu �� ��ġ�� ������ titleMenu ������ RectTransform �� ���·� ��ȯ�� �����Ѵ�.
        //titleMenu = (RectTransform)titleSceneChildren[0].transform;
        #endregion
    }
    #endregion


    #region CoroutineSequence for TitleScene
    IEnumerator CoroutineSequence()
    {
        // FadeinBackground coroutine �� 1������ �����Ѵ�.
        yield return StartCoroutine(FadeinBackground(0f));
        // FadeinBackground coroutine ������ ���� ��, FadeinLogo coroutine �� �����Ѵ�.
        yield return StartCoroutine(FadeinLogo(0f));
        // FadeinLogo coroutine ������ ���� �� MoveLogo, MoveMenu coroutine �� ���ÿ� �����Ѵ�.
        StartCoroutine(MoveLogo(titleLogo.GetComponent<RectTransform>().anchoredPosition.y));
        StartCoroutine(MoveMenu(titleMenu.GetComponent<RectTransform>().anchoredPosition.y));
    }
    #endregion


    #region FadeInBackground
    IEnumerator FadeinBackground(float startColorValue_)    // �ʱ� ���� ���� �Ű������� �޴´�.
    {
        // { ����
        while (true) 
        {
            // startColorValue_ �� ���� 1 ���Ͽ����� if ������ ���´�.
            if (startColorValue_ <= 1)
            {
                // yield return ���� : WaitForSecondsRealtime(0.1f)
                // �����ð� 0.1�� ��ŭ ����Ƽ�� �ֵ����� �Ѱ��ش�.
                // TODO : new WaitForSecondsRealtime�� 4���̳� ȣ���ϰ� �ֱ⶧���� ���߿� caching�� �����صд�.
                yield return new WaitForSecondsRealtime(0.1f);
                // Title �� Image ������Ʈ(���ȭ��)�� ���� ������ �ٲ��. 
                titleScene.GetComponent<Image>().color =
                    new Color(startColorValue_, startColorValue_, startColorValue_);
                // startColorValue_ ������ ����ؼ� 0.03f �� �����ش�.
                startColorValue_ += 0.03f;
            }
            // startColorValue_ �� ���� 1 �ʰ���� else ������ ���´�.
            else
            {
                // Ȯ���ϰ� �ڷ�ƾ�� ������ ���ؼ� yield break �� ����Ѵ�.
                yield break;
            }
        }
        // } ����
    }
    #endregion


    #region FadeInBackground2
    //IEnumerator FadeinBackground()
    //{
    //    float colorVal = 0f;
    //    float time = 0.02f;
    //    while (time <= 1)
    //    {
    //        colorVal = Mathf.Lerp(0f, 1, time);
    //        Debug.LogFormat("{0}", colorVal);
    //        Debug.LogFormat("{0}", 1);
    //        yield return new WaitForSeconds(0.2f);
    //        titleScene.GetComponent<Image>().color = new Color(colorVal, colorVal, colorVal);
    //        time += 0.03f;
    //    }
    //}
    #endregion
    #region LEGACY
    //IEnumerator FadeinBackground()
    //{
    //    float colorVal = 0f;
    //    float time = 0.02f;
    //    while (time <= 1)
    //    {
    //        colorVal = Mathf.Lerp(0f, 1, time);
    //        Debug.LogFormat("{0}", colorVal);
    //        Debug.LogFormat("{0}", 1);
    //        yield return new WaitForSeconds(0.2f);
    //        titleScene.GetComponent<Image>().color = new Color(colorVal, colorVal, colorVal);
    //        time += 0.03f;
    //    }
    //}
    #endregion


    #region FadeInLogo
    IEnumerator FadeinLogo(float startAlphaValue_)
    {
        while (true)
        {
            if (startAlphaValue_ <= 1)
            {
                yield return new WaitForSecondsRealtime(0.1f);
                titleLogo.GetComponent<Image>().color =
                    new Color(1, 1, 1, startAlphaValue_);
                startAlphaValue_ += 0.06f;
            }
            else
            {
                yield break;
            }
        }
    }
    #endregion


    #region MoveLogo
    IEnumerator MoveLogo(float titleLogoCurrentY_)
    {
        while (true) 
        {
            // anchored position �� ���� �ȵ� �����ѹ��� ��
            if(titleLogoCurrentY_ <= 40f)
            {
                yield return new WaitForSecondsRealtime(0.05f);
                titleLogo.GetComponent<RectTransform>().anchoredPosition =
                    new Vector2(titleLogo.GetComponent<RectTransform>().anchoredPosition.x, titleLogoCurrentY_);
                titleLogoCurrentY_ += 8f;
            }
            else 
            {
                yield break;
            }
        }
    }
    #endregion


    #region MoveMenu
    IEnumerator MoveMenu(float titleMenuCurrentY_)
    {
        while (true)
        {
            if (titleMenuCurrentY_ >= 0f)
            {
                yield return new WaitForSecondsRealtime(0.04f);
                titleMenu.GetComponent<RectTransform>().anchoredPosition =
                    new Vector2(titleMenu.GetComponent<RectTransform>().anchoredPosition.x, titleMenuCurrentY_);
                titleMenuCurrentY_ -= 20f;
            }
            else
            {
                yield break;
            }
        }
    }
    #endregion


    #region SkipIntroAnimation
    private void SkipIntro() 
    {
        // ��� ����̹����� color �� (1,1,1,1) �� �����Ѵ�.
        titleScene.GetComponent<Image>().color = Color.white;
        // ��� �ΰ��� color �� (1,1,1,1) �� �����Ѵ�.
        titleLogo.GetComponent<Image>().color = Color.white;

        // ��� �޴��� ��ġ�� 
        titleMenu.GetComponent<RectTransform>().anchoredPosition =
            new Vector2(0f, 7f);
        // 
        titleLogo.GetComponent<RectTransform>().anchoredPosition =
            new Vector2(0f, 39f);
    }
    #endregion
}
