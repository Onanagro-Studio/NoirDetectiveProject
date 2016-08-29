using UnityEngine;
using System.Collections;

public class S_Enemy_Collision_Light : MonoBehaviour
{
    
	void Start ()
    {
        m_renderer = GetComponent<Renderer>();
        m_AI = GetComponentInParent<S_Enemy_AI>();
    }
	
	void Update ()
    {
	
	}

    void OnTriggerEnter(Collider collision)
    {
        m_renderer.material.color = Color.red;
        m_AI.Attack_Player( collision.GetComponent<Transform>() );
    }

    private Renderer m_renderer;
    private S_Enemy_AI m_AI;
}
