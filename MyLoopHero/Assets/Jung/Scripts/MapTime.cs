using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MapTime : MonoBehaviour
{
    public static float mapTimeScale { get; private set; } = 1.0f;

    public static float MapTimeScale(float scale_)
    {
        mapTimeScale = scale_;

        return mapTimeScale;
    }

    public static float MapDeltaTime()
    {
        float mapDeltaTime_ = Time.deltaTime;
        mapDeltaTime_ *= mapTimeScale;

        return mapDeltaTime_;
    }
}
