using UnityEngine;
using System.Collections;

public class S_Enemy_AI : MonoBehaviour
{
    public float RandomWaitTime = 5.0f;

    public float WalkSpeedMin = 1.0f;
    public float WalkSpeedMax = 2.5f;

    public GameObject Flags_Pool;
    public GameObject Min_Flag;
    public GameObject Max_Flag;

    public int MaxCountRandomWalk = 5;

    public EnemyAction m_state;

    void Start ()
    {
        Debug.Log( "Init AI ..." );

        m_transform = GetComponent<Transform>();

        m_min_flag = Min_Flag.GetComponent<Transform>().position.x;
        m_max_flag = Max_Flag.GetComponent<Transform>().position.x;

        Min_Flag.GetComponent<Transform>().parent = Flags_Pool.GetComponent<Transform>();
        Max_Flag.GetComponent<Transform>().parent = Flags_Pool.GetComponent<Transform>();

        if ( m_min_flag > m_max_flag )
        {
            float _min = m_min_flag;
            m_min_flag = m_max_flag;
            m_max_flag = _min;
        }

        float _range = Mathf.Abs(m_min_flag - m_max_flag);

        m_random_move_min = _range / 5.0f;
        m_random_move_max = _range / 1.5f;

        Random_Wait( 0.1f );
    }
	
	void Update ()
    {
        if( Input.GetKeyDown( KeyCode.G ) )
            S_SceneManager.Load_GameOver();

        if( m_state == EnemyAction.Waiting )
            Wait_AI();
        else
        if( m_state == EnemyAction.Walk )
            Walk_AI();
        else
        if( m_state == EnemyAction.Attack )
            Attack_AI();

    }

    #region AI Waiting
    private float m_waitTimer;

    private void Random_Wait(float _range)
    {
        m_state = EnemyAction.Waiting;

        float _waittime = Random.Range( 0.5f, _range );
        m_waitTimer = Time.realtimeSinceStartup + _waittime;

        Debug.Log( "Waiting: " + _waittime );
    }

    private void Wait_AI()
    {
        if (Time.realtimeSinceStartup > m_waitTimer )
        {
            Random_Walk( m_random_move_min, m_random_move_max );
        }
    }
    #endregion

    #region AI Walk
    private Vector3 m_walk_dest;
    private float m_walk_speed;

    private void Random_Walk(float _move_min, float _move_max)
    {
        m_state = EnemyAction.Walk;

        bool _correct_dest = false;

        int _count = 0;
        float _dest = 0;
        float _dir = 0;

        while( !_correct_dest && _count < MaxCountRandomWalk )
        {
            float _range = Random.Range( _move_min, _move_max );

            _dir = RandomSign();
            _dest = m_transform.position.x + _range * _dir;

            if( _dest > m_min_flag && _dest < m_max_flag )
                _correct_dest = true;

            _count++;
        }
        
        if ( _correct_dest )
        {
            m_walk_dest = new Vector3( _dest, m_transform.position.y, m_transform.position.z );
            m_walk_speed = Random.Range( WalkSpeedMin, WalkSpeedMax );

            if( _dir == 1 )
                m_transform.localScale = new Vector3( 1, 1, 1 );
            else
                m_transform.localScale = new Vector3( -1, 1, 1 );

            Debug.Log( "Move: " + _dest + ", Speed: " + m_walk_speed );
        }
        else
            Random_Wait( RandomWaitTime );
    }

    private void Walk_AI()
    {
        if ( Mathf.Abs(m_transform.position.x - m_walk_dest.x) < 1.5f )
        {
            Random_Wait( RandomWaitTime );
        }
        else
        {
            if ( m_transform.position.x - m_walk_dest.x > 0)
            {
                m_transform.position = new Vector3( m_transform.position.x - m_walk_speed * Time.deltaTime, m_transform.position.y, m_transform.position.z );
            }
            else
            {
                m_transform.position = new Vector3( m_transform.position.x + m_walk_speed * Time.deltaTime, m_transform.position.y, m_transform.position.z );
            }
        }
    }
    #endregion

    #region AI Attack
    public void Attack_Player(Transform _m_player_transform)
    {
        m_player_transform = _m_player_transform;
        m_state = EnemyAction.Attack;

        Debug.Log( "Attack !" );
    }

    private void Attack_AI()
    {
        if ( Mathf.Abs(m_transform.position.x - m_player_transform.position.x) > 2.6f )
        {
            if( m_transform.position.x - m_player_transform.position.x > 0 )
            {
                m_transform.localScale = new Vector3( -1, 1, 1 );
                m_transform.position = new Vector3( m_transform.position.x - 5.0f * Time.deltaTime, m_transform.position.y, m_transform.position.z );
            }
            else
            {
                m_transform.localScale = new Vector3( 1, 1, 1 );
                m_transform.position = new Vector3( m_transform.position.x + 5.0f * Time.deltaTime, m_transform.position.y, m_transform.position.z );
            }
        }
    }
    #endregion

    #region Utils
    private int RandomSign()
    {
        return Random.value < .5 ? 1 : -1;
    }
    #endregion

    private Transform m_transform;
    private Transform m_player_transform;

    private float m_min_flag;
    private float m_max_flag;

    private float m_random_move_min;
    private float m_random_move_max;
}

public enum EnemyAction
{
    Waiting,
    Walk,
    Attack,
    WatchingDuck
}
