using UnityEngine;
using System.Collections;

public class S_Enemy_AI : MonoBehaviour
{
    public float RandomWaitTime = 5.0f;

    public float WalkSpeedMin = 1.0f;
    public float WalkSpeedMax = 2.5f;

    public float RandomMoveMin = 13.0f;
    public float RandomMoveMax = 35.0f;

    void Start ()
    {
        m_transform = GetComponent<Transform>();

        //Debug.Log( "Init AI ...");
        Random_Wait( RandomWaitTime );
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
    private float WaitTimer;

    private void Random_Wait(float _range)
    {
        m_state = EnemyAction.Waiting;

        float _waittime = Random.Range( 0.5f, _range );
        WaitTimer = Time.realtimeSinceStartup + _waittime;

        //Debug.Log( "Waiting: " + _waittime );
    }

    private void Wait_AI()
    {
        if (Time.realtimeSinceStartup > WaitTimer )
        {
            Random_Walk( RandomMoveMin, RandomMoveMax );
        }
    }
    #endregion

    #region AI Walk
    private Vector3 m_walk_dest;
    private float m_walk_speed;

    private void Random_Walk(float _min, float _max)
    {
        m_state = EnemyAction.Walk;
        
        float _dest = Random.Range( _min, _max );
        float _dir = RandomSign();

        m_walk_dest = new Vector3( m_transform.position.x + _dest * _dir, m_transform.position.y, m_transform.position.z );

        m_walk_speed = Random.Range( WalkSpeedMin, WalkSpeedMax );

        if ( _dir == 1)
            m_transform.localScale = new Vector3( 0.75f, 0.75f, 1 );
        else
            m_transform.localScale = new Vector3( -0.75f, 0.75f, 1 );

        //Debug.Log( "Range: " + _dest + " Dest: " + m_walk_dest );
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
    private void Attack_AI()
    {

    }
    #endregion

    #region Utils
    private int RandomSign()
    {
        return Random.value < .5 ? 1 : -1;
    }
    #endregion

private Transform m_transform;
    private EnemyAction m_state;
}

enum EnemyAction
{
    Waiting,
    Walk,
    Attack,
    WatchingDuck
}
