using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    private static CardManager instance;

    [SerializeField]
    private GameObject roadCardBase;
    // 길 베이스
    [SerializeField]
    private GameObject sideCardBase;
    // 길가 베이스
    [SerializeField]
    private GameObject etcCardBase;
    // 그외 베이스
    [SerializeField]
    private GameObject mightCardBase;
    // 망각 전용 베이스

    #region 카드 이미지
    /// <summary>
    /// 0:  망각, 
    /// 1:  묘지, 
    /// 2:  마을, 
    /// 3:  수풀, 
    /// 4:  밀밭, 
    /// 5:  거미고치, 
    /// 6:  흡혈귀 저택, 
    /// 7:  전장, 
    /// 8:  등대, 
    /// 9:  바위, 
    /// 10: 산, 
    /// 11: 피투성이 수풀, 
    /// 12: 가로등, 
    /// 13: 늪, 
    /// 14: 금고, 
    /// 15: 목초지
    /// </summary>
    #endregion // 카드 이미지
    public Sprite[] faceSprites;

    private void Awake()
    {
        if (instance == null || instance == default)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("CardManager가 너무 많습니다");
        }
    }

    void Start()
    {

    }

    void Update()
    {

    }
}
