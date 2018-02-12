using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DouduckGame;

public enum BGMAudio {
    Menu = 0,
    InGame
}

public enum EffectAudio {
    Dive = 0,
    Explosion,
    Nice,
    BuBu
}

public class AudioInterface : GameSystemMono {
    [SerializeField]
    private AudioSource m_BGMSource;
    [SerializeField]
    private AudioSource m_EffectSource;

    [SerializeField]
    private AudioClip[] m_bgmClip;
    [SerializeField]
    private AudioClip[] m_effectClip;

    public void PlayBGM (BGMAudio bgm) {
        m_BGMSource.clip = m_bgmClip[(int)bgm];
        m_BGMSource.Play ();
    }

    public void PlaySound (EffectAudio sound) {
        m_EffectSource.clip = m_effectClip[(int)sound];
        m_EffectSource.Play ();
    }
}
