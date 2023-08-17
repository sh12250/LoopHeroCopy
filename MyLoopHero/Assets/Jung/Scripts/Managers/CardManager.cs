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

    #region 빌드 이미지
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
    #endregion // 빌드 이미지
    public Sprite[] buildSprites;

    public enum CardName
    {
        OBLIVION = 0,
        CEMETARY,
        VILLAGE,
        BUSH,
        CORNFIELD,
        COCOON,
        MANSION,
        BATTLEFIELD,
        LIGHTHOUSE,
        ROCK,
        MOUNT,
        BLOODYBUSH,
        LAMP,
        SWAMP,
        SAFE,
        GRASS
    }

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

        #region 각 카드 생성 확률
        if (randNum >= 0 && randNum < 2)
        {   // 망각 2
            theTile_ = Instantiate(mightCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[0];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[0];
            theTile_.name = CardName.OBLIVION.ToString();
        }
        else if (randNum >= 2 && randNum < 8)
        {   // 묘지 6
            theTile_ = Instantiate(roadCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[1];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[1];
            theTile_.name = CardName.CEMETARY.ToString();
        }
        else if (randNum >= 8 && randNum < 14)
        {   // 마을 6
            theTile_ = Instantiate(roadCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[2];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[2];
            theTile_.name = CardName.VILLAGE.ToString();
        }
        else if (randNum >= 14 && randNum < 20)
        {   // 수풀 6
            theTile_ = Instantiate(roadCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[3];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[3];
            theTile_.name = CardName.BUSH.ToString();
        }
        else if (randNum >= 20 && randNum < 26)
        {   // 밀밭 6
            theTile_ = Instantiate(roadCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[4];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[4];
            theTile_.name = CardName.CORNFIELD.ToString();
        }
        else if (randNum >= 26 && randNum < 32)
        {   // 거미 고치 6
            theTile_ = Instantiate(sideCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[5];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[5];
            theTile_.name = CardName.COCOON.ToString();
        }
        else if (randNum >= 32 && randNum < 38)
        {   // 흡혈귀 저택 6
            theTile_ = Instantiate(sideCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[6];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[6];
            theTile_.name = CardName.MANSION.ToString();
        }
        else if (randNum >= 38 && randNum < 44)
        {   // 전장 6
            theTile_ = Instantiate(sideCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[7];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[7];
            theTile_.name = CardName.BATTLEFIELD.ToString();
        }
        else if (randNum >= 44 && randNum < 48)
        {   // 등대 4
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[8];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[8];
            theTile_.name = CardName.LIGHTHOUSE.ToString();
        }
        else if (randNum >= 48 && randNum < 58)
        {   // 바위 10
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[9];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[9];
            theTile_.name = CardName.ROCK.ToString();
        }
        else if (randNum >= 58 && randNum < 68)
        {   // 산 10
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[10];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[10];
            theTile_.name = CardName.MOUNT.ToString();
        }
        else if (randNum >= 68 && randNum < 74)
        {   // 피투성이 수풀 6
            theTile_ = Instantiate(sideCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[11];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[11];
            theTile_.name = CardName.BLOODYBUSH.ToString();
        }
        else if (randNum >= 74 && randNum < 80)
        {   // 가로등 6
            theTile_ = Instantiate(sideCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[12];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[12];
            theTile_.name = CardName.LAMP.ToString();
        }
        else if (randNum >= 80 && randNum < 86)
        {   // 늪 6
            theTile_ = Instantiate(roadCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[13];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[13];
            theTile_.name = CardName.SWAMP.ToString();
        }
        else if (randNum >= 86 && randNum < 90)
        {   // 금고 4
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[14];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[14];
            theTile_.name = CardName.SAFE.ToString();
        }
        else if (randNum >= 90 && randNum < 100)
        {   // 목초지 10
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[15];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[15];
            theTile_.name = CardName.GRASS.ToString();
        }
        #endregion // 각 카드 생성 확률

        if (theTile_ != null || theTile_ != default)
        {
            theTile_.GetComponentsInChildren<Image>()[1].enabled = true;
            return theTile_;
            // 카드 이미지 활성화 후 반환
        }
        else { return MakeCard(); }
        // 카드가 무조건 생기도록 재귀
    }       // MakeCard()
}
