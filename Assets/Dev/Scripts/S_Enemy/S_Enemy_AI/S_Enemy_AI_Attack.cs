using UnityEngine;
using System.Collections;

public class S_Enemy_AI_Attack : MonoBehaviour
{
   
    public float OutOfRange = 10.0f;

    void Start ()
    {
        m_enemy = GetComponent<S_Enemy>();
        m_transform = GetComponent<Transform>();
    }
    
    void Update ()
    {
        if ( m_enemy.m_AI.m_state == Enemy_AI_State.Attack )
        {
            S_MadnessBar.progress += 0.015f * Time.deltaTime;

            float _dist = Mathf.Abs( m_transform.position.x - m_player_transform.position.x );

            if( _dist > 2.6f )
            {
                if( m_transform.position.x - m_player_transform.position.x > 0 )
                {
                    m_enemy.SetDirection( EnemyDirection.Left );
                    m_transform.position = new Vector3( m_transform.position.x - 5.0f * Time.deltaTime, m_transform.position.y, m_transform.position.z );
                }
                else
                {
                    m_enemy.SetDirection( EnemyDirection.Right ); 
                    m_transform.position = new Vector3( m_transform.position.x + 5.0f * Time.deltaTime, m_transform.position.y, m_transform.position.z );
                }
            }

            if ( _dist > OutOfRange )
            {
                Debug.Log( "Is lost !" );
                m_lastposx = m_player_transform.position.x;
                ConeLightR.material.color = m_enemy.m_WarningColor;
                ConeLightL.material.color = m_enemy.m_WarningColor;

                m_enemy.m_AI.Start_LookAround();
            }
        }
    }

    public void Attack_Player(Transform _player_transform)
    {
        ConeLightR.material.color = m_enemy.m_DetectColor;
        ConeLightL.material.color = m_enemy.m_DetectColor;

        m_player_transform = _player_transform;
        m_enemy.m_AI.m_state = Enemy_AI_State.Attack;

        //Debug.Log( "Attack !" );
    }

    private S_Enemy m_enemy;

    private Transform m_transform;
    private Transform m_player_transform;

    [HideInInspector]
    public Renderer ConeLightR, ConeLightL;

    private float m_lastposx;
}
