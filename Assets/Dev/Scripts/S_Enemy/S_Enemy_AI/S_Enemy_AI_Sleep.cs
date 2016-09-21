using UnityEngine;
using System.Collections;

public class S_Enemy_AI_Sleep : MonoBehaviour
{
    public float MinSleepTime = 10.0f;
    public float MaxSleepTime = 20.0f;

    public GameObject ConeLightObject;
    public GameObject StunIcon;

    void Start ()
    {
        m_enemy = GetComponent<S_Enemy>();
        m_animator = GetComponentInChildren<Animator>();
    }

	void Update ()
    {
        if ( m_enemy.m_AI.m_state == Enemy_AI_State.Sleep)
        {
            if( Time.realtimeSinceStartup > m_sleepTimer )
            {
                m_enemy.SetColor( m_enemy.m_PatrolColor );
                m_enemy.m_isKo = false;
                m_animator.SetTrigger( "IsWaking" );
                StunIcon.SetActive(false);

                m_waitforcone = true;
                m_coneTimer = Time.realtimeSinceStartup + 1.5f;
                m_enemy.m_AI.Start_Patrol();
            }
        }

        if (m_waitforcone && Time.realtimeSinceStartup > m_coneTimer)
        {
            m_waitforcone = false;
            ConeLightObject.SetActive(true);
        }
    }

    public void Start_Sleep(float _time)
    {
        m_enemy.m_AI.m_state = Enemy_AI_State.Sleep;
        m_sleepTimer = Time.realtimeSinceStartup + _time;//Time.realtimeSinceStartup + _time;

        m_enemy.SetColor( new Color( 255, 128, 128));
        m_enemy.SetVelocity( 0, 0 );
    }

    public void Start_SleepRandom()
    {
        Start_Sleep( Random.Range( MinSleepTime, MaxSleepTime ) );
    }

    private bool m_waitforcone;
    private float m_coneTimer;
    private Animator m_animator;
    private S_Enemy m_enemy;
    private float m_sleepTimer;
}
