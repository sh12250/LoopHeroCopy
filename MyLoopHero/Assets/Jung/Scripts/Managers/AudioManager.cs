using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField]
    private AudioSource musicPlayer;

    /// <summary>
    /// 0: 인트로, 1,2,3: 기본 배경 음악, 4: 리치 맵 등장, 5: 리치 전투 배경 음악
    /// </summary>
    public List<AudioClip> musics;

    /// <summary>
    /// 0,1,2: 영웅의 공격, 3,4: 영웅의 회복, 5: 영웅의 죽음
    /// </summary>
    public List<AudioClip> sounds_Hero;

    /// <summary>
    /// 0,1: 적의 공격, 2: 리치의 등장, 3: 리치의 공격, 4: 리치의 죽음
    /// </summary>
    public List<AudioClip> sounds_Enemy;

    /// <summary>
    /// 0: 하루의 시작, 1: 레벨업, 2: 퍽알림
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
            Debug.LogWarning("AudioManager가 너무 많습니다");
        }

        musicPlayer.clip = musics[0];
    }

    // 음악
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
    // 음악

    // 효과음
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
    // 효과음
}
