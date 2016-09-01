using UnityEngine;
using System.Collections;

public class S_Enemy_AI_Wait : MonoBehaviour
{
    public float RandomWaitTime = 5.0f;

    void Start()
    {

    }

    public void Init(S_Enemy_AI _enemy_AI)
    {
        m_enemy_AI = _enemy_AI;
    }
    
    void Update ()
    {
        if ( m_enemy_AI.m_state == EnemyAction.Waiting )
        {
            if( Time.realtimeSinceStartup > m_waitTimer )
            {
                m_enemy_AI.Start_Patrol();
            }
        }
    }
    
    public void Wait()
    {
        m_enemy_AI.m_state = EnemyAction.Waiting;

        float _waittime = Random.Range( 0.5f, RandomWaitTime );
        m_waitTimer = Time.realtimeSinceStartup + _waittime;

        //Debug.Log( "Waiting: " + _waittime );
    }

    public void Wait(float _max)
    {
        m_enemy_AI.m_state = EnemyAction.Waiting;

        float _waittime = Random.Range( 0.5f, _max );
        m_waitTimer = Time.realtimeSinceStartup + _waittime;

        //Debug.Log( "Waiting: " + _waittime );
    }

    private float m_waitTimer;
    private S_Enemy_AI m_enemy_AI;
}
