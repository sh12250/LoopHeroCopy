using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public static CardManager instance;

    [SerializeField]
    private GameObject roadCardBase;
    // �� ���̽�
    [SerializeField]
    private GameObject sideCardBase;
    // �氡 ���̽�
    [SerializeField]
    private GameObject etcCardBase;
    // �׿� ���̽�
    [SerializeField]
    private GameObject mightCardBase;
    // ���� ���� ���̽�

    #region ī�� �̹���
    /// <summary>
    /// 0:  ����, 
    /// 1:  ����, 
    /// 2:  ����, 
    /// 3:  ��Ǯ, 
    /// 4:  �й�, 
    /// 5:  �Ź̰�ġ, 
    /// 6:  ������ ����, 
    /// 7:  ����, 
    /// 8:  ���, 
    /// 9:  ����, 
    /// 10: ��, 
    /// 11: �������� ��Ǯ, 
    /// 12: ���ε�, 
    /// 13: ��, 
    /// 14: �ݰ�, 
    /// 15: ������
    /// </summary>
    #endregion // ī�� �̹���
    public Sprite[] faceSprites;

    private void Awake()
    {
        if (instance == null || instance == default)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("CardManager�� �ʹ� �����ϴ�");
        }
    }

    // ���� ī�� ����
    public GameObject MakeCard()
    {
        int randNum = Random.Range(0, 100);

        GameObject theTile_ = default;

        Transform parent_ = HandManager.instance.GetHandTransform();

        if (randNum >= 0 && randNum < 4)
        {   // ����
            theTile_ = Instantiate(mightCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[0];
        }
        else if (randNum >= 4 && randNum < 12)
        {   // �ݰ�
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[14];
        }
        else if (randNum >= 12 && randNum < 20)
        {   // ���
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[8];
        }
        else if (randNum >= 20 && randNum < 32)
        {   // ����
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[9];
        }
        else if (randNum >= 32 && randNum < 42)
        {   // ��
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[10];
        }
        else if (randNum >= 42 && randNum < 52)
        {   // ������
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[15];
        }
        else if (randNum >= 52 && randNum < 60)
        {   // ����
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[1];
        }
        else if (randNum >= 60 && randNum < 70)
        {   // ��Ǯ
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[3];
        }
        else if (randNum >= 70 && randNum < 76)
        {   // ���ε�
            theTile_ = Instantiate(sideCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[12];
        }
        else if (randNum >= 76 && randNum < 84)
        {   // �Ź̰�ġ
            theTile_ = Instantiate(sideCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[5];
        }
        else if (randNum >= 84 && randNum < 92)
        {   // ����
            theTile_ = Instantiate(sideCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[7];
        }
        else if (randNum >= 92 && randNum < 100)
        {   // ����
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
