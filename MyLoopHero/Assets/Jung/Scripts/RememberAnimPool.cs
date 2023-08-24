using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RememberAnimPool : MonoBehaviour
{
    public static RememberAnimPool instance;

    [SerializeField]
    private GameObject remAnimPrefab;

    Queue<RememberAnim> animQueue = new Queue<RememberAnim>();

    private void Awake()
    {
        if (instance == null || instance == default)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("RememberAnimPool이 너무 많습니다");
        }

        Initialize(20);
    }

    private void Initialize(int initCount)
    {
        for (int i = 0; i < initCount; i++)
        {
            animQueue.Enqueue(CreateNewObject());
        }
    }

    private RememberAnim CreateNewObject()
    {
        RememberAnim newObj = Instantiate(remAnimPrefab).GetComponent<RememberAnim>();
        newObj.gameObject.SetActive(false);
        newObj.transform.SetParent(transform);
        return newObj;
    }

    public static RememberAnim GetObject()
    {
        if (instance.animQueue.Count > 0)
        {
            RememberAnim obj = instance.animQueue.Dequeue();
            obj.gameObject.SetActive(true);
            obj.transform.SetParent(null);
            return obj;
        }
        else
        {
            RememberAnim newObj = instance.CreateNewObject();
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;
        }
    }

    public static void ReturnObject(RememberAnim obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(instance.transform);
        obj.transform.localPosition = instance.transform.localPosition;
        instance.animQueue.Enqueue(obj);
    }
}