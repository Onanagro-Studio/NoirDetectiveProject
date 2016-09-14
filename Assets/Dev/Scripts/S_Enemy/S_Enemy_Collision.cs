using UnityEngine;
using System.Collections;

public class S_Enemy_Collision : MonoBehaviour
{
    public GameObject ConeLightObject;

	void Start ()
    {
        m_hinted = false;
        m_iskill = false;
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

            if( m_life <= 0 )
                Kill();
        }

        //if( m_iskill && Time.realtimeSinceStartup > m_deathAnimTimer )
        //    Destroy( this.gameObject );
	}
    
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 11 && !m_iskill)
        {
            if( !S_Charact_Controller.m_isKillKey )
            {
                if( m_enemy.m_AI.m_state != Enemy_AI_State.Sleep )
                {
                    if( m_enemy.m_AI.m_state != Enemy_AI_State.Attack )
                    {
                        m_enemy.m_AI.Start_SleepRandom();
                        Debug.Log( "Dodo" );

                        //m_animator.SetBool( "IsStun", true );
                    }
                    else
                    if( m_life > 0 )
                    {
                        m_hinted = true;
                        m_enemy.SetColor( Color.red );

                        m_animator.SetInteger( "TakeDamage", Random.Range( 0, 2 ) );
                        m_animator.SetTrigger( "IsDamaged" );

                        if (m_iskill)
                            Kill();

                        m_hintTimer = Time.realtimeSinceStartup + 0.1f;

                        m_life--;
                    }
                }
            }
            else
            {
                Debug.Log( m_enemy.m_AI.m_state );

                if( m_enemy.m_AI.m_state == Enemy_AI_State.Sleep )
                {
                    S_Charact_Madness.Madness += 0.2f;
                    Debug.Log( "You have kill him, you are a mad man !" );

                    Kill();
                }
            }
        }
    }

    private void Kill()
    {
        Debug.Log( "Death" );

        m_enemy.SetVelocity( 0, 0 );
        m_animator.SetTrigger( "IsDead" );
        m_iskill = true;
        //m_deathAnimTimer = Time.realtimeSinceStartup + 2f;
        m_enemy.SetColor( new Color(0, 0, 0, 0) );
        m_enemy.m_AI.m_state = Enemy_AI_State.Dead;
        ConeLightObject.SetActive( false );
    }

    private float m_deathAnimTimer;
    private bool m_iskill;
    private Animator m_animator;
    private int m_life;
    private float m_hintTimer;
    private bool m_hinted;
    private S_Enemy m_enemy;
}
