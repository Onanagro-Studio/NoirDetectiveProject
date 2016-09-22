using UnityEngine;
using System.Collections;

public class S_Text_Anim : MonoBehaviour
{
    public float m_speed = 80.0f;
    public S_MenuButtonManager m_manager;
    
    void Start ()
    {
        Reset();
    }

    void OnEnable()
    {
        Reset();
    }
	
	void Update ()
    {
        if( m_scroll && Time.realtimeSinceStartup > m_startTimer )
        {
            if( m_scroll )
            {
                m_transform.position += m_transform.up * m_speed * Time.deltaTime;

                if( m_transform.position.y > 2589.0f )
                    m_scroll = false;
            }
        }

        if( Input.GetButtonDown( "Joy0_A" ) )
            m_manager.Credits_Back();
    }

    private void Reset()
    {
        if( !m_transform )
            m_transform = GetComponent<Transform>();

        m_transform.position = new Vector3( m_transform.position.x, 0, m_transform.position.z );
        m_scroll = true;
        m_startTimer = Time.realtimeSinceStartup + 2.0f;
    }

    private float m_startTimer;
    private bool m_scroll;
    private Transform m_transform;
}
