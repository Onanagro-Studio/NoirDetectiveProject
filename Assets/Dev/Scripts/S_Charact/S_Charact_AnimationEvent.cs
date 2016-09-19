using UnityEngine;
using System.Collections;
using Spine.Unity;

public class S_Charact_AnimationEvent : MonoBehaviour
{
    [SpineEvent]
    public string footstep1EventName;
    [SpineEvent]
    public string footstep2EventName;

    public GameObject Footstep;

    void Start ()
    {
        m_skeletonAnimation = GetComponent<Animator>();

        m_footStepSounds = Footstep.GetComponentsInChildren<AudioSource>();
    }

    public void PrintEvent(string _event)
    {
        if (_event == "FootStep" )
            m_footStepSounds[ Random.Range( 0, m_footStepSounds.Length ) ].Play();
    }

    private AudioSource[] m_footStepSounds;
    private Animator m_skeletonAnimation;
}
