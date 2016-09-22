using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class S_Enemy_AI_Attack : MonoBehaviour
{
    public float Damage = 20.0f;
    public float OutOfRange = 5.0f;
    public float TimeForPunch_Min = 0.5f, TimeForPunch_Max = 3.5f;

    void Start ()
    {
        m_enemy = GetComponent<S_Enemy>();
        m_transform = GetComponent<Transform>();
        m_animator = GetComponentInChildren<Animator>();
        m_collision = GetComponent<S_Enemy_Collision>();

        FightBox.enabled = false;

        TimeForPunch_Min = 0.2f;
        TimeForPunch_Max = 1.2f;

        m_climbLadder = false;
        m_ladderList = new List<S_Interact_Ladder>();

        if( m_enemy.m_type == EnemyType.Mafia )
        {
            m_attackSpeed = 8.5f;
            Damage = 35.0f;
            m_punchRange = 4.5f;
        }
        else
        {
            m_attackSpeed = 11.0f;
            Damage = 45.0f;
            m_punchRange = 2.5f;
        }
    }
    
    void Update ()
    {
        UpdatePunch();

        if ( m_enemy.m_AI.m_state == Enemy_AI_State.Attack )
        {
            if( S_Charact_Collision.m_isDead || m_transform.position.x > 840.0f ) //Go awai when player dead 
            {
                m_enemy.m_AI.Start_Patrol();
            }

            if (m_climbLadder)
            {
                if( Mathf.Abs( m_transform.position.x - m_currentLadder.m_PortalBottomTransform.position.x ) > 1.5f )
                {
                    if( m_transform.position.x - m_currentLadder.m_PortalBottomTransform.position.x > 0 )
                    {
                        m_enemy.SetDirection( EnemyDirection.Left );
                        m_enemy.SetVelocity( -m_attackSpeed, 0 );
                    }
                    else
                    {
                        m_enemy.SetDirection( EnemyDirection.Right );
                        m_enemy.SetVelocity( m_attackSpeed, 0 );
                    }
                }
                else
                {
                    m_transform.position = new Vector3( m_currentLadder.m_PortalTopTransform.position.x, m_currentLadder.m_PortalTopTransform.position.y + 1, m_currentLadder.m_PortalTopTransform.position.z );

                    //Debug.Log( "Climb Ladder ! " );

                    m_climbLadder = false;
                }
            }
            else
            if (m_fallLadder)
            {
                if( Mathf.Abs( m_transform.position.x - m_currentLadder.m_PortalTopTransform.position.x ) > 1.5f )
                {
                    if( m_transform.position.x - m_currentLadder.m_PortalTopTransform.position.x > 0 )
                    {
                        m_enemy.SetDirection( EnemyDirection.Left );
                        m_enemy.SetVelocity( -m_attackSpeed, 0 );
                    }
                    else
                    {
                        m_enemy.SetDirection( EnemyDirection.Right );
                        m_enemy.SetVelocity( m_attackSpeed, 0 );
                    }
                }
                else
                {
                    m_transform.position = new Vector3( m_currentLadder.m_PortalBottomTransform.position.x, m_currentLadder.m_PortalBottomTransform.position.y + 1, m_currentLadder.m_PortalBottomTransform.position.z );

                    //Debug.Log( "Fall Ladder ! " );

                    m_fallLadder = false;
                }
            }
            else
                AI();
        }
    }
    
    public void Attack_Player(Transform _player_transform)
    {
        m_enemy.SetColor( m_enemy.m_DetectColor );

        m_player_transform = _player_transform;
        m_enemy.m_AI.m_state = Enemy_AI_State.Attack;
    }

    private void AI()
    {
        S_Charact_Madness.Madness += 0.015f * Time.deltaTime;

        float _dx = Mathf.Abs( m_transform.position.x - m_player_transform.position.x );
        float _dy = Mathf.Abs( m_transform.position.y - m_player_transform.position.y );

        float _dist = new Vector2(_dx, _dy).magnitude;

        if( _dx > m_punchRange - 0.5f )
            Follow_Player();
        else
        {
            Look_Player();

            m_enemy.SetVelocity( 0, 0 );

            if( _dx < m_punchRange && !S_Charact_Collision.m_isDead )
                Punch();
        }

        if( _dist > OutOfRange )
        {
            //Debug.Log( "Is lost !" );
            m_lastposx = m_player_transform.position.x;

            m_enemy.SetColor( m_enemy.m_WarningColor );

            m_enemy.m_AI.Start_LookAround();
        }
        else
        {
            Look_For_Friend();
        }

        if( m_player_transform.position.y - m_transform.position.y > 2.0f )
        {
            float range = 30.0f;

            RaycastHit[] hits;
            hits = Physics.RaycastAll( new Vector3( m_transform.position.x - range / 2.0f, m_transform.position.y - 1f, m_transform.position.z ), new Vector3( 1.0f, 0, 0 ), range );

            for( int i = 0; i < hits.Length; i++ )
            {
                if( hits[ i ].collider.gameObject.layer == 10 )
                {
                    S_Interact_Ladder _currentLadder = hits[ i ].collider.gameObject.GetComponent<S_Interact_Ladder>();

                    if( _currentLadder != null && _currentLadder.Interact_Type == InteractType.Ladder )
                    {
                        //Debug.Log( "Ladder finded !" );
                        m_climbLadder = true;

                        m_currentLadder = _currentLadder;

                        m_ladderList.Add( m_currentLadder );
                    }
                }
            }
        }
        else
        if( m_player_transform.position.y - m_transform.position.y < -2.0f )
        {
            float range = 30.0f;

            RaycastHit[] hits;
            hits = Physics.RaycastAll( new Vector3( m_transform.position.x - range / 2.0f, m_transform.position.y - 1f, m_transform.position.z ), new Vector3( 1.0f, 0, 0 ), range );

            for( int i = 0; i < hits.Length; i++ )
            {
                if( hits[ i ].collider.gameObject.layer == 10 )
                {
                    S_Interact_Ladder _currentLadder = hits[ i ].collider.gameObject.GetComponent<S_Interact_Ladder>();

                    if( _currentLadder != null && _currentLadder != m_currentLadder && _currentLadder.Interact_Type == InteractType.Ladder && _currentLadder.m_PortalBottomTransform.position.y < m_transform.position.y - 2.0f )
                    {
                        //Debug.Log( "Ladder finded !" );
                        m_fallLadder = true;

                        m_currentLadder = _currentLadder;
                    }
                }
            }

            if (!m_fallLadder && m_ladderList.Count > 0)
            {
                m_currentLadder = m_ladderList[ m_ladderList.Count - 1 ];
                m_ladderList.RemoveAt( m_ladderList.Count - 1 );

                //Debug.Log( "Last Ladder !" );
                m_fallLadder = true;
            }
        }
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

                if( enemy.m_AI.m_state != Enemy_AI_State.Attack && enemy.m_AI.m_state != Enemy_AI_State.Sleep && enemy.m_AI.m_state != Enemy_AI_State.Dead )
                {
                    enemy.m_AI.Attack_Player( m_player_transform );
                }
            }
        }
    }

    private void Follow_Player()
    {
        m_enemy.SetVelocity( 0, 0 );

        if( m_transform.position.x - m_player_transform.position.x > 0 )
        {
            m_enemy.SetDirection( EnemyDirection.Left );
            m_enemy.SetVelocity( -m_attackSpeed, 0 );
        }
        else
        {
            m_enemy.SetDirection( EnemyDirection.Right );
            m_enemy.SetVelocity( m_attackSpeed, 0 );
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
        if (!m_punch && !m_enemy.m_isKo)
        {
            if ( Time.realtimeSinceStartup > m_punchTimer )
            {
                int _anim;

                if (m_enemy.m_type == EnemyType.Mafia)
                {
                    _anim = Random.Range( 0, 2 );
                    m_punchTimer = Time.realtimeSinceStartup + 1.0f;
                }
                else //if( m_enemy.m_type == EnemyType.Cultist )
                {
                    _anim = Random.Range( 0, 1 );
                    m_punchTimer = Time.realtimeSinceStartup + 1.9f;
                }

                m_animator.SetInteger( "Attack", _anim );
                m_animator.SetTrigger( "IsAttacking" );

                m_punch = true;

                m_boxPunch = true;

                if ( _anim == 0)
                    m_boxPunchTimer = Time.realtimeSinceStartup + 0.85f;
                else
                    m_boxPunchTimer = Time.realtimeSinceStartup + 0.5f;
            }
        }
    }

    private void UpdatePunch()
    {
        if (m_punch)
        {
            if ( m_boxPunch && Time.realtimeSinceStartup > m_boxPunchTimer )
            {
                FightBox.enabled = true;
                m_boxPunch = false;
                m_unPunch = true;

                m_UnpunchTimer = Time.realtimeSinceStartup + 0.1f;
            }

            if( m_unPunch && Time.realtimeSinceStartup > m_UnpunchTimer )
            {
                m_punch = false;
                m_unPunch = false;
                FightBox.enabled = false;
            }
        }
    }

    private float m_punchRange;
    private float m_attackSpeed;

    private S_Enemy m_enemy;
    private Animator m_animator;
    private S_Enemy_Collision m_collision;

    private Transform m_transform;
    private Transform m_player_transform;

    private float m_lastposx;

    private bool m_punch;
    private float m_punchTimer;
    private float m_UnpunchTimer;

    private float m_boxPunchTimer;
    private bool m_boxPunch;
    private bool m_unPunch;

    private bool m_climbLadder;
    private bool m_fallLadder;
    private S_Interact_Ladder m_currentLadder;

    public List<S_Interact_Ladder> m_ladderList;

    //[HideInInspector]
    public SpriteRenderer ConeLight;
    //[HideInInspector]
    public BoxCollider FightBox;
}
