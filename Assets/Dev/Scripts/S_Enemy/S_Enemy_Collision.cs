using UnityEngine;
using System.Collections;

public class S_Enemy_Collision : MonoBehaviour
{
    public GameObject ConeLightObject;

	void Start ()
    {
        m_hinted = false;
        m_enemy = GetComponent<S_Enemy>();
        m_animator = GetComponentInChildren<Animator>();

        m_life = 3;
    }
	
	void Update ()
    {
	    if ( m_hinted && Time.realtimeSinceStartup > m_hintTimer )
        {
            m_hinted = false;
            m_enemy.SetColor( Color.white );
        }

        if (m_hint && !m_enemy.m_isDead )
        {
            m_hint = false;

            Hint();

            if( m_charact.m_animCount == 2 )
                m_life -= 2;
            else
                m_life--;

            if( m_life < 0 )
            {
                if (!m_enemy.m_isKo)
                    Ko();
                else
                {
                    if( !m_enemy.m_isDead && m_charact.m_isStomp )
                        Death();
                }
            }
            else
            {
                Damage();
            }
        }
	}
    
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 11)
        {
            if( !m_charact )
                m_charact = collision.gameObject.GetComponentInParent<S_Charact_Controller>();
            
            if( m_enemy.m_AI.m_state != Enemy_AI_State.Attack )
                m_life = -1;

            m_hint = true;
        }
    }
    
    private void Hint()
    {
        if ( !m_enemy.m_isKo )
        {
            m_enemy.SetColor( Color.red );
            m_hinted = true;
            m_hintTimer = Time.realtimeSinceStartup + 0.1f;
        }
    }

    private void Ko()
    {
        Debug.Log( "Ko" );

        ConeLightObject.SetActive( false );
        
        m_hinted = false;

        m_enemy.m_isKo = true;
        m_enemy.SetVelocity( 0, 0 );
        m_enemy.m_AI.Start_SleepRandom();

        m_animator.SetTrigger( "IsDead" );
    }

    private void Damage()
    {
        m_animator.SetInteger( "TakeDamage", Random.Range( 0, 2 ) );
        m_animator.SetTrigger( "IsDamaged" );
    }

    private void Death()
    {
        Debug.Log( "Dead" );

        m_hinted = false;
        
        m_enemy.SetColor( new Color(0, 0, 0, 0) );
        m_enemy.m_isDead = true;
        m_enemy.m_AI.m_state = Enemy_AI_State.Dead;
    }

    private Animator m_animator;
    private int m_life;
    private float m_hintTimer;
    private bool m_hinted;
    private bool m_hint;
    private S_Enemy m_enemy;

    private S_Charact_Controller m_charact;
}
