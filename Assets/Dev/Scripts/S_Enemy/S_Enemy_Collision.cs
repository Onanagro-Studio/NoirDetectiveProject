using UnityEngine;
using System.Collections;

public class S_Enemy_Collision : MonoBehaviour
{
    public GameObject ConeLightObject;
    public GameObject DeathIcon;
    public GameObject StunIcon;
    public GameObject m_damagesIcons;

    void Start ()
    {
        m_hinted = false;
        m_enemy = GetComponent<S_Enemy>();
        m_animator = GetComponentInChildren<Animator>();
        m_collider = GetComponent<BoxCollider>();

        m_damageIconAnim = m_damagesIcons.GetComponentsInChildren<S_Anim_Loop>();

        Debug.Log( m_damageIconAnim.Length + " damage icons finded !" );

        m_life = 3;

        m_currentframe = Time.frameCount;
    }
	
	void Update ()
    {
        if(Time.frameCount > m_currentframe )
        {
            m_currentframe = Time.frameCount;
            m_anyone_frapped = false;
        }

        if ( m_hint && m_charact.m_isStomp && !m_enemy.m_isKo )
        {
            m_hint = false;
        }

        if ( (m_hint && !m_enemy.m_isKo) || (m_hint && m_charact.m_isStomp))
        {
            if ( !m_enemy.m_isDead )
            {
                if( m_anyone_frapped )
                    m_hint = false;
                else
                    m_anyone_frapped = true;
            }
        }

	    if ( m_hinted && Time.realtimeSinceStartup > m_hintTimer )
        {
            m_hinted = false;
            m_enemy.SetColor( new Color(255, 127, 127) );
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
            
            if( !m_enemy.m_isKo )
                m_damageIconAnim[ Random.Range( 0, m_damageIconAnim.Length ) ].Restart();
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

        Update_BoxCollider( true );

        m_animator.SetTrigger( "IsDead" );

        StunIcon.SetActive( true );

        m_life = 3;
    }

    private void Damage()
    {
        if ( !m_enemy.m_isKo )
        {
            m_animator.SetInteger( "TakeDamage", Random.Range( 0, 2 ) );
            m_animator.SetTrigger( "IsDamaged" );
        }
    }

    private void Death()
    {
        Debug.Log( "Dead" );

        m_hinted = false;
        
        m_enemy.SetColor( new Color(0, 0, 0, 0) );
        m_enemy.m_isDead = true;
        m_enemy.m_AI.m_state = Enemy_AI_State.Dead;

        StunIcon.SetActive( false );
        DeathIcon.SetActive( true );
    }

    private void Update_BoxCollider(bool _ko)
    {
        if ( _ko )
        {
            m_collider.size = new Vector3( 4, m_collider.size.y, m_collider.size.z );
            m_collider.center = new Vector3( 2, m_collider.center.y, m_collider.center.z );
        }
        else
        {
            m_collider.size = new Vector3( 2, m_collider.size.y, m_collider.size.z );
            m_collider.center = new Vector3( 0, m_collider.center.y, m_collider.center.z );
        }
    }

    public static int m_currentframe;
    public static bool m_anyone_frapped;

    private S_Anim_Loop[] m_damageIconAnim;
    private Animator m_animator;
    private int m_life;
    private float m_hintTimer;
    private bool m_hinted;
    private bool m_hint;
    private S_Enemy m_enemy;
    private BoxCollider m_collider;

    private S_Charact_Controller m_charact;
}
