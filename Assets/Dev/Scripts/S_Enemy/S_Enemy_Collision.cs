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

            m_renderer.color = new Color( 1, 1, 1 );

            if ( m_life <= 0 )
                Destroy( this.gameObject );
        }
	}
    
    void OnTriggerEnter(Collider collision)
    {
        if (m_life > 0)
        {
            if( m_AI.m_state != EnemyAction.Attack )
                m_AI.Attack_Player( collision.transform );

            m_hinted = true;
            m_renderer.color = new Color( 1, 0, 0 );

            m_hintTimer = Time.realtimeSinceStartup + 0.1f;

            m_life--;
        }
    }

    private int m_life;
    private float m_hintTimer;
    private bool m_hinted;
    private SpriteRenderer m_renderer;
    private S_Enemy_AI m_AI;
}
