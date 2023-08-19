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
        // titleScene 은 이 스크립트를 들고 있는 게임 오브젝트이다.
        titleScene = this.gameObject;

        #region Legacy
        //// titleScene 하위(1위계)에 있는 모든 자식 오브젝트를 titleSceneChildren 에 담는다.
        //// titleSceneChildren 배열의 크기는 titleScene 의 자식 오브젝트의 수이다.
        //titleSceneChildren = new GameObject[titleScene.transform.childCount];

        //// for 문을 통해 titleSceneChildren 배열 하나마다 직접 GetChild 함수를 통해 얻은 오브젝트를 대입한다.
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
        // titleScene 에서 Image 컴포넌트의 색상을 검정(0,0,0,1)으로 바꾼다.
        titleScene.GetComponent<Image>().color = Color.black;
        // titleSceneChildren[1] => Title_Logo 의 Image 컴포넌트 색상을 투명(0,0,0,0)으로 바꾼다.
        titleLogo.GetComponent<Image>().color = Color.clear;
        //titleSceneChildren[1].GetComponent<Image>().color = Color.clear;

        #region Legacy
        //// Title_Logo 의 위치를 저장할 titleLogo 변수를 RectTransform 의 형태로 변환해 저장한다.
        //titleLogo = (RectTransform)titleSceneChildren[1].transform;
        //// Title_Menu 의 위치를 저장할 titleMenu 변수를 RectTransform 의 형태로 변환해 저장한다.
        //titleMenu = (RectTransform)titleSceneChildren[0].transform;
        #endregion
    }
    #endregion


    #region CoroutineSequence for TitleScene
    IEnumerator CoroutineSequence()
    {
        // FadeinBackground coroutine 을 1번으로 실행한다.
        yield return StartCoroutine(FadeinBackground(0f));
        // FadeinBackground coroutine 실행이 끝난 후, FadeinLogo coroutine 을 실행한다.
        yield return StartCoroutine(FadeinLogo(0f));
        // FadeinLogo coroutine 실행이 끝난 후 MoveLogo, MoveMenu coroutine 을 동시에 실행한다.
        StartCoroutine(MoveLogo(titleLogo.GetComponent<RectTransform>().anchoredPosition.y));
        StartCoroutine(MoveMenu(titleMenu.GetComponent<RectTransform>().anchoredPosition.y));
    }
    #endregion


    #region FadeInBackground
    IEnumerator FadeinBackground(float startColorValue_)    // 초기 색상 값을 매개변수로 받는다.
    {
        // { 루프
        while (true) 
        {
            // startColorValue_ 의 값이 1 이하에서만 if 문으로 들어온다.
            if (startColorValue_ <= 1)
            {
                // yield return 조건 : WaitForSecondsRealtime(0.1f)
                // 실제시간 0.1초 만큼 유니티에 주도권을 넘겨준다.
                // TODO : new WaitForSecondsRealtime을 4번이나 호출하고 있기때문에 나중에 caching을 염두해둔다.
                yield return new WaitForSecondsRealtime(0.1f);
                // Title 의 Image 컴포넌트(배경화면)가 다음 값으로 바뀐다. 
                titleScene.GetComponent<Image>().color =
                    new Color(startColorValue_, startColorValue_, startColorValue_);
                // startColorValue_ 변수에 계속해서 0.03f 를 더해준다.
                startColorValue_ += 0.03f;
            }
            // startColorValue_ 의 값이 1 초과라면 else 문으로 들어온다.
            else
            {
                // 확실하게 코루틴을 끝내기 위해서 yield break 를 사용한다.
                yield break;
            }
        }
        // } 루프
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
            // anchored position 이 말을 안들어서 매직넘버가 들어감
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
        // 즉시 배경이미지의 color 를 (1,1,1,1) 로 세팅한다.
        titleScene.GetComponent<Image>().color = Color.white;
        // 즉시 로고의 color 를 (1,1,1,1) 로 세팅한다.
        titleLogo.GetComponent<Image>().color = Color.white;

        // 즉시 메뉴의 위치를 
        titleMenu.GetComponent<RectTransform>().anchoredPosition =
            new Vector2(0f, 7f);
        // 
        titleLogo.GetComponent<RectTransform>().anchoredPosition =
            new Vector2(0f, 39f);
    }
    #endregion
}
