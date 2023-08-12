using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : MonoBehaviour
{
    public float enemyrHP { get; private set; }
    public float enemyDMG { get; private set; }
    public float enemyDEF { get; private set; }
    public float enemyAttackSpeed { get; private set; }

    private void Awake()
    {
        MakeEnemy();   
    }

    private void MakeEnemy()
    {
        enemyrHP = 20f;
        enemyDMG = 3f;
        enemyDEF = 3f;
        enemyAttackSpeed = 0.5f;
    }
}
