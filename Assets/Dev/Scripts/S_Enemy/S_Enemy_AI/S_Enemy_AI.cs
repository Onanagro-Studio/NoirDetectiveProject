using UnityEngine;
using System.Collections;

public class S_Enemy_AI : MonoBehaviour
{
    public EnemyAction m_state;
    public EnemyDirection m_direction;


    void Start ()
    {
        Debug.Log( "Init AI ..." );

        m_AI_Attack = GetComponent<S_Enemy_AI_Attack>();
        m_AI_Wait = GetComponent<S_Enemy_AI_Wait>();
        m_AI_Walk = GetComponent<S_Enemy_AI_Walk>();
        m_AI_LookAround = GetComponent<S_Enemy_AI_LookAround>();
        m_AI_Sleep = GetComponent<S_Enemy_AI_Sleep>();

        m_AI_Wait.Init(this);
        Wait( 0.1f );
    }

    #region Attack
    public void Attack_Player(Transform _player_transform)
    {
        m_AI_Attack.Attack_Player( _player_transform );
    }
    #endregion

    #region Wait
    public void Wait()
    {
        m_AI_Wait.Wait();
    }

    public void Wait(float _max)
    {
        m_AI_Wait.Wait( _max );
    }
    #endregion

    #region Walk
    public void Start_Patrol()
    {
        m_AI_Walk.Start_Patrol();
    }
    #endregion
    
    #region LookAround
    public void Start_LookAround()
    {
        m_AI_LookAround.Start_LookAround();
    }
    #endregion

    #region Sleep
    public void Start_SleepRandom()
    {
        m_AI_Sleep.Start_SleepRandom();
    }
    #endregion

    #region Direction

    public void SetDirection(EnemyDirection _direction)
    {
        m_direction = _direction;

        switch( m_direction )
        {
            case EnemyDirection.Left:
                 m_SpriteLeft.SetActive( true );
                 m_SpriteRight.SetActive( false );
                break;
            case EnemyDirection.Right:
                m_SpriteRight.SetActive( true );
                m_SpriteLeft.SetActive( false );
                break;
            default:
                break;
        }

    }
    public void InvertDirection()
    {
        

        switch( m_direction )
        {
            case EnemyDirection.Left:
                SetDirection( EnemyDirection.Right );
                break;
            case EnemyDirection.Right:
                SetDirection( EnemyDirection.Left );
                break;
            default:
                break;
        }

    }

    #endregion

    private S_Enemy_AI_Attack m_AI_Attack;
    private S_Enemy_AI_Wait m_AI_Wait;
    private S_Enemy_AI_Walk m_AI_Walk;
    private S_Enemy_AI_LookAround m_AI_LookAround;
    private S_Enemy_AI_Sleep m_AI_Sleep;

    [HideInInspector]
    public GameObject m_SpriteRight, m_SpriteLeft;
}

public enum EnemyAction
{
    Waiting,
    Walk,
    Patrol,
    Attack,
    LookAround,
    Sleep
}

public enum EnemyDirection
{
    Left,
    Right

}
