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

    void Start ()
    {
        m_enemy_AI = GetComponent<S_Enemy_AI>();

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
        if( m_enemy_AI.m_state == EnemyAction.Walk || m_enemy_AI.m_state == EnemyAction.Patrol )
        {
            if( (m_transform.position.x < m_min_flag || m_transform.position.x > m_max_flag) && m_enemy_AI.m_state == EnemyAction.Patrol )
            {
                Start_Return_Area();
            }

            if( Mathf.Abs( m_transform.position.x - m_walk_dest.x ) < 1.5f )
            {
                m_enemy_AI.Wait();
            }
            else
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
        }
    }
    
    public void Start_Patrol()
    {
        if( (m_transform.position.x < m_min_flag || m_transform.position.x > m_max_flag) )
        {
            Start_Return_Area();
        }
        else
        {
            m_enemy_AI.m_state = EnemyAction.Patrol;

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
                    m_transform.localScale = new Vector3( 1, 1, 1 );
                else
                    m_transform.localScale = new Vector3( -1, 1, 1 );

                //Debug.Log( "Move: " + _dest + ", Speed: " + m_walk_speed );
            }
            else
            {
                m_enemy_AI.Wait();
            }
        }
    }

    private void Start_Return_Area()
    {
        m_enemy_AI.m_state = EnemyAction.Walk;

        m_walk_dest = new Vector3( Random.Range( m_min_flag + m_random_move_min, m_max_flag - m_random_move_min ), 0, 0 );
        
        if( m_walk_dest.x > m_transform.position.x )
            m_transform.localScale = new Vector3( 1, 1, 1 );
        else
            m_transform.localScale = new Vector3( -1, 1, 1 );

        //Debug.Log( "Out of Area ==> return" );
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

    private S_Enemy_AI m_enemy_AI;
    private Transform m_transform;
}
