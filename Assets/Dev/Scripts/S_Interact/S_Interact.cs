using UnityEngine;
using System.Collections;
using HighlightingSystem;

public class S_Interact : MonoBehaviour
{
    public Color ColorBase = Color.gray;
    public Color ColorIsBehind = Color.cyan;
    public Color ColorIsUsed = Color.blue;
    
    public GameObject Props_Sprite;
    public InteractType Interact_Type = InteractType.Default;
    
    void Update ()
    {
        if ( m_canInteract && Input.GetButtonDown( "Joy0_Interact" ) )
        {
            m_highlighter.ConstantOnImmediate( ColorIsUsed );
            On_Interact_Start( m_last_colision );
        }
    }
    
    void OnTriggerEnter(Collider collision)
    {
        if( !m_charact_controller )
            Get_Char_Infos( collision );

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
        m_InteractTransform = GetComponent<Transform>();
        m_SpriteTransform = Props_Sprite.GetComponent<Transform>();
        
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

    protected void Get_Char_Infos(Collider _collision)
    {
        m_charact_controller = _collision.gameObject.GetComponent<S_Charact_Controller>();
        m_CharTransform = m_charact_controller.GetComponent<Transform>();
        m_CharSpriteLeftTransform = m_charact_controller.m_SpriteLeft.GetComponent<Transform>();
        m_CharSpriteRightTransform = m_charact_controller.m_SpriteRight.GetComponent<Transform>();
    }
    #endregion

    protected Transform m_InteractTransform;
    protected Transform m_SpriteTransform;

    protected Transform m_CharTransform;

    protected Transform m_CharSpriteLeftTransform, m_CharSpriteRightTransform;


    protected bool m_canInteract;
    protected Collider m_last_colision;
    protected Renderer m_renderer;
    protected S_Charact_Controller m_charact_controller;
    protected Highlighter m_highlighter;
}

public enum InteractType
{
    Default,
    Ladder
}