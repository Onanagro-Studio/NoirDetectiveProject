using UnityEngine;
using System.Collections;

public class S_Enemy_Drunk : MonoBehaviour
{

    void Start()
    {
        m_hinted = false;
        m_enemy = GetComponent<S_Enemy>();
        m_renderer = GetComponentInChildren<SpriteRenderer>();
    }
    
    void OnTriggerEnter(Collider collision)
    {
        if( collision.gameObject.layer == 11 )
        {
            if( !Input.GetButton( "Joy0_Kill" ) )
            {
                if ( !m_hinted )
                {
                    m_hinted = true;
                    m_renderer.material.color = Color.green;
                }
            }
            else
            {
                if( m_hinted )
                {
                    S_Charact_Madness.Madness += 0.2f;
                    Destroy( this.gameObject );

                    Debug.Log( "You have kill him, you are a mad man !" );
                }
            }
        }
    }

    private SpriteRenderer m_renderer;
    private bool m_hinted;
    private S_Enemy m_enemy;
}
