using UnityEngine;
using System.Collections;

public class S_Enemy_Collision : MonoBehaviour
{
    
	void Start ()
    {
        m_hinted = false;
        m_renderer = GetComponentInChildren<SpriteRenderer>();
        m_AI = GetComponent<S_Enemy_AI>();

        m_life = 3;
    }
	
	void Update ()
    {
	    if ( m_hinted && Time.realtimeSinceStartup > m_hintTimer )
        {
            m_hinted = false;

            m_renderer.color = Color.white;

            if ( m_life <= 0 )
                Destroy( this.gameObject );
        }
	}
    
    void OnTriggerEnter(Collider collision)
    {
        if (m_AI.m_state != EnemyAction.Sleep)
        {
            if( m_AI.m_state != EnemyAction.Attack )
                m_AI.Start_SleepRandom();
            else
            if( m_life > 0 )
            {
                m_hinted = true;
                m_renderer.color = Color.red;

                m_hintTimer = Time.realtimeSinceStartup + 0.1f;

                m_life--;
            }
        }
    }

    private int m_life;
    private float m_hintTimer;
    private bool m_hinted;
    private SpriteRenderer m_renderer;
    private S_Enemy_AI m_AI;
}
