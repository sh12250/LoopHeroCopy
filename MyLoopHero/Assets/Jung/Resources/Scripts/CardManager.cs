using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;

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

    // 랜덤 카드 생성
    public GameObject MakeCard()
    {
        int randNum = Random.Range(0, 100);

        GameObject theTile_ = default;

        Transform parent_ = HandManager.instance.GetHandTransform();

        if (randNum >= 0 && randNum < 4)
        {   // 망각
            theTile_ = Instantiate(mightCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[0];
        }
        else if (randNum >= 4 && randNum < 12)
        {   // 금고
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[14];
        }
        else if (randNum >= 12 && randNum < 20)
        {   // 등대
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[8];
        }
        else if (randNum >= 20 && randNum < 32)
        {   // 바위
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[9];
        }
        else if (randNum >= 32 && randNum < 42)
        {   // 산
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[10];
        }
        else if (randNum >= 42 && randNum < 52)
        {   // 목초지
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[15];
        }
        else if (randNum >= 52 && randNum < 60)
        {   // 묘지
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[1];
        }
        else if (randNum >= 60 && randNum < 70)
        {   // 수풀
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[3];
        }
        else if (randNum >= 70 && randNum < 76)
        {   // 가로등
            theTile_ = Instantiate(sideCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[12];
        }
        else if (randNum >= 76 && randNum < 84)
        {   // 거미고치
            theTile_ = Instantiate(sideCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[5];
        }
        else if (randNum >= 84 && randNum < 92)
        {   // 전장
            theTile_ = Instantiate(sideCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[7];
        }
        else if (randNum >= 92 && randNum < 100)
        {   // 저택
            theTile_ = Instantiate(sideCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[6];
        }

        if (theTile_ != null || theTile_ != default)
        {
            theTile_.GetComponentsInChildren<Image>()[1].enabled = true;
            return theTile_;
        }
        else { return MakeCard(); }
    }       // MakeCard()
}
