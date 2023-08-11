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
        }

        dayGauge.fillAmount = globalTime / DAYCYCLE;
    }

    public RaycastHit2D GetHit(string layerMaskName_)
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // ���콺 ��ġ�� ȭ�� ��ǥ���� ���� ��ǥ�� ��ȯ
        Vector2 origin = new Vector2(mousePos.x, mousePos.y);
        // ����ĳ��Ʈ ������
        Vector2 direction = Vector2.zero;
        // ����ĳ��Ʈ ����
        RaycastHit2D hit = Physics2D.Raycast(origin, direction, Mathf.Infinity, LayerMask.GetMask(layerMaskName_));
        // ����ĳ��Ʈ ����

        return hit;
    }
}
