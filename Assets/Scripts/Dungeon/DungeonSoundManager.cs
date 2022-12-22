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

    public enum SEType {
        Invalide = -1,
        SwordAttack,
        ChargeAttack,
        NextStagePosSE,
        SoundTypesMax
    }

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
        // 現在再生中の音源とは違う音源を再生する場合は再生できる
        if (audioSources[(int)SoundType.BGM].clip != BGMClips[(int)bgmType]) {

            audioSources[(int)SoundType.BGM].clip = BGMClips[(int)bgmType];
            audioSources[(int)SoundType.BGM].Play();
        }
    }

    public void PlaySE(SEType SEType)
    {
        if (!audioSources[(int)SoundType.SEAttack1].isPlaying)
        {

            audioSources[(int)SoundType.SEAttack1].PlayOneShot(SEClips[(int)SEType]);
        }
        else {

            audioSources[(int)SoundType.SEAttack2].PlayOneShot(SEClips[(int)SEType]);
        }
    }
}
