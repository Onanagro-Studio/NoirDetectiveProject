using UnityEngine;
using System.Collections;

public class S_Charact_Collision : MonoBehaviour
{
    void Start()
    {
        m_renderer = GetComponentInChildren<SpriteRenderer>();
        m_hinted = false;
    }

    void Update()
    {
        if( m_hinted && Time.realtimeSinceStartup > m_hintTimer )
        {
            m_hinted = false;
            m_renderer.color = Color.white;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 14 )
        {
            S_MadnessBar.progress += 0.05f;

            m_hinted = true;
            m_hintTimer = Time.realtimeSinceStartup + 0.1f;

            m_renderer.color = Color.red;

            Debug.Log( "Player is Frapped !" );
        }
    }

    private bool m_hinted;
    private float m_hintTimer;
    private SpriteRenderer m_renderer;
}
