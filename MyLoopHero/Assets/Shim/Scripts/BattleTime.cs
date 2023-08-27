using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleTime : MonoBehaviour
{
    public static float battleTimeScale { get; private set; } = 1.0f;

    public static float BattleTimeScale(float scale_)
    {
        battleTimeScale = scale_;

        return battleTimeScale;
    }

    public static float BattleDeltaTime()
    {
        float battleDeltaTime_ = Time.deltaTime;
        battleDeltaTime_ *= battleTimeScale;

        return battleDeltaTime_;
    }
}
