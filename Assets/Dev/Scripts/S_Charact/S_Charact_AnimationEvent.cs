using UnityEngine;
using System.Collections;
using Spine.Unity;

public class S_Charact_AnimationEvent : MonoBehaviour
{
    public GameObject Footstep_Sounds;
    public GameObject Punch_Sounds;

    void Start ()
    {
        m_skeletonAnimation = GetComponent<Animator>();

        m_footStepSounds = Footstep_Sounds.GetComponentsInChildren<AudioSource>();
        m_punchAudioSources = Punch_Sounds.GetComponentsInChildren<AudioSource>();
    }

    public void PrintEvent(string _event)
    {
        Debug.Log( _event );

        if (_event == "FootStep" )
        {
            int _count = Random.Range( 0, m_footStepSounds.Length );
            Debug.Log( _count );
            m_footStepSounds[ _count ].Play();
        }

        if (_event == "Punch")
            m_punchAudioSources[ Random.Range( 0, m_punchAudioSources.Length ) ].Play();
    }

    private AudioSource[] m_footStepSounds;
    private AudioSource[] m_punchAudioSources;

    private Animator m_skeletonAnimation;
}
