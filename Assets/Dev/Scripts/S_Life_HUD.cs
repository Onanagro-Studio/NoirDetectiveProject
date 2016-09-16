using UnityEngine;
using System.Collections;

public class S_Life_HUD : MonoBehaviour
{
    
	void Start ()
    {
        m_renderer = GetComponent<SpriteRenderer>();
    }
	
	void Update ()
    {
        m_renderer.color = new Color( m_renderer.color.r, m_renderer.color.g, m_renderer.color.b, 1 - S_Charact_Collision.m_life / 100.0f);
    }

    private SpriteRenderer m_renderer;
}
