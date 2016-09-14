using UnityEngine;
using System.Collections;

public class S_Enemy_AI_Sleep : MonoBehaviour
{
    public float MinSleepTime = 10.0f;
    public float MaxSleepTime = 20.0f;

    void Start ()
    {
        m_enemy = GetComponent<S_Enemy>();
    }

	void Update ()
    {
        if ( m_enemy.m_AI.m_state == Enemy_AI_State.Sleep)
        {
            if( Time.realtimeSinceStartup > m_sleepTimer )
            {
                m_enemy.SetColor( Color.white );
                m_enemy.m_AI.Start_Patrol();
            }
        }
    }

    public void Start_Sleep(float _time)
    {
        m_enemy.m_AI.m_state = Enemy_AI_State.Sleep;
        m_sleepTimer = Time.realtimeSinceStartup + _time;

        m_enemy.SetColor( Color.green );
        m_enemy.SetVelocity( 0, 0 );
    }

    public void Start_SleepRandom()
    {
        Start_Sleep( Random.Range( MinSleepTime, MaxSleepTime ) );
    }

    private S_Enemy m_enemy;
    private float m_sleepTimer;
}
