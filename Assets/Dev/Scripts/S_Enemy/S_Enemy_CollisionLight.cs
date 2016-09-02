using UnityEngine;
using System.Collections;

public class S_Enemy_CollisionLight : MonoBehaviour
{
    
	void Start ()
    {
        m_renderer = GetComponent<Renderer>();
        m_AI = GetComponentInParent<S_Enemy_AI>();

        m_is_see = false;
    }
	
	void Update ()
    {
        if ( m_is_see && m_AI.m_state != Enemy_AI_State.Attack && !m_player_charact_controller.IsHidden && m_AI.m_state != Enemy_AI_State.Sleep )
        {
            m_AI.Attack_Player( m_player_transform );
        }
	}

    void OnTriggerEnter(Collider collision)
    {
        if( !m_player_transform )
        {
            m_player_transform = collision.GetComponent<Transform>();
            m_player_charact_controller = collision.GetComponent<S_CharactController>();
        }

        m_is_see = true;
    }

    void OnTriggerExit(Collider collision)
    {
        m_is_see = false;
    }

    private bool m_is_see;
    private Transform m_player_transform;
    private S_CharactController m_player_charact_controller;

    private Renderer m_renderer;
    private S_Enemy_AI m_AI;
}
