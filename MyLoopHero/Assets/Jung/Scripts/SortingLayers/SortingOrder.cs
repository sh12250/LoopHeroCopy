using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingOrder : MonoBehaviour
{
    public string sortingLayerName;
    public int sortingOrder;

    void Start()
    {
        Canvas mesh = GetComponent<Canvas>();
        mesh.sortingLayerName = sortingLayerName;
        mesh.sortingOrder = sortingOrder;
    }
}
