using UnityEngine;
using System.Collections;

public class S_Enemy : MonoBehaviour
{
    public EnemyDirection m_direction;
    public Color m_PatrolColor = Color.white,
                 m_WarningColor = Color.yellow,
                 m_DetectColor = Color.red;
    
    void Start()
    {
        m_spriteRendererRight = m_SpriteRight.GetComponent<SpriteRenderer>();
        m_spriteRendererLeft = m_SpriteLeft.GetComponent<SpriteRenderer>();

        m_AI = GetComponent<S_Enemy_AI>();
    }
	
    void Update()
    {

    }

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

    #region Color
    public void SetColor(Color _color)
    {
        m_spriteRendererLeft.color = _color;
        m_spriteRendererRight.color = _color;
    }
    #endregion

    private SpriteRenderer m_spriteRendererRight;
    private SpriteRenderer m_spriteRendererLeft;

    [HideInInspector]
    public S_Enemy_AI m_AI;
    [HideInInspector]
    public GameObject m_SpriteRight, m_SpriteLeft;
}
