using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSoundManager : SingletonMonoBehaviour<DungeonSoundManager>
{
    public enum SoundType {
        Invalide =-1,
        BGM,
        SEAttack1,
        SEAttack2,
        SoundTypesMax  
    }
    private AudioSource[] audioSources;



    public enum BGMType
    {
        Invalide = -1,
        DungeonTitleBGM,
        DungeonAttackBGM,
        DungeonResultBGM,
        SoundTypesMax
    }

    [SerializeField]
    private AudioClip[] BGMClips;

    [SerializeField]
    private AudioClip[] SEClips;

    public override void Awake()
    {
        audioSources = new AudioSource[(int)SoundType.SoundTypesMax];
        base.Awake();
        for (int i =0;i< (int)SoundType.SoundTypesMax;i++)
        {
            audioSources[i] = this.gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayeBGM(BGMType bgmType) {
            audioSources[(int)SoundType.BGM].clip = BGMClips[(int)bgmType];
            audioSources[(int)SoundType.BGM].Play();
    }

    public void PlaySE(SoundType soundType)
    {
        switch (soundType) {
            case SoundType.SEAttack1:
                audioSources[(int)SoundType.SEAttack1].PlayOneShot(SEClips[0]);
                break;
            case SoundType.SEAttack2:
                audioSources[(int)SoundType.SEAttack2].PlayOneShot(SEClips[1]);
                break;
        }
    }
}
