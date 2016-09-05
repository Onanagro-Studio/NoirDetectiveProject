using UnityEngine;
using System.Collections;
using HighlightingSystem;

public class S_Interact : MonoBehaviour
{
    public Color ColorBase = Color.gray;
    public Color ColorIsBehind = Color.cyan;
    public Color ColorIsUsed = Color.blue;
    
    public GameObject Props_Sprite;
    
    void Update ()
    {
        if ( m_canInteract && Input.GetKeyDown(KeyCode.E))
        {
            m_highlighter.ConstantOnImmediate( ColorIsUsed );
            On_Interact_Start( m_last_colision );
        }
    }
    
    void OnTriggerEnter(Collider collision)
    {
        if ( !m_charact_controller )
            m_charact_controller = collision.gameObject.GetComponent<S_Charact_Controller>();

        m_canInteract = true;
        m_highlighter.ConstantOnImmediate( ColorIsBehind );

        m_last_colision = collision;
    }

    void OnTriggerExit(Collider collision)
    {
        m_canInteract = false;
        m_highlighter.ConstantOnImmediate( ColorBase );

        On_Interact_Leave( collision );
    }
    
    #region Interact
    protected void Interact_Init()
    {
        m_renderer = GetComponent<Renderer>();
        m_renderer.material.color = new Color( 1, 1, 1, 0.7f );
        m_highlighter = Props_Sprite.AddComponent<Highlighter>();
        m_highlighter.ConstantOnImmediate( ColorBase );
    }

    protected virtual void On_Interact_Start(Collider _collision)
    {
        Debug.Log( "Interact" );
    }

    protected virtual void On_Interact_Leave(Collider _collision)
    {

    }
    #endregion

    protected bool m_canInteract;
    protected Collider m_last_colision;
    protected Renderer m_renderer;
    protected S_Charact_Controller m_charact_controller;
    protected Highlighter m_highlighter;
}
