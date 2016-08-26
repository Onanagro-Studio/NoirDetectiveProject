using UnityEngine;
using System.Collections;

public class S_Enemy_Collision : MonoBehaviour
{
    
	void Start ()
    {
        m_hinted = false;
        m_renderer = GetComponentInChildren<SpriteRenderer>();
    }
	
	void Update ()
    {
	    if ( m_hinted && Time.realtimeSinceStartup > m_hintTimer )
        {
            //m_hinted = false;
            //m_renderer.color = new Color( 1, 1, 1 );
            Destroy( this.gameObject );
        }
	}
    
    void OnTriggerEnter(Collider collision)
    {
        if (!m_hinted)
        {
            m_hinted = true;
            m_renderer.color = new Color( 1, 0, 0 );

            m_hintTimer = Time.realtimeSinceStartup + 0.15f;
        }
    }

    private float m_hintTimer;
    private bool m_hinted;
    private SpriteRenderer m_renderer;
}
