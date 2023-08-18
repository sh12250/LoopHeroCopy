using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public RaycastHit2D hit;
    // ������ũ��Ʈ�� �ѷ��� ����

    [SerializeField]
    private Image dayGauge;

    public const float DAYCYCLE = 24f;
    public float globalTime;
    public int dayCnt;
    public int loopCnt;

    private void Awake()
    {
        if (instance == null || instance == default)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("GameManager�� �ʹ� �����ϴ�");
        }
    }

    void Start()
    {
        globalTime = 0f;
        dayCnt = 0;
    }

    void Update()
    {
        globalTime += Time.deltaTime * 4;

        if (globalTime >= DAYCYCLE)
        {
            globalTime = 0f;
            dayCnt += 1;

            HandManager.instance.DrawCard();
            HandManager.instance.DrawCard();
        }

        dayGauge.fillAmount = globalTime / DAYCYCLE;
    }

    public RaycastHit2D GetHit(string layerMaskName_)
    {
        Vector3 mousePos_ = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // ���콺 ��ġ�� ȭ�� ��ǥ���� ���� ��ǥ�� ��ȯ
        Vector2 origin_ = new Vector2(mousePos_.x, mousePos_.y);
        // ����ĳ��Ʈ ������
        Vector2 direction_ = Vector2.zero;
        // ����ĳ��Ʈ ����
        RaycastHit2D hit_ = Physics2D.Raycast(origin_, direction_, Mathf.Infinity, LayerMask.GetMask(layerMaskName_));
        // ����ĳ��Ʈ ����

        return hit_;
    }

    public RaycastHit2D GetHit(Vector2 position_, string layerMaskName_)
    {
        Vector2 origin_ = new Vector2(position_.x, position_.y);
        // ����ĳ��Ʈ ������
        Vector2 direction_ = Vector2.zero;
        // ����ĳ��Ʈ ����
        RaycastHit2D hit_ = Physics2D.Raycast(origin_, direction_, Mathf.Infinity, LayerMask.GetMask(layerMaskName_));
        // ����ĳ��Ʈ ����

        return hit_;
    }
}
