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

    public int cardCnt;
    // 총 카드 수

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

        cardCnt = 0;
    }

    // 랜덤 카드 생성
    public GameObject MakeCard()
    {
        int randNum = Random.Range(0, 100);

        GameObject theTile_ = default;

        Transform parent_ = HandManager.instance.GetHandTransform();

        #region 각 카드 생성 확률
        if (randNum >= 0 && randNum < 4)
        {   // 망각 4
            theTile_ = Instantiate(mightCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[0];
        }
        else if (randNum >= 4 && randNum < 12)
        {   // 금고 8
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[14];
        }
        else if (randNum >= 12 && randNum < 20)
        {   // 등대 8
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[8];
        }
        else if (randNum >= 20 && randNum < 32)
        {   // 바위 12
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[9];
        }
        else if (randNum >= 32 && randNum < 42)
        {   // 산 10
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[10];
        }
        else if (randNum >= 42 && randNum < 52)
        {   // 목초지 10
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[15];
        }
        else if (randNum >= 52 && randNum < 60)
        {   // 묘지 8
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[1];
        }
        else if (randNum >= 60 && randNum < 70)
        {   // 수풀 10
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[3];
        }
        else if (randNum >= 70 && randNum < 76)
        {   // 가로등 6
            theTile_ = Instantiate(sideCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[12];
        }
        else if (randNum >= 76 && randNum < 84)
        {   // 거미고치 8
            theTile_ = Instantiate(sideCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[5];
        }
        else if (randNum >= 84 && randNum < 92)
        {   // 전장 8
            theTile_ = Instantiate(sideCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[7];
        }
        else if (randNum >= 92 && randNum < 100)
        {   // 저택 8
            theTile_ = Instantiate(sideCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[6];
        }
        #endregion // 각 카드 생성 확률

        theTile_.GetComponent<RectTransform>().localPosition = new Vector3(-451 + (cardCnt * 2 * 41), -14, 0);

        if (theTile_ != null || theTile_ != default)
        {
            cardCnt += 1;
            // 총 카드 수 상승
            if(cardCnt > 12)
            {   // 12개가 모이면 손패가 꽉 참
                cardCnt = 12;
                // 맨 마지막 자리에 다시 넣는다
            }

            theTile_.GetComponentsInChildren<Image>()[1].enabled = true;
            return theTile_;
            // 카드 이미지 활성화 후 반환
        }
        else { return MakeCard(); }
        // 카드가 무조건 생기도록 재귀
    }       // MakeCard()
}
