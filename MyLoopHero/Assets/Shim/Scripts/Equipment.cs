using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{

    private int equipedItemId_prev;
    private int equipedItemId_curr;

    private void Awake()
    {
        equipedItemId_prev = default;
        equipedItemId_curr = default;
    }

    private void Update()
    {
        if (equipedItemId_prev != equipedItemId_curr)
        {
            equipedItemId_prev = equipedItemId_curr;


        }
    }



    public void SetEquipedItemID(int itemId_)
    {
        equipedItemId_curr = itemId_;
    }
}
