using UnityEngine;
using System.Collections;

public class S_Enemy_AnimController : MonoBehaviour
{

    Transform m_Transform;
    Animator m_Animator;


    public GameObject m_SpineMechanism;
    public float m_SpeedX = 5f;



    // Use this for initialization
    void Start()
    {
        m_Transform = GetComponent<Transform>();
        m_Animator = m_SpineMechanism.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX =  Input.GetAxis("Horizontal") * Time.deltaTime * m_SpeedX;

        m_Animator.SetFloat( "Speed", moveX );

        if( Input.GetAxis( "Horizontal" ) < 0 )
            m_Transform.localScale = new Vector3( -1, m_Transform.localScale.y, m_Transform.localScale.z );
        else if( Input.GetAxis( "Horizontal" ) > 0 )
            m_Transform.localScale = new Vector3( 1, m_Transform.localScale.y, m_Transform.localScale.z );



        m_Transform.position = new Vector3( m_Transform.position.x + moveX, m_Transform.position.y, m_Transform.position.z );

        if( Input.GetKeyDown( KeyCode.K ) )
        {
            m_Animator.SetTrigger( "IsDead" );
        }
        if( Input.GetKeyDown( KeyCode.L ) )
        {
            m_Animator.SetInteger( "TakeDamage", Random.Range( 0, 2 ) );
            m_Animator.SetTrigger( "IsDamaged" );
        }

        if( Input.GetKeyDown( KeyCode.E ) )
        {
        
            m_Animator.SetInteger( "Attack", Random.Range( 0, 2 ) );
            m_Animator.SetTrigger( "IsAttacking" );
        }
        if( Input.GetKeyDown( KeyCode.R ) )
        {
            m_Animator.SetBool( "???", !m_Animator.GetBool("???") );
        }


    }
}
