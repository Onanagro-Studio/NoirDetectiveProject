using UnityEngine;
using System.Collections;

public class S_Enemy_AI_Wait : MonoBehaviour
{
    public bool RandomTime = true;
    public float WaitTime = 5.0f;

    void Start()
    {

    }

    public void Init(S_Enemy_AI _enemy_AI)
    {
        m_enemy_AI = _enemy_AI;
    }
    
    void Update ()
    {
        if ( m_enemy_AI.m_state == Enemy_AI_State.Waiting )
        {
            if( Time.realtimeSinceStartup > m_waitTimer )
            {
                m_enemy_AI.Start_Patrol();
            }
        }
    }
    
    public void Wait()
    {
        m_enemy_AI.m_state = Enemy_AI_State.Waiting;

        if (RandomTime)
        {
            float _waittime = Random.Range( 0.5f, WaitTime );
            m_waitTimer = Time.realtimeSinceStartup + _waittime;
        }
        else
        { 
            m_waitTimer = Time.realtimeSinceStartup + WaitTime;
        }
    }

    public void Wait(float _max)
    {
        m_enemy_AI.m_state = Enemy_AI_State.Waiting;

        float _waittime = Random.Range( 0.5f, _max );
        m_waitTimer = Time.realtimeSinceStartup + _waittime;
    }
    
    private float m_waitTimer;
    private S_Enemy_AI m_enemy_AI;
}
