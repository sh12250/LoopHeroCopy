using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase : MonoBehaviour
{
    private float power;

    private void Start()
    {
        // Loop당 50% 씩 강해짐
        power = 1f;
    }

    private void Update()
    {

    }

    public void PowerUp()
    {
        power *= 1.5f;
    }
}
