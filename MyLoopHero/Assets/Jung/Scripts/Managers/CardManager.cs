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

    #region ���� �̹���
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
    #endregion // ���� �̹���
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
            Debug.LogWarning("CardManager�� �ʹ� �����ϴ�");
        }
    }

    // ���� ī�� ����
    public GameObject MakeCard()
    {
        int randNum = Random.Range(0, 100);

        GameObject theTile_ = default;

        Transform parent_ = HandManager.instance.GetHandTransform();

        #region �� ī�� ���� Ȯ��
        if (randNum >= 0 && randNum < 4)
        {   // ���� 4
            theTile_ = Instantiate(mightCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[0];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[0];
            theTile_.name = CardName.OBLIVION.ToString();
        }
        else if (randNum >= 4 && randNum < 12)
        {   // �ݰ� 8
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[14];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[14];
            theTile_.name = CardName.SAFE.ToString();
        }
        else if (randNum >= 12 && randNum < 20)
        {   // ��� 8
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[8];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[8];
            theTile_.name = CardName.LIGHTHOUSE.ToString();
        }
        else if (randNum >= 20 && randNum < 32)
        {   // ���� 12
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[9];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[9];
            theTile_.name = CardName.ROCK.ToString();
        }
        else if (randNum >= 32 && randNum < 42)
        {   // �� 10
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[10];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[10];
            theTile_.name = CardName.MOUNT.ToString();
        }
        else if (randNum >= 42 && randNum < 52)
        {   // ������ 10
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[15];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[15];
            theTile_.name = CardName.GRASS.ToString();
        }
        else if (randNum >= 52 && randNum < 60)
        {   // ���� 8
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[1];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[1];
            theTile_.name = CardName.CEMETARY.ToString();
        }
        else if (randNum >= 60 && randNum < 70)
        {   // ��Ǯ 10
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[3];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[3];
            theTile_.name = CardName.BUSH.ToString();
        }
        else if (randNum >= 70 && randNum < 76)
        {   // ���ε� 6
            theTile_ = Instantiate(sideCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[12];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[12];
            theTile_.name = CardName.LAMP.ToString();
        }
        else if (randNum >= 76 && randNum < 84)
        {   // �Ź̰�ġ 8
            theTile_ = Instantiate(sideCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[5];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[5];
            theTile_.name = CardName.COCOON.ToString();
        }
        else if (randNum >= 84 && randNum < 92)
        {   // ���� 8
            theTile_ = Instantiate(sideCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[7];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[7];
            theTile_.name = CardName.BATTLEFIELD.ToString();
        }
        else if (randNum >= 92 && randNum < 100)
        {   // ���� 8
            theTile_ = Instantiate(sideCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[6];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[6];
            theTile_.name = CardName.MANSION.ToString();
        }
        #endregion // �� ī�� ���� Ȯ��

        if (theTile_ != null || theTile_ != default)
        {
            theTile_.GetComponentsInChildren<Image>()[1].enabled = true;
            return theTile_;
            // ī�� �̹��� Ȱ��ȭ �� ��ȯ
        }
        else { return MakeCard(); }
        // ī�尡 ������ ���⵵�� ���
    }       // MakeCard()
}
