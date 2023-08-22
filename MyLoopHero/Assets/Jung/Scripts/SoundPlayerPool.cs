using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayerPool : MonoBehaviour
{
    public static SoundPlayerPool instance;

    [SerializeField]
    private GameObject soundPlayerPrefab;

    Queue<SoundPlayer> soundQueue = new Queue<SoundPlayer>();

    private void Awake()
    {
        if (instance == null || instance == default)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("SoundPlayerPool이 너무 많습니다");
        }

        InitPool(10);
    }

    private void InitPool(int cnt_)
    {
        for (int i = 0; i < cnt_; i++)
        {
            soundQueue.Enqueue(CreateSoundPlayer());
        }
    }

    private SoundPlayer CreateSoundPlayer()
    {
        SoundPlayer newObj_ = Instantiate(soundPlayerPrefab).GetComponent<SoundPlayer>();
        newObj_.gameObject.SetActive(false);
        newObj_.enabled = false;
        newObj_.transform.SetParent(instance.transform);
        return newObj_;
    }

    public static SoundPlayer GetSoundPlayer()
    {
        if (instance.soundQueue.Count > 0)
        {
            SoundPlayer obj_ = instance.soundQueue.Dequeue();
            obj_.gameObject.SetActive(true);
            obj_.transform.SetParent(null);
            return obj_;
        }
        else
        {
            SoundPlayer newObj_ = instance.CreateSoundPlayer();
            newObj_.gameObject.SetActive(true);
            newObj_.transform.SetParent(null);
            return newObj_;
        }
    }

    public static void ReturnSoundPlayer(SoundPlayer obj_)
    {
        obj_.gameObject.SetActive(false);
        obj_.transform.SetParent(instance.transform);
        instance.soundQueue.Enqueue(obj_);
    }
}
