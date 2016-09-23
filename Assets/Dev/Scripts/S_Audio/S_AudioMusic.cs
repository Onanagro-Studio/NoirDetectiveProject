using UnityEngine;
using System.Collections;

public class S_AudioMusic : MonoBehaviour
{

    [Range(0,100)]
    public int m_VolumeMultiplier = 100;

    [HideInInspector]
    public float m_volume;

    void Start()
    {
        m_audioSource = GetComponents<AudioSource>();
    }

    void Update()
    {
        m_volume = (float)S_AudioManager.GlobalVolume / 100f * (float)S_AudioManager.MusicVolume / 100f * (float)m_VolumeMultiplier / 100f;

        for( int i = 0; i < m_audioSource.Length; i++ )
        {
            m_audioSource[ i ].volume = m_volume;
        }

      
    }


    private AudioSource[] m_audioSource;
}
