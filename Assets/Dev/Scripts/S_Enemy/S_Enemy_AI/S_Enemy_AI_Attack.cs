using UnityEngine;
using System.Collections;

public class S_Enemy_AI_Attack : MonoBehaviour
{
    public float Damage = 20.0f;
    public float OutOfRange = 5.0f;
    public float TimeForPunch_Min = 0.5f, TimeForPunch_Max = 3.5f;

    void Start ()
    {
        m_enemy = GetComponent<S_Enemy>();
        m_transform = GetComponent<Transform>();

        FightBoxRight.enabled = false;
        FightBoxLeft.enabled = false;

        TimeForPunch_Min = 0.2f;
        TimeForPunch_Max = 1.2f;
    }
    
    void Update ()
    {
        if ( m_enemy.m_AI.m_state == Enemy_AI_State.Attack )
        {
            S_Charact_Madness.Madness += 0.015f * Time.deltaTime;

            float _dist = Mathf.Abs( m_transform.position.x - m_player_transform.position.x );

            if( _dist > 2.9f )
                Follow_Player();
            else
                Look_Player();
            
            if ( _dist > OutOfRange )
            {
                Debug.Log( "Is lost !" );
                m_lastposx = m_player_transform.position.x;
                ConeLightR.material.color = m_enemy.m_WarningColor;
                ConeLightL.material.color = m_enemy.m_WarningColor;

                m_enemy.m_AI.Start_LookAround();
            }
            else
            {
                Look_For_Friend();
                Punch();
            }
        }
    }
    
    public void Attack_Player(Transform _player_transform)
    {
        ConeLightR.material.color = m_enemy.m_DetectColor;
        ConeLightL.material.color = m_enemy.m_DetectColor;

        m_player_transform = _player_transform;
        m_enemy.m_AI.m_state = Enemy_AI_State.Attack;
    }

    private void Look_For_Friend()
    {
        float range = 50.0f;

        RaycastHit[] hits;
        hits = Physics.RaycastAll( new Vector3( m_transform.position.x - range / 2.0f, m_transform.position.y, m_transform.position.z ), new Vector3( 1.0f, 0, 0 ), range );

        for( int i = 0; i < hits.Length; i++ )
        {
            if( hits[ i ].collider.gameObject.layer == 12 )
            {
                S_Enemy enemy = hits[ i ].collider.GetComponent<S_Enemy>();

                if( enemy.m_AI.m_state != Enemy_AI_State.Attack && enemy.m_AI.m_state != Enemy_AI_State.Sleep )
                {
                    enemy.m_AI.Attack_Player( m_player_transform );
                    Debug.Log( "I help my friend !" );
                }
            }
        }
    }

    private void Follow_Player()
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

    private void Look_Player()
    {
        if( m_transform.position.x - m_player_transform.position.x > 0 )
            m_enemy.SetDirection( EnemyDirection.Left );
        else
            m_enemy.SetDirection( EnemyDirection.Right );
    }

    private void Punch()
    {
        if (!m_punch && Time.realtimeSinceStartup > m_punchTimer )
        {
            m_punch = true;
            m_punchTimer = Time.realtimeSinceStartup + Random.Range( TimeForPunch_Min, TimeForPunch_Max );

            FightBoxLeft.enabled = true;
            FightBoxRight.enabled = true;

            Debug.Log( "Enemy punch !" );
        }
        else
        {
            m_punch = false;

            FightBoxLeft.enabled = false;
            FightBoxRight.enabled = false;
        }
    }

    private S_Enemy m_enemy;

    private Transform m_transform;
    private Transform m_player_transform;

    private float m_lastposx;

    private bool m_punch;
    private float m_punchTimer;

    [HideInInspector]
    public Renderer ConeLightR, ConeLightL;
    [HideInInspector]
    public BoxCollider FightBoxRight, FightBoxLeft;
}
