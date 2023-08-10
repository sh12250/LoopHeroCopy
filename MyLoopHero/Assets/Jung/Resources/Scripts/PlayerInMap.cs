using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerInMap : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> path;

    int startIdx_;
    int targetIdx_;

    private void Start()
    {
        path = new List<GameObject>();
        path = MapManager.instance.passPoints;

        startIdx_ = 0;
        targetIdx_ = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Patrolling();
    }

    private void Patrolling()
    {
        float targetX_ = path[targetIdx_].transform.localPosition.x;
        float targetY_ = path[targetIdx_].transform.localPosition.y;

        // Debug.LogFormat("�� ��ǥ: {0, 1}, ��ǥ ��ǥ: {2, 3}", transform.position.x, transform.position.y, targetX_, targetY_);

        // ���ǿ� ������ �ε����� ������Ű�� �Լ� ����
        if (transform.localPosition.x >= targetX_ - 0.005f
            && transform.localPosition.x <= targetX_ + 0.005f)
        {
            if (transform.localPosition.y >= targetY_ - 0.005f
                && transform.localPosition.y <= targetY_ + 0.005f)
            {
                transform.localPosition = path[targetIdx_].transform.localPosition;

                startIdx_ += 1;
                targetIdx_ += 1;

                if (startIdx_ >= path.Count)
                {
                    startIdx_ = 0;
                }

                if (targetIdx_ >= path.Count)
                {
                    targetIdx_ = 0;
                }

                return;
            }
        }

        float distanceX_ = Mathf.Abs(new Vector2(path[targetIdx_].transform.localPosition.x - path[startIdx_].transform.localPosition.x, 0f).magnitude);
        float distanceY_ = Mathf.Abs(new Vector2(0f, path[targetIdx_].transform.localPosition.y - path[startIdx_].transform.localPosition.y).magnitude);

        float speed_ = 0.005f;

        if (distanceX_ >= distanceY_)
        {
            if (transform.localPosition.x > targetX_)
            {
                // �ϴ� �ݱ��� �̵�
                if (transform.localPosition.x < (targetX_ + Mathf.Ceil(distanceX_ / 2)) - 0.005f
                    || transform.localPosition.x > (targetX_ + Mathf.Ceil(distanceX_ / 2)) + 0.005f)
                {
                    transform.Translate(new Vector2(1, 0) * speed_ * -1);
                    return;
                }

                // ���� �̵�
                if (transform.localPosition.y > targetY_)
                {
                    if (transform.localPosition.y < targetY_ - 0.005f
                        || transform.localPosition.y > targetY_ + 0.005f)
                    {
                        transform.Translate(new Vector2(0, 1) * speed_ * -1);
                        return;
                    }
                }
                else if (transform.localPosition.y < targetY_)
                {
                    if (transform.localPosition.y < targetY_ - 0.005f
                        || transform.localPosition.y > targetY_ + 0.005f)
                    {
                        transform.Translate(new Vector2(0, 1) * speed_);
                        return;
                    }
                }

                // ������ �� �̵� (������ ���� ����)
                if (transform.localPosition.x < targetX_ - 0.005f
                    || transform.localPosition.x > targetX_ + 0.005f)
                {
                    transform.Translate(new Vector2(1, 0) * speed_ * -1);
                    return;
                }
            }
            else if (transform.localPosition.x < targetX_)
            {
                // �ϴ� �ݱ��� �̵�
                if (transform.localPosition.x < (targetX_ - Mathf.Ceil(distanceX_ / 2)) - 0.005f
                    || transform.localPosition.x > (targetX_ - Mathf.Ceil(distanceX_ / 2)) + 0.005f)
                {
                    transform.Translate(new Vector2(1, 0) * speed_);
                    return;
                }

                // ���� �̵�
                if (transform.localPosition.y > targetY_)
                {
                    if (transform.localPosition.y < targetY_ - 0.005f
                        || transform.localPosition.y > targetY_ + 0.005f)
                    {
                        transform.Translate(new Vector2(0, 1) * speed_ * -1);
                        return;
                    }
                }
                else if (transform.localPosition.y < targetY_)
                {
                    if (transform.localPosition.y < targetY_ - 0.005f
                        || transform.localPosition.y > targetY_ + 0.005f)
                    {
                        transform.Translate(new Vector2(0, 1) * speed_);
                        return;
                    }
                }

                // ������ �� �̵� (������ ���� ����)
                if (transform.localPosition.x < targetX_ - 0.005f
                    || transform.localPosition.x > targetX_ + 0.005f)
                {
                    transform.Translate(new Vector2(1, 0) * speed_);
                    return;
                }
            }
        }
        else if (distanceX_ < distanceY_)
        {
            if (transform.localPosition.y > targetY_)
            {
                // �ϴ� �ݱ��� �̵�
                if (transform.localPosition.y < (targetY_ + Mathf.Ceil(distanceY_ / 2)) - 0.005f
                    || transform.localPosition.y > (targetY_ + Mathf.Ceil(distanceY_ / 2)) + 0.005f)
                {
                    transform.Translate(new Vector2(0, 1) * speed_ * -1);
                    return;
                }

                // ���� �̵�
                if (transform.localPosition.x > targetX_)
                {
                    if (transform.localPosition.x < targetX_ - 0.005f
                        || transform.localPosition.x > targetX_ + 0.005f)
                    {
                        transform.Translate(new Vector2(1, 0) * speed_ * -1);
                        return;
                    }
                }
                else if (transform.localPosition.x < targetX_)
                {
                    if (transform.localPosition.x < targetX_ - 0.005f
                        || transform.localPosition.x > targetX_ + 0.005f)
                    {
                        transform.Translate(new Vector2(1, 0) * speed_);
                        return;
                    }
                }

                // ������ �� �̵� (������ ���� ����)
                if (transform.localPosition.y < targetY_ - 0.005f
                    || transform.localPosition.y > targetY_ + 0.005f)
                {
                    transform.Translate(new Vector2(0, 1) * speed_ * -1);
                    return;
                }
            }
            else if (transform.localPosition.y < targetY_)
            {
                // �ϴ� �ݱ��� �̵�
                if (transform.localPosition.y < (targetY_ - Mathf.Ceil(distanceY_ / 2)) - 0.005f
                    || transform.localPosition.y > (targetY_ - Mathf.Ceil(distanceY_ / 2)) + 0.005f)
                {
                    transform.Translate(new Vector2(0, 1) * speed_);
                    return;
                }

                // ���� �̵�
                if (transform.localPosition.x > targetX_)
                {
                    if (transform.localPosition.x < targetX_ - 0.005f
                        || transform.localPosition.x > targetX_ + 0.005f)
                    {
                        transform.Translate(new Vector2(1, 0) * speed_ * -1);
                        return;
                    }
                }
                else if (transform.localPosition.x < targetX_)
                {
                    if (transform.localPosition.x < targetX_ - 0.005f
                        || transform.localPosition.x > targetX_ + 0.005f)
                    {
                        transform.Translate(new Vector2(1, 0) * speed_);
                        return;
                    }
                }

                // ������ �� �̵� (������ ���� ����)
                if (transform.localPosition.y < targetY_ - 0.005f
                    || transform.localPosition.y > targetY_ + 0.005f)
                {
                    transform.Translate(new Vector2(0, 1) * speed_);
                    return;
                }
            }
        }
    }
}
