using UnityEngine;
using System.Collections;

public class S_Enemy_AI_Sleep : MonoBehaviour
{
    public float MinSleepTime = 10.0f;
    public float MaxSleepTime = 20.0f;

    void Start ()
    {
        m_enemy_AI = GetComponent<S_Enemy_AI>();
    }

	void Update ()
    {
        if (m_enemy_AI.m_state == EnemyAction.Sleep)
        {
            if( Time.realtimeSinceStartup > m_sleepTimer )
            {
                m_enemy_AI.SetColor( Color.white );
                m_enemy_AI.Start_Patrol();
            }
        }
    }

    public void Start_Sleep(float _time)
    {
        m_enemy_AI.m_state = EnemyAction.Sleep;
        m_sleepTimer = Time.realtimeSinceStartup + _time;

        m_enemy_AI.SetColor( Color.green );
        //Debug.Log( "Sleep :" + _time );
    }

    public void Start_SleepRandom()
    {
        Start_Sleep( Random.Range( MinSleepTime, MaxSleepTime ) );
    }

    private S_Enemy_AI m_enemy_AI;
    private float m_sleepTimer;
}
