using UnityEngine;
using System.Collections;

public class S_AudioMusic : MonoBehaviour
{


    public float m_volume;

    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
        m_volume = (float)S_AudioManager.GlobalVolume / 100f * (float)S_AudioManager.MusicVolume / 100f;
        // S_AudioManager.GlobalVolume;
    }

    void Update()
    {
        m_audioSource.volume = m_volume;
    }


    private AudioSource m_audioSource;
}
