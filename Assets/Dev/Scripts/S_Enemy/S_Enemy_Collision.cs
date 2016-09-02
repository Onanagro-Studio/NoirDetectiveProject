using UnityEngine;
using System.Collections;

public class S_Enemy_Collision : MonoBehaviour
{
    
	void Start ()
    {
        m_hinted = false;
        m_enemy = GetComponent<S_Enemy>();

        m_life = 3;
    }
	
	void Update ()
    {
	    if ( m_hinted && Time.realtimeSinceStartup > m_hintTimer )
        {
            m_hinted = false;

            m_enemy.SetColor( Color.white );

            if ( m_life <= 0 )
                Destroy( this.gameObject );
        }
	}
    
    void OnTriggerEnter(Collider collision)
    {
        if ( m_enemy.m_AI.m_state != Enemy_AI_State.Sleep)
        {
            if( m_enemy.m_AI.m_state != Enemy_AI_State.Attack )
                m_enemy.m_AI.Start_SleepRandom();
            else
            if( m_life > 0 )
            {
                m_hinted = true;
                m_enemy.SetColor( Color.red );

                m_hintTimer = Time.realtimeSinceStartup + 0.1f;

                m_life--;
            }
        }
    }

    private int m_life;
    private float m_hintTimer;
    private bool m_hinted;
    private S_Enemy m_enemy;
}
