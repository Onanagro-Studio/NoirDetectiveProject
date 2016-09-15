using UnityEngine;
using System.Collections;

public class S_Enemy : MonoBehaviour
{
    public EnemyDirection m_direction;
    public Color m_PatrolColor = Color.white,
                 m_WarningColor = Color.yellow,
                 m_DetectColor = Color.red;

    public float SpeedDivisor = 30.0f;

    void Start()
    {
        m_AI = GetComponent<S_Enemy_AI>();
        m_transform = GetComponent<Transform>();
        m_highlight = GetComponent<S_HighlightObject>();
        m_animator = GetComponentInChildren<Animator>();
        m_body = GetComponent<Rigidbody>();
    }
	
    #region Direction
    public void SetDirection(EnemyDirection _direction)
    {
        m_direction = _direction;

        switch( m_direction )
        {
            case EnemyDirection.Left:
                m_transform.localScale = new Vector3( -1, m_transform.localScale.y, m_transform.localScale.z );
                break;
            case EnemyDirection.Right:
                m_transform.localScale = new Vector3( 1, m_transform.localScale.y, m_transform.localScale.z );
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

    public void SetVelocity(float _dx, float _dy)
    {
        m_body.velocity = new Vector3( _dx, m_body.velocity.y );
        m_animator.SetFloat( "Speed", _dx / SpeedDivisor );
    }
    #endregion

    #region Color
    public void SetColor(Color _color)
    {
        m_highlight.m_HighlightColor = _color;
    }
    #endregion

    private Transform m_transform;
    private S_HighlightObject m_highlight;
    private Rigidbody m_body;
    private Animator m_animator;

    public S_Enemy_AI m_AI;
    public bool m_isKo;
    public bool m_isDead;
}
