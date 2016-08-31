using UnityEngine;
using System.Collections;
using HighlightingSystem;


public class S_Interact : MonoBehaviour
{

    public Color Color_Base = Color.gray;
    public Color Color_IsBehind = Color.cyan;
    public Color Color_IsUsed = Color.blue;

    public GameObject Props_Sprite;

	void Start ()
    {
        m_renderer = GetComponent<Renderer>();
        m_renderer.material.color = new Color( 1, 1, 1, 0.7f );
        m_highlighter = Props_Sprite.AddComponent<Highlighter>();
    }
	
	void Update ()
    {
	    if ( m_canInteract && Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log( "Interact" );
            m_highlighter.ConstantOnImmediate( Color_IsUsed );
            //m_renderer.material.color = new Color( 1, 0, 0, 1f );
        }
	}
    
    void OnTriggerEnter(Collider collision)
    {
        if ( !m_charact_controller )
            m_charact_controller = collision.gameObject.GetComponent<S_CharactController>();

        m_charact_controller.IsHidden = true;

        m_canInteract = true;
        m_highlighter.ConstantOnImmediate( Color_IsBehind );
       // m_renderer.material.color = new Color( 1, 1, 1, 1f );
    }

    void OnTriggerExit(Collider collision)
    {
        m_charact_controller.IsHidden = false;

        m_canInteract = false;
        m_highlighter.ConstantOnImmediate( Color_Base );
        //m_renderer.material.color = new Color( 1, 1, 1, 0.7f );
    }

    private bool m_canInteract;
    private Renderer m_renderer;
    private S_CharactController m_charact_controller;
    private Highlighter m_highlighter;
}
