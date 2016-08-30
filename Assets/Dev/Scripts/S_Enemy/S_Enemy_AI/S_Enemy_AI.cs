using UnityEngine;
using System.Collections;

public class S_Enemy_AI : MonoBehaviour
{
    public EnemyAction m_state;

    void Start ()
    {
        Debug.Log( "Init AI ..." );

        m_AI_Attack = GetComponent<S_Enemy_AI_Attack>();
        m_AI_Wait = GetComponent<S_Enemy_AI_Wait>();
        m_AI_Walk = GetComponent<S_Enemy_AI_Walk>();

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

    private S_Enemy_AI_Attack m_AI_Attack;
    private S_Enemy_AI_Wait m_AI_Wait;
    private S_Enemy_AI_Walk m_AI_Walk;
}

public enum EnemyAction
{
    Waiting,
    Walk,
    Patrol,
    Attack,
    LookAround
}
