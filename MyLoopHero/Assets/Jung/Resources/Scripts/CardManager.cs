using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    private static CardManager instance;

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

    void Start()
    {

    }

    void Update()
    {

    }
}
