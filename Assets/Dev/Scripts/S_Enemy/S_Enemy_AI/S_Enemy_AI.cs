using UnityEngine;
using System.Collections;

public class S_Enemy_AI : MonoBehaviour
{
    public Enemy_AI_State m_state;

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
    
    private S_Enemy_AI_Attack m_AI_Attack;
    private S_Enemy_AI_Wait m_AI_Wait;
    private S_Enemy_AI_Walk m_AI_Walk;
    private S_Enemy_AI_LookAround m_AI_LookAround;
    private S_Enemy_AI_Sleep m_AI_Sleep;
}

public enum Enemy_AI_State
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
