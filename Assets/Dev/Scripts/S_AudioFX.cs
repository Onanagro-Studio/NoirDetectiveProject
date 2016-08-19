using UnityEngine;
using System.Collections;

public class S_AudioFX : MonoBehaviour {

    public float m_volume;

    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_volume = S_AudioManager.GlobalVolume / 100 * S_AudioManager.FXVolume / 100;
        // S_AudioManager.GlobalVolume;
    }

    void Update()
    {
        m_audioSource.volume = m_volume;
    }


    private AudioSource m_audioSource;
}
