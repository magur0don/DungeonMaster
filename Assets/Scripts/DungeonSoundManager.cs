using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSoundManager : SingletonMonoBehaviour<DungeonSoundManager>
{
    public enum SoundType {
        Invalide =-1,
        BGM,
        SE1,
        SE2,
        SoundTypeMax  
    }
    private AudioSource[] audioSources;

    [SerializeField]
    private AudioClip BGMClips;

    [SerializeField]
    private AudioClip[] SEClips;

    public override void Awake()
    {
        audioSources = new AudioSource[(int)SoundType.SoundTypeMax];
        base.Awake();
        for (int i =0;i< (int)SoundType.SoundTypeMax;i++)
        {
            audioSources[i] = this.gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayeBGM() {
        // 音楽が再生中ではなかったら再生する
        if (!audioSources[(int)SoundType.BGM].isPlaying) {
            audioSources[(int)SoundType.BGM].clip = BGMClips;
            audioSources[(int)SoundType.BGM].Play();
        }
    }

    public void PlayeSE(SoundType soundType)
    {
        switch (soundType) {
            case SoundType.SE1:
                // 音楽が再生中ではなかったら再生する
                audioSources[(int)SoundType.SE1].PlayOneShot(SEClips[0]);
                break;
            case SoundType.SE2:
                audioSources[(int)SoundType.SE2].PlayOneShot(SEClips[1]);
                break;
        }
    }
}
