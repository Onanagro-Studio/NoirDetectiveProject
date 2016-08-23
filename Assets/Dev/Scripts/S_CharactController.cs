using UnityEngine;
using System.Collections;

public class S_CharactController : MonoBehaviour
{
    public float ZoneCam = 8.0f;
    public BoxCollider FightBox;

	void Start ()
    {
        m_transform = GetComponent<Transform>();
        m_body = GetComponent<Rigidbody>();
        m_cam_transform = Camera.main.transform;

        m_dir_R = false;
        m_dir_L = false;

        FightBox.enabled = false;
    }
	
	void Update ()
    {
        float dx = Input.GetAxis("Horizontal") * 10.0f;
        m_body.velocity = new Vector3( dx, m_body.velocity.y, 0 );
        
        if( dx > 0.0f && !m_dir_R )
        {
            m_dir_R = true;
            m_dir_L = false;

            m_transform.localScale = new Vector3( 0.75f, 0.75f, 1 );
        }
        else
        if( dx < 0.0f && !m_dir_L )
        {
            m_dir_L = true;
            m_dir_R = false;

            m_transform.localScale = new Vector3( -0.75f, 0.75f, 1 );
        }

        if ( m_transform.position.x > m_cam_transform.position.x + ZoneCam )
        {
            m_cam_transform.position = new Vector3( m_transform.position.x - ZoneCam, m_cam_transform.position.y, m_cam_transform.position.z );
        }
        else
        if( m_transform.position.x < m_cam_transform.position.x - ZoneCam )
        {
            m_cam_transform.position = new Vector3( m_transform.position.x + ZoneCam, m_cam_transform.position.y, m_cam_transform.position.z );
        }

        if( Input.GetKeyDown( KeyCode.Q ) )
            FightBox.enabled = true;
        else
            FightBox.enabled = false;
    }
    
    private bool m_dir_R;
    private bool m_dir_L;

    private Transform m_transform;
    private Rigidbody m_body;
    private Transform m_cam_transform;
}
