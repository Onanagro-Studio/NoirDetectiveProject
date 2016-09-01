using UnityEngine;
using System.Collections;
using HighlightingSystem;

public class S_Highlight_Color : MonoBehaviour
{


    public GameObject m_Sprite;
    public Color HighlightColor = Color.black;
    public bool IsHighlighted = false;

    void Awake()
    {
        m_highlight = m_Sprite.AddComponent<Highlighter>();
       

    }

    // Use this for initialization
    void Start()
    {

      


    }

    // Update is called once per frame
    void Update()
    {

        if( IsHighlighted ) m_highlight.ConstantOnImmediate( HighlightColor );
        else m_highlight.ConstantOffImmediate();

    }

    private Highlighter m_highlight;
}
