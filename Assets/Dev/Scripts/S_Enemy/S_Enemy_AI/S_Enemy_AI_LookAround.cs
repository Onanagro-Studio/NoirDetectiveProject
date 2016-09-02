using UnityEngine;
using System.Collections;

public class S_Enemy_AI_LookAround : MonoBehaviour
{
    public float RandomLookTime_Min = 8.0f;
    public float RandomLookTime_Max = 15.0f;

    public float WalkSpeedMin = 0.5f;
    public float WalkSpeedMax = 1.5f;

    void Start ()
    {
        m_enemy = GetComponent<S_Enemy>();
        m_transform = GetComponent<Transform>();
    }
    
    void Update ()
    {
        if ( m_enemy.m_AI.m_state == Enemy_AI_State.LookAround )
        {
            if ( Time.realtimeSinceStartup > m_lookTimer )
            {
                m_enemy.m_AI.Start_Patrol();
            }
            else
            {
                if( Time.realtimeSinceStartup > m_FlipTimer )
                {
                    m_enemy.InvertDirection();
                    
                    m_FlipTimer = Time.realtimeSinceStartup + m_FlipTime;

                    m_walk_speed = -m_walk_speed;
                }
                else
                {
                    m_transform.position = new Vector3( m_transform.position.x + m_walk_speed * Time.deltaTime, m_transform.position.y, m_transform.position.z );
                }
            }
        }
    }
    
    public void Start_LookAround()
    {
        m_enemy.m_AI.m_state = Enemy_AI_State.LookAround;

        float _looktime = Random.Range( RandomLookTime_Min, RandomLookTime_Max );
        m_lookTimer = Time.realtimeSinceStartup + _looktime;

        m_FlipTime = _looktime / Random.Range(1.5f, 4.5f);
        m_FlipTimer = Time.realtimeSinceStartup + m_FlipTime;

        m_walk_speed = Random.Range( WalkSpeedMin, WalkSpeedMax );

        if( m_enemy.m_direction == EnemyDirection.Left ) m_walk_speed *= -1;
          

        Debug.Log( "Look Around for: " + _looktime + ", flip time: " + m_FlipTime );
    }

    private float m_FlipTime;
    private float m_FlipTimer;

    private float m_lookTimer;

    private float m_walk_speed;

    private S_Enemy m_enemy;
    private Transform m_transform;
}
