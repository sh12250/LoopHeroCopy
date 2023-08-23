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

    //[Header("For Test")]
    //[Space(2)]
    [SerializeField]
    private float moveSpeed;

    private Vector2 currPos;
    [SerializeField]
    private float moveDist;

    private void Start()
    {
        path = new List<GameObject>();
        path = MapManager.instance.passPoints;

        startIdx_ = 0;
        targetIdx_ = 1;

        moveSpeed = 1f;

        currPos = transform.localPosition;
        moveDist = 0f;
    }

    private void Update()
    {
        if (GetComponentInChildren<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name == "WarriorWalk")
        {
            Patrolling();
        }

        moveDist = ((Vector2)transform.localPosition - currPos).magnitude;

        if (moveDist >= 1f)
        {
            RaycastHit2D hit_Tiles = GameManager.instance.GetHit(transform.position, "Tiles");

            if (hit_Tiles.collider != null)
            {
                currPos = hit_Tiles.collider.gameObject.transform.localPosition;

                if (hit_Tiles.collider.GetComponent<RoadTile>() != null)
                {
                    if (hit_Tiles.collider.GetComponent<RoadTile>().GetMonsterCnt() > 0)
                    {
                        // 전투창 열람
                        BattleManager.instance.GetPlayerInfo();
                        BattleManager.instance.UpdateMonsterInfo(hit_Tiles);
                        //MapTime.MapTimeScale(0);
                        //Time.timeScale = 0;
                        BattleManager.instance.FindHitTarget();
                        BattleManager.instance.OpenWindow();
                    }
                }

                if (hit_Tiles.collider.name == "CampsiteTile")
                {
                    GameManager.instance.loopCnt += 1;
                    float healAmount = GetComponent<Knight>().heroHealthMax / 5f;
                    GetComponent<Knight>().heroHealth += healAmount;

                    AudioManager.instance.PlaySound_HeroCampHeal();
                }

                if (hit_Tiles.collider.name == "VILLAGE")
                {
                    float healAmount = 15 + 5 * GameManager.instance.loopCnt;
                    GetComponent<Knight>().heroHealth += healAmount;

                    AudioManager.instance.PlaySound_HeroVillageHeal();
                }
            }
        }
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

        float distanceToMove = moveSpeed * MapTime.MapDeltaTime();
        //float distanceToMove = moveSpeed * Time.deltaTime;

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
