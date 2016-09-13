using UnityEngine;
using System.Collections;

public class S_Enemy_AI_Walk : MonoBehaviour
{
    public GameObject Flags_Pool;

    public GameObject Min_Flag;
    public GameObject Max_Flag;

    public int MaxCountRandomWalk = 5;

    public float WalkSpeedMin = 1.0f;
    public float WalkSpeedMax = 2.5f;

    public WalkStyle Walk_Style = WalkStyle.Random;
    public bool CanFlip = true;

    void Start ()
    {
        m_enemy = GetComponent<S_Enemy>();
        m_enemyAttack = GetComponent<S_Enemy_AI_Attack>();

        m_transform = GetComponent<Transform>();

        m_min_flag = Min_Flag.GetComponent<Transform>().position.x;
        m_max_flag = Max_Flag.GetComponent<Transform>().position.x;

        Min_Flag.GetComponent<Transform>().parent = Flags_Pool.GetComponent<Transform>();
        Max_Flag.GetComponent<Transform>().parent = Flags_Pool.GetComponent<Transform>();

        if( m_min_flag > m_max_flag )
        {
            float _min = m_min_flag;
            m_min_flag = m_max_flag;
            m_max_flag = _min;
        }

        float _range = Mathf.Abs(m_min_flag - m_max_flag);

        m_random_move_min = _range / 5.0f;
        m_random_move_max = _range / 1.5f;
    }
    
    void Update ()
    {
        if( m_enemy.m_AI.m_state == Enemy_AI_State.Walk || m_enemy.m_AI.m_state == Enemy_AI_State.Patrol )
        {
            if( (m_transform.position.x < m_min_flag || m_transform.position.x > m_max_flag) && m_enemy.m_AI.m_state == Enemy_AI_State.Patrol )
            {
                Start_Return_Area();
            }

            if( Mathf.Abs( m_transform.position.x - m_walk_dest.x ) < 1.5f )
            {
                m_enemy.m_AI.Wait();
            }
            else
            {
                if (!m_needLadder && m_enemyAttack.m_ladderList.Count != 0)
                {
                    m_needLadder = true;
                    m_currentLadder = m_enemyAttack.m_ladderList[ m_enemyAttack.m_ladderList.Count - 1 ];
                    m_enemyAttack.m_ladderList.RemoveAt( m_enemyAttack.m_ladderList.Count - 1 );
                    Debug.Log( "Doit prendre l'echelle :/" );
                }
                
                if ( !m_needLadder )
                {
                    if( m_transform.position.x - m_walk_dest.x > 0 )
                    {
                        m_transform.position = new Vector3( m_transform.position.x - m_walk_speed * Time.deltaTime, m_transform.position.y, m_transform.position.z );
                    }
                    else
                    {
                        m_transform.position = new Vector3( m_transform.position.x + m_walk_speed * Time.deltaTime, m_transform.position.y, m_transform.position.z );
                    }
                }
                else
                {
                    if( Mathf.Abs( m_transform.position.x - m_currentLadder.m_PortalTopTransform.position.x ) > 1.5f )
                    {
                        if( m_transform.position.x - m_currentLadder.m_PortalTopTransform.position.x > 0 )
                        {
                            m_enemy.SetDirection( EnemyDirection.Left );
                            m_transform.position = new Vector3( m_transform.position.x - m_walk_speed * Time.deltaTime, m_transform.position.y, m_transform.position.z );
                        }
                        else
                        {
                            m_enemy.SetDirection( EnemyDirection.Right );
                            m_transform.position = new Vector3( m_transform.position.x + m_walk_speed * Time.deltaTime, m_transform.position.y, m_transform.position.z );
                        }
                    }
                    else
                    {
                        m_transform.position = new Vector3( m_transform.position.x, m_currentLadder.m_PortalBottomTransform.position.y + 1.0f, m_transform.position.z );

                        Debug.Log( "Fall Ladder ! " );

                        m_needLadder = false;
                    }
                }
            }
        }
    }
    
    public void Start_Patrol()
    {
        ConeLightR.material.color = m_enemy.m_PatrolColor;
        ConeLightL.material.color = m_enemy.m_PatrolColor;

        if( (m_transform.position.x < m_min_flag || m_transform.position.x > m_max_flag) )
        {
            Start_Return_Area();
        }
        else
        {
            m_enemy.m_AI.m_state = Enemy_AI_State.Patrol;

            if (Walk_Style == WalkStyle.Random)
            {
                Start_Random_Patrol();
            }
            else
            if (Walk_Style == WalkStyle.Defined)
            {
                Start_Defined_Patrol();
            }
            else
            {
                if ( CanFlip )
                {
                    if( m_enemy.m_direction == EnemyDirection.Left )
                        m_enemy.SetDirection( EnemyDirection.Right );
                    else
                        m_enemy.SetDirection( EnemyDirection.Left );
                }

                m_enemy.m_AI.Wait();
            }
        }
    }

    private void Start_Random_Patrol()
    {
        bool _correct_dest = false;

        int _count = 0;
        float _dest = 0;
        float _dir = 0;

        while( !_correct_dest && _count < MaxCountRandomWalk )
        {
            float _range = Random.Range( m_random_move_min, m_random_move_max );

            _dir = RandomSign();
            _dest = m_transform.position.x + _range * _dir;

            if( _dest > m_min_flag && _dest < m_max_flag )
                _correct_dest = true;

            _count++;
        }

        if( _correct_dest )
        {
            m_walk_dest = new Vector3( _dest, m_transform.position.y, m_transform.position.z );
            m_walk_speed = Random.Range( WalkSpeedMin, WalkSpeedMax );

            if( _dir == 1 )
                m_enemy.SetDirection( EnemyDirection.Right );
            else
                m_enemy.SetDirection( EnemyDirection.Left );

            //Debug.Log( "Move: " + _dest + ", Speed: " + m_walk_speed );
        }
        else
        {
            m_enemy.m_AI.Wait();
        }
    }

    private void Start_Defined_Patrol()
    {
        m_walk_speed = WalkSpeedMax;

        if( Mathf.Abs( m_transform.position.x - m_min_flag ) < 1.5f )
        {
            m_walk_dest = new Vector3( m_max_flag, m_transform.position.y, m_transform.position.z );
            m_enemy.SetDirection( EnemyDirection.Right );
        }
        else
        {
            m_walk_dest = new Vector3( m_min_flag, m_transform.position.y, m_transform.position.z );
            m_enemy.SetDirection( EnemyDirection.Left );
        }
    }

    private void Start_Return_Area()
    {
        m_enemy.m_AI.m_state = Enemy_AI_State.Walk;

        m_walk_dest = new Vector3( Random.Range( m_min_flag + m_random_move_min, m_max_flag - m_random_move_min ), 0, 0 );
        
        if( m_walk_dest.x > m_transform.position.x )
            m_enemy.SetDirection( EnemyDirection.Right );
        else
            m_enemy.SetDirection( EnemyDirection.Left );
    }

    #region Utils
    private int RandomSign()
    {
        return Random.value < .5 ? 1 : -1;
    }
    #endregion

    private Vector3 m_walk_dest;
    private float m_walk_speed;

    private float m_min_flag;
    private float m_max_flag;

    private float m_random_move_min;
    private float m_random_move_max;

    private S_Enemy m_enemy;
    private Transform m_transform;

    private bool m_needLadder;
    private S_Interact_Ladder m_currentLadder;
    private S_Enemy_AI_Attack m_enemyAttack;

    [HideInInspector]
    public Renderer ConeLightR, ConeLightL;

}

public enum WalkStyle
{
    Random,
    Defined,
    Sentry
}
