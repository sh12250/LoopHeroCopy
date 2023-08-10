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

    [Header("For Test")]
    [Space(2)]
    [SerializeField]
    float moveSpeed;

    private void Start()
    {
        path = new List<GameObject>();
        path = MapManager.instance.passPoints;

        startIdx_ = 0;
        targetIdx_ = 1;

        moveSpeed = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Patrolling();
    }

    // 목적지를 향해 Y축 이동 후 X축 이동하는 함수
    private void Patrolling()
    {
        if (startIdx_ < 0 || startIdx_ >= path.Count || targetIdx_ < 0 || targetIdx_ >= path.Count)
        {
            Debug.LogWarning("Invalid indices for path elements.");
            return;
        }

        float startY_ = path[startIdx_].transform.localPosition.y;
        float startX_ = path[startIdx_].transform.localPosition.x;

        float targetY_ = path[targetIdx_].transform.localPosition.y;
        float targetX_ = path[targetIdx_].transform.localPosition.x;

        float distanceToMove = moveSpeed * Time.deltaTime;

        if (startY_ > targetY_)
        {
            if (transform.localPosition.y > targetY_)
            {
                transform.Translate(Vector2.down * distanceToMove);
            }
            else
            {
                if (startX_ > targetX_)
                {
                    if (transform.localPosition.x > targetX_)
                    {
                        transform.Translate(Vector2.left * distanceToMove);
                    }
                    else
                    {
                        transform.localPosition = new Vector2(targetX_, targetY_);

                        LoopIdx();
                        return;
                    }
                }
                else if (startX_ < targetX_)
                {
                    if (transform.localPosition.x < targetX_)
                    {
                        transform.Translate(Vector2.right * distanceToMove);
                    }
                    else
                    {
                        transform.localPosition = new Vector2(targetX_, targetY_);

                        LoopIdx();
                        return;
                    }
                }
                else if (startX_ == targetX_)
                {
                    LoopIdx();
                }
            }
        }
        else if (startY_ < targetY_)
        {
            if (transform.localPosition.y < targetY_)
            {
                transform.Translate(Vector2.up * distanceToMove);
            }
            else
            {
                if (startX_ > targetX_)
                {
                    if (transform.localPosition.x > targetX_)
                    {
                        transform.Translate(Vector2.left * distanceToMove);
                    }
                    else
                    {
                        transform.localPosition = new Vector2(targetX_, targetY_);

                        LoopIdx();
                        return;
                    }
                }
                else if (startX_ < targetX_)
                {
                    if (transform.localPosition.x < targetX_)
                    {
                        transform.Translate(Vector2.right * distanceToMove);
                    }
                    else
                    {
                        transform.localPosition = new Vector2(targetX_, targetY_);

                        LoopIdx();
                        return;
                    }
                }
                else if (startX_ == targetX_)
                {
                    LoopIdx();
                }
            }
        }
    }

    private void LoopIdx()
    {
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
    }
}
