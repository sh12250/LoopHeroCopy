using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    private AudioSource musicPlayer;

    /// <summary>
    /// 0: ��Ʈ��, 1,2,3: �⺻ ��� ����, 4: ��ġ �� ����, 5: ��ġ ���� ��� ����
    /// </summary>
    public List<AudioClip> musics;

    /// <summary>
    /// 0,1,2: ������ ����, 3,4: ������ ȸ��, 5: ������ ����
    /// </summary>
    public List<AudioClip> sounds_Hero;

    /// <summary>
    /// 0,1: ���� ����, 2: ��ġ�� ����, 3: ��ġ�� ����, 4: ��ġ�� ����
    /// </summary>
    public List<AudioClip> sounds_Enemy;

    /// <summary>
    /// 0: �Ϸ��� ����, 1: ������, 2: �ܾ˸�
    /// </summary>
    public List<AudioClip> sounds_Etc;

    private void Awake()
    {
        if (instance == null || instance == default)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("AudioManager�� �ʹ� �����ϴ�");
        }

        musicPlayer.clip = musics[0];
    }

    // ����
    public void PlayMusic_Basic()
    {
        musicPlayer.Stop();

        int randIdx_ = Random.Range(1, 4);

        musicPlayer.clip = musics[randIdx_];
        musicPlayer.Play();
    }

    public void PlayMusic_LichPortal()
    {
        musicPlayer.Stop();

        musicPlayer.clip = musics[4];
        musicPlayer.Play();
    }

    public void PlayMusic_LichBattle()
    {
        musicPlayer.Stop();

        musicPlayer.clip = musics[5];
        musicPlayer.Play();
    }
    // ����

    // ȿ����
    public void PlaySound_HeroAttack()
    {
        SoundPlayer soundPlayer_ = SoundPlayerPool.GetSoundPlayer();

        soundPlayer_.GetComponent<AudioSource>().Stop();

        int randIdx_ = Random.Range(0, 3);

        soundPlayer_.GetComponent<AudioSource>().clip = sounds_Hero[randIdx_];

        soundPlayer_.enabled = true;

        soundPlayer_.GetComponent<AudioSource>().Play();
    }

    public void PlaySound_HeroCampHeal()
    {
        SoundPlayer soundPlayer_ = SoundPlayerPool.GetSoundPlayer();

        soundPlayer_.GetComponent<AudioSource>().Stop();

        soundPlayer_.GetComponent<AudioSource>().clip = sounds_Hero[3];

        soundPlayer_.enabled = true;

        soundPlayer_.GetComponent<AudioSource>().Play();
    }

    public void PlaySound_HeroVillageHeal()
    {
        SoundPlayer soundPlayer_ = SoundPlayerPool.GetSoundPlayer();

        soundPlayer_.GetComponent<AudioSource>().Stop();

        soundPlayer_.GetComponent<AudioSource>().clip = sounds_Hero[4];

        soundPlayer_.enabled = true;

        soundPlayer_.GetComponent<AudioSource>().Play();
    }

    public void PlaySound_HeroDeath()
    {
        SoundPlayer soundPlayer_ = SoundPlayerPool.GetSoundPlayer();

        soundPlayer_.GetComponent<AudioSource>().Stop();

        soundPlayer_.GetComponent<AudioSource>().clip = sounds_Hero[5];

        soundPlayer_.enabled = true;

        soundPlayer_.GetComponent<AudioSource>().Play();
    }

    public void PlaySound_EnemyAttack()
    {
        SoundPlayer soundPlayer_ = SoundPlayerPool.GetSoundPlayer();

        soundPlayer_.GetComponent<AudioSource>().Stop();

        int randIdx_ = Random.Range(0, 2);

        soundPlayer_.GetComponent<AudioSource>().clip = sounds_Enemy[randIdx_];

        soundPlayer_.enabled = true;

        soundPlayer_.GetComponent<AudioSource>().Play();
    }
    public void PlaySound_LichAppear()
    {
        SoundPlayer soundPlayer_ = SoundPlayerPool.GetSoundPlayer();

        soundPlayer_.GetComponent<AudioSource>().Stop();

        soundPlayer_.GetComponent<AudioSource>().clip = sounds_Enemy[2];

        soundPlayer_.enabled = true;

        soundPlayer_.GetComponent<AudioSource>().Play();
    }

    public void PlaySound_LichDeath()
    {
        SoundPlayer soundPlayer_ = SoundPlayerPool.GetSoundPlayer();

        soundPlayer_.GetComponent<AudioSource>().Stop();

        soundPlayer_.GetComponent<AudioSource>().clip = sounds_Enemy[3];

        soundPlayer_.enabled = true;

        soundPlayer_.GetComponent<AudioSource>().Play();
    }

    public void PlaySound_LichAttack()
    {
        SoundPlayer soundPlayer_ = SoundPlayerPool.GetSoundPlayer();

        soundPlayer_.GetComponent<AudioSource>().Stop();

        soundPlayer_.GetComponent<AudioSource>().clip = sounds_Enemy[4];

        soundPlayer_.enabled = true;

        soundPlayer_.GetComponent<AudioSource>().Play();
    }

    public void PlaySound_DayStart()
    {
        SoundPlayer soundPlayer_ = SoundPlayerPool.GetSoundPlayer();

        soundPlayer_.GetComponent<AudioSource>().Stop();

        soundPlayer_.GetComponent<AudioSource>().clip = sounds_Etc[0];

        soundPlayer_.enabled = true;

        soundPlayer_.GetComponent<AudioSource>().Play();
    }

    public void PlaySound_LevelUp()
    {
        SoundPlayer soundPlayer_ = SoundPlayerPool.GetSoundPlayer();

        soundPlayer_.GetComponent<AudioSource>().Stop();

        soundPlayer_.GetComponent<AudioSource>().clip = sounds_Etc[1];

        soundPlayer_.enabled = true;

        soundPlayer_.GetComponent<AudioSource>().Play();
    }

    public void PlaySound_PerkAlarm()
    {
        SoundPlayer soundPlayer_ = SoundPlayerPool.GetSoundPlayer();

        soundPlayer_.GetComponent<AudioSource>().Stop();

        soundPlayer_.GetComponent<AudioSource>().clip = sounds_Etc[2];

        soundPlayer_.enabled = true;

        soundPlayer_.GetComponent<AudioSource>().Play();
    }
    // ȿ����
}
