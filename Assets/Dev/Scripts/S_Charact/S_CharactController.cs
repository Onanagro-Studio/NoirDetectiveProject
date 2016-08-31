using UnityEngine;
using System.Collections;
using HighlightingSystem;

public class S_CharactController : MonoBehaviour
{
    public float ZoneCam = 8.0f;
    
    public bool IsHidden;
    public Color HighlightColor = Color.black;

    public bool IsHighlighted = false;

    [HideInInspector]
    public BoxCollider FightBoxRight, FightBoxLeft ;
    [HideInInspector]
    public GameObject m_SpriteLeft, m_SpriteRight;

    void Start()
    {
        m_transform = GetComponent<Transform>();
        m_body = GetComponent<Rigidbody>();
        m_cam_transform = Camera.main.transform;
        m_highlightRight = m_SpriteRight.AddComponent<Highlighter>();
        m_highlightLeft = m_SpriteLeft.AddComponent<Highlighter>();

        m_dir_R = false;
        m_dir_L = false;
        FightBoxLeft.enabled = false;
        FightBoxRight.enabled = false;
        IsHidden = false;
    }

    void Update()
    {

        if( IsHighlighted && m_dir_L ) m_highlightLeft.ConstantOnImmediate( HighlightColor );
        else m_highlightLeft.ConstantOffImmediate();
        if( IsHighlighted && m_dir_R) m_highlightRight.ConstantOnImmediate( HighlightColor );
        else m_highlightRight.ConstantOffImmediate();

        if( Input.GetKeyDown( KeyCode.G ) )
            S_SceneManager.Load_GameOver();

        float dx = Input.GetAxis("Horizontal") * 10.0f;
        m_body.velocity = new Vector3( dx, m_body.velocity.y, 0 );

        if( dx > 0.0f && !m_dir_R )
        {
            m_dir_R = true;
            m_dir_L = false;

            m_SpriteLeft.SetActive( false );
            m_SpriteRight.SetActive( true );
         
        }
        else
        if( dx < 0.0f && !m_dir_L )
        {
            m_dir_L = true;
            m_dir_R = false;

            m_SpriteLeft.SetActive( true );
            m_SpriteRight.SetActive( false );

        }

        if( m_transform.position.x > m_cam_transform.position.x + ZoneCam )
        {
            m_cam_transform.position = new Vector3( m_transform.position.x - ZoneCam,m_cam_transform.position.y, m_cam_transform.position.z );
        }
        else
        if( m_transform.position.x < m_cam_transform.position.x - ZoneCam )
        {
            m_cam_transform.position = new Vector3( m_transform.position.x + ZoneCam, m_cam_transform.position.y, m_cam_transform.position.z );
        }

        if( Input.GetKeyDown( KeyCode.Q ))
        {
            if( m_SpriteLeft.activeInHierarchy ) FightBoxLeft.enabled = true;
            if( m_SpriteRight.activeInHierarchy ) FightBoxRight.enabled = true;
        }
        else
        {
            if( m_SpriteLeft.activeInHierarchy ) FightBoxLeft.enabled = false;
            if( m_SpriteRight.activeInHierarchy ) FightBoxRight.enabled = false;
        }

    }

    private bool m_dir_R;
    private bool m_dir_L;

    private Transform m_transform;
    private Rigidbody m_body;
    private Transform m_cam_transform;
    private Highlighter m_highlightRight, m_highlightLeft;
}
