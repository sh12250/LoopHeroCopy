using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoopCounter : MonoBehaviour
{
    private GameObject loopText;

    private void Awake()
    {
        loopText = this.gameObject;
    }

    private void FixedUpdate()
    {
        loopText.GetComponent<TMP_Text>().text = GameManager.instance.loopCnt.ToString();
    }
}
