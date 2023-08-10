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
        else if (randNum >= 4 && randNum < 14)
        {   // ���� 10
            theTile_ = Instantiate(roadCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[1];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[1];
            theTile_.name = CardName.CEMETARY.ToString();
        }
        else if (randNum >= 14 && randNum < 24)
        {   // ���� 10
            theTile_ = Instantiate(roadCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[2];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[2];
            theTile_.name = CardName.VILLAGE.ToString();
        }
        else if (randNum >= 24 && randNum < 34)
        {   // ��Ǯ 10
            theTile_ = Instantiate(roadCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[3];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[3];
            theTile_.name = CardName.BUSH.ToString();
        }
        else if (randNum >= 34 && randNum < 44)
        {   // �й� 10
            theTile_ = Instantiate(roadCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[4];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[4];
            theTile_.name = CardName.CORNFIELD.ToString();
        }
        //else if (randNum >= 42 && randNum < 52)
        //{   // �Ź� ��ġ 10
        //    theTile_ = Instantiate(sideCardBase, parent_);
        //    theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[5];
        //    theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[5];
        //    theTile_.name = CardName.COCOON.ToString();
        //}
        //else if (randNum >= 52 && randNum < 60)
        //{   // ������ ���� 8
        //    theTile_ = Instantiate(sideCardBase, parent_);
        //    theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[6];
        //    theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[6];
        //    theTile_.name = CardName.MANSION.ToString();
        //}
        //else if (randNum >= 60 && randNum < 70)
        //{   // ���� 10
        //    theTile_ = Instantiate(sideCardBase, parent_);
        //    theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[7];
        //    theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[7];
        //    theTile_.name = CardName.BATTLEFIELD.ToString();
        //}
        else if (randNum >= 44 && randNum < 54)
        {   // ��� 10
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[8];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[8];
            theTile_.name = CardName.LIGHTHOUSE.ToString();
        }
        else if (randNum >= 54 && randNum < 64)
        {   // ���� 10
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[9];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[9];
            theTile_.name = CardName.ROCK.ToString();
        }
        else if (randNum >= 64 && randNum < 74)
        {   // �� 10
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[10];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[10];
            theTile_.name = CardName.MOUNT.ToString();
        }
        //else if (randNum >= 92 && randNum < 100)
        //{   // �������� ��Ǯ 8
        //    theTile_ = Instantiate(sideCardBase, parent_);
        //    theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[11];
        //    theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[11];
        //    theTile_.name = CardName.BLOODYBUSH.ToString();
        //}
        //else if (randNum >= 92 && randNum < 100)
        //{   // ���ε� 8
        //    theTile_ = Instantiate(sideCardBase, parent_);
        //    theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[12];
        //    theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[12];
        //    theTile_.name = CardName.LAMP.ToString();
        //}
        else if (randNum >= 74 && randNum < 84)
        {   // �� 10
            theTile_ = Instantiate(roadCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[13];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[13];
            theTile_.name = CardName.SWAMP.ToString();
        }
        else if (randNum >= 84 && randNum < 90)
        {   // �ݰ� 6
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[14];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[14];
            theTile_.name = CardName.SAFE.ToString();
        }
        else if (randNum >= 90 && randNum < 100)
        {   // ������ 10
            theTile_ = Instantiate(etcCardBase, parent_);
            theTile_.GetComponentsInChildren<Image>()[1].sprite = faceSprites[15];
            theTile_.GetComponentsInChildren<SpriteRenderer>()[0].sprite = buildSprites[15];
            theTile_.name = CardName.GRASS.ToString();
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
